using Magic.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Core
{
    public interface IChatClient
    {
        Task ForceExist(string str);

        Task AppendNotice(SysNotice notice);
    }
}
