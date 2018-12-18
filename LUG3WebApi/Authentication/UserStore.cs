using Dapper;
using LUG3WebApi.Authentication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace LUG3WebApi.Authentication
{
    public class UserStore : IUserStore<ApplicationUser>, IUserEmailStore<ApplicationUser>, IUserTwoFactorStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>, IUserSecurityStampStore<ApplicationUser>, IUserClaimStore<ApplicationUser>
    {
        private readonly string _connectionString;

        public UserStore(IConfiguration configuration)
        {
            //_connectionString = configuration.GetConnectionString("DefaultConnection");
            _connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=LU-G3; Integrated Security = true;";
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);
                user.Id = await connection.QuerySingleAsync<int>($@"INSERT INTO [Login] ([Username], [Password], [LoginType],[TwoFactorEnabled], [SecurityStamp])
                VALUES (@{nameof(ApplicationUser.UserName)}, @{nameof(ApplicationUser.Password)}, @{nameof(ApplicationUser.LoginType)},
                @{nameof(ApplicationUser.TwoFactorEnabled)}, @{nameof(ApplicationUser.SecurityStamp)});
                SELECT CAST(SCOPE_IDENTITY() as int)", user);
                if (user.LoginType == 1) {
                    user.IdPostulant = await connection.QuerySingleAsync<int>("SELECT Id FROM [Postulant] WHERE Dni = @Dni", new { @Dni = user.Dni });
                    await connection.ExecuteAsync($" INSERT INTO [PostulantLogin] ([IdPostulant], [IdLogin]) VALUES (@IdPostulant, @IdLogin)", new {@IdPostulant = user.IdPostulant, @IdLogin = user.Id});
                }
               
            }

            return IdentityResult.Success;
        }
        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);
                var dni = await connection.QuerySingleOrDefaultAsync("SELECT Dni FROM [Postulant] WHERE [Dni] = @Dni", new {@Dni = userId});
                
                if (dni == null) 
                {
                    return null;
                } else {
                    ApplicationUser apus = new ApplicationUser(){
                        Dni = userId
                    };
                    return apus;
                }                
            } 
        }

        public async Task<string> FindByDniAsync(string userDni, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);
                return await connection.QuerySingleOrDefaultAsync("SELECT Dni FROM [Postulant] WHERE [Dni] = @Dni", new {@Dni = userDni});
            }
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);
                ApplicationUser apus = await connection.QuerySingleOrDefaultAsync<ApplicationUser>($@"SELECT * FROM Login WHERE [UserName] = @UserName", new { userName });
                if(apus != null){
                    if (apus.LoginType == 1) {
                        apus.IdPostulant = await connection.QuerySingleAsync<int>("SELECT p.Id FROM Postulant p INNER JOIN PostulantLogin pl ON (pl.IdPostulant = p.Id) INNER JOIN Login l ON (l.Id = pl.IdLogin) WHERE l.Username = @Username", new { @Username = userName });
                    }
                } 
                return apus;
            }
        }

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }


        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.FromResult(0);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);
                await connection.ExecuteAsync($@"UPDATE [Login] SET
                [UserName] = @{nameof(ApplicationUser.UserName)},
                [PasswordHash] = @{nameof(ApplicationUser.Password)},
                [TwoFactorEnabled] = @{nameof(ApplicationUser.TwoFactorEnabled)}
                WHERE [Id] = @{nameof(ApplicationUser.Id)}", user);
            }

            return IdentityResult.Success;
        }
        

        public Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancellationToken)
        {
            user.TwoFactorEnabled = enabled;
            return Task.FromResult(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.TwoFactorEnabled);
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Password= passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password != null);
        }

        public void Dispose()
        {
            // Nothing to dispose.
        }

        public Task SetSecurityStampAsync(ApplicationUser user, string stamp, CancellationToken cancellationToken)
        {
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.SecurityStamp);
        }

        public Task<IList<Claim>> GetClaimsAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult<IList<Claim>>(new List<Claim>() 
            {
                new Claim(ClaimTypes.Name, user.UserName),
            });
        }

        public Task AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            var user = await this.FindByNameAsync(claim.Value, cancellationToken);
            return new List<ApplicationUser>() { user };
        }

        public async Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.UserName);
        }

        public async Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.UserName = normalizedName;
            await Task.FromResult(0);
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetEmailAsync(ApplicationUser user, string email, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public async Task<string> GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);
                if (user.LoginType == 1) {
                    return user.UserName;
                } else {
                    return user.UserName;
                }
            }
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return null;
        }

        public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task<ApplicationUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return null;
        }

        public Task<string> GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return null;
        }

        public Task SetNormalizedEmailAsync(ApplicationUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
