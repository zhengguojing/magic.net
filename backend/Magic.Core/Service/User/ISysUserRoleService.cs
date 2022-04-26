﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Magic.Core.Service
{
    public interface ISysUserRoleService
    {
        Task DeleteUserRoleListByRoleId(long roleId);
        Task DeleteUserRoleListByUserId(long userId);
        Task<List<long>> GetUserRoleDataScopeIdList(long userId, long orgId);
        Task<List<long>> GetUserRoleIdList(long userId);
        Task GrantRole(UpdateUserInput input);
    }
}