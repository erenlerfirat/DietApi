using Core.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Core.Attributes.JWT
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly long[] _role;
        public AuthorizeAttribute(long[] role = null)
        {
            _role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (UserLoginDto)context.HttpContext.Items["UserLogin"];
            
            if (user == null)
            {
                context.Result = new JsonResult(new { message = "Not Authenthicated" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }
            if (_role != null )
            {
                if (!_role.Contains(user.Role))
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status403Forbidden };
            }
        }
    }
}
