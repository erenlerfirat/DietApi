using Core.Abstract;
using Core.Constants;
using System;

namespace Core.Helpers
{
    public class RoleHelper : IRoleHelper
    {
        public UserRoleEnum GetRole(string role)
        {
            _ = Enum.TryParse(role.ToLower(), out UserRoleEnum userRole);
            return userRole;
        }
    }
}
