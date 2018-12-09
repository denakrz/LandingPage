
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LUG3WebApi.Authentication
{
    public class PasswordlessLoginTotpTokenProvider<TUser> : TotpSecurityStampBasedTokenProvider<TUser>
        where TUser : class
    {
        public override Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult(false);
        }

        public override async Task<string> GetUserModifierAsync(string purpose, UserManager<TUser> manager, TUser user)
        {
            var email = await manager.GetEmailAsync(user);
            return "PasswordlessLogin:" + purpose + ":" + email;
        }
    }

    public static class CustomIdentityBuilderExtensions
    {
        public static IdentityBuilder AddPasswordlessLoginTotpTokenProvider(this IdentityBuilder builder)
        {
            var userType = builder.UserType;
            var totpProvider = typeof(PasswordlessLoginTotpTokenProvider<>).MakeGenericType(userType);
            return builder.AddTokenProvider("PasswordlessLoginTotpProvider", totpProvider);
        }
    }

}
