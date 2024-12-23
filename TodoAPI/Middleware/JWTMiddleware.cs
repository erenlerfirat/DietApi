using Business.Abstract;
using Core.Abstract;
using Core.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DietApi.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate next;

        public JwtMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService,IJwtHelper jwtHelper)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                AttachUserToContext(context, userService, jwtHelper, token);
                jwtHelper.GetUserDetails(jwtHelper.ValidateToken(token));
            }

            await next(context);
        }

        private static void AttachUserToContext(HttpContext context, IUserService userService, IJwtHelper jwtHelper, string token)
        {
            try
            {
                var userDetails = jwtHelper.GetUserDetails(jwtHelper.ValidateToken(token));

                // attach user to context on successful jwt validation
                var user = userService.GetByIdAync(userDetails.UserId).Result.Data;
                context.Items["UserLogin"] = new UserLoginDto { UserId = user.Id,Role = user.UserRoleId };
            }
            catch (Exception ex)
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
