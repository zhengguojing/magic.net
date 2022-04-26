using Furion;
using Magic.Core;
using Magic.Core.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Yitter.IdGenerator;

namespace Magic.Web.Core
{
	[AppStartup(9)]
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddConfigurableOptions<ConnectionStringsOptions>();
            services.AddConfigurableOptions<JWTSettingsOptions>();
            services.AddConfigurableOptions<CacheOptions>();
            services.AddConfigurableOptions<SnowIdOptions>();
            services.AddConfigurableOptions<SystemSettingsOptions>();
            services.AddConfigurableOptions<UploadFileOptions>();
            services.AddConfigurableOptions<OAuthOptions>();

            //单位是字节（byte） 1kb=1024byte，默认是30M
            long maxRequestBodySize = Convert.ToInt64(App.Configuration["MaxRequestBodySize"]);
            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = maxRequestBodySize;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = maxRequestBodySize;
            });

            services.SqlSugarConfigure();

            services.AddJwt<JwtHandler>(enableGlobalAuthorize: true);

            services.AddCorsAccessor();

            // 配置远程请求
            services.AddRemoteRequest(option =>
            {
                // 配置天气预报GZIP
                option.AddHttpClient("wthrcdn", c =>
                {
                    c.BaseAddress = new Uri("http://wthrcdn.etouch.cn/");
                }).ConfigurePrimaryHttpMessageHandler(_ =>
                    new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip });
            });
            services.AddControllersWithViews()
                    .AddMvcFilter<RequestActionFilter>()
                    .AddInjectWithUnifyResult<XnRestfulResultProvider>()
                    .AddJsonOptions(options =>
                    {
                        //options.JsonSerializerOptions.DefaultBufferSize = 10_0000;//返回较大数据数据序列化时会截断，原因：默认缓冲区大小（以字节为单位）为16384。
                        options.JsonSerializerOptions.Converters.AddDateFormatString("yyyy-MM-dd HH:mm:ss");
                        options.JsonSerializerOptions.Converters.Add(new LongJsonConverter()); // 配置过长的整数类型返回前端会丢失精度的问题
                        options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // 忽略循环引用 仅.NET 6支持
                    });

            services.AddViewEngine();
            services.AddSignalR();
            services.AddRemoteRequest();

            // 设置雪花id的workerId，确保每个实例workerId都应不同
            var workerId = ushort.Parse(App.GetOptions<SnowIdOptions>().WorkerId);
            YitIdHelper.SetIdGenerator(new IdGeneratorOptions { WorkerId = workerId });

            // 开启自启动定时任务
            App.GetService<ISysTimerService>().StartTimerJob();

            // 注册EventBus服务
            services.AddEventBus(builder =>
            {
                // 注册 Log 日志订阅者
                builder.AddSubscriber<LogEventSubscriber>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // 添加状态码拦截中间件
            app.UseUnifyResultStatusCodes();

            app.UseHttpsRedirection(); // 强制https
            app.UseStaticFiles();

            // Serilog请求日志中间件---必须在 UseStaticFiles 和 UseRouting 之间
            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseCorsAccessor();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseInject(string.Empty);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/hubs/chathub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}