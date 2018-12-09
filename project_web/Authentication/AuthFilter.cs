using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using LUG3WebApi.Authentication.Model;

namespace LUG3WebApi.Authentication
{
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        private readonly UserManager<ApplicationUser> userStore;

        public AuthFilter(UserManager<ApplicationUser> userStore)
        {
            this.userStore = userStore;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.ActionDescriptor.FilterDescriptors.Any(fd => fd.Filter is AllowAnonymousFilter))
            {
                var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                var userName = context.HttpContext.Request.Headers["User"].FirstOrDefault() ?? "";
                var user = userStore.FindByNameAsync(userName).Result;

                if (user == null || token == null)
                {
                    context.Result = new UnauthorizedResult();
                }
                else
                {
                    var isValid = userStore.VerifyUserTokenAsync(user, "PasswordlessLoginTotpProvider", "passwordless-auth", token).Result;
                    if (isValid)
                    {
                       this.SignIn(context, user).Wait(); 
                    }
                    else 
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
        }

        private async Task SignIn(AuthorizationFilterContext context, ApplicationUser user) 
        {
            var identity = new ClaimsIdentity(await userStore.GetClaimsAsync(user));

            context.HttpContext.User = new ClaimsPrincipal(new List<ClaimsIdentity>() { identity });
            await context.HttpContext.SignInAsync("Identity.TwoFactorUserId", context.HttpContext.User);
        }
    }
}
