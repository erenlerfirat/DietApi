using Core.Abstract;
using Core.Constants;
using Core.Utilities.CustomException;
using System;

namespace Core.Helpers
{
    public class RoleHelper : IRoleHelper
    {
        public UserRoleEnum GetRole(string role)
        {
            role ??= string.Empty;
            bool result =  Enum.TryParse(role.ToLower(), out UserRoleEnum userRole);

            if (result || UserRoleEnum.admin == userRole)             
                throw new ValidationException(Messages.RoleTypeError);
            
            return userRole;
        }
    }
}
