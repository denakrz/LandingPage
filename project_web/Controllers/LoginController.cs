using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LUG3WebApi.Added;
using LUG3WebApi.Authentication.Model;
using LUG3WebApi.DBManagerAll;
using LUG3WebApi.DBModels;
using LUG3WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LUG3WebApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IDBManager dbm;
        private readonly UserManager<ApplicationUser> userStore;
        private AddedFunctions fnc;
        public LoginController(IDBManager dbm_, UserManager<ApplicationUser> userStore)
        {
            this.dbm = dbm_;
            this.userStore = userStore;
            fnc = new AddedFunctions();
        }

        [HttpGet]
        [AllowAnonymous]
        //GET api/Login
        //[Route("")]
        public async Task<UserInfo> Login([FromHeader] string userName, [FromHeader] string password)
        {
            var user = await userStore.FindByNameAsync(userName);

            if (user == null)
            {
                return null;
            }
            
            if (await userStore.CheckPasswordAsync(user, password))
            {
                var token = await userStore.GenerateUserTokenAsync(user, "PasswordlessLoginTotpProvider", "passwordless-auth");
                UserInfo ui = new UserInfo {
                    Token = token,
                    LoginType = user.LoginType,
                    IdPostulant = user.IdPostulant
                };
                
                return ui;
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GenerateUserPostulant")]
        //GET api/Login/GenerateUserPostulant

        public async Task<IdentityResult> GenerateUser([FromHeader] string username, [FromHeader] string password, [FromHeader] string dni)
        {
            var user = await userStore.FindByNameAsync(username);
            var existDni = await userStore.FindByIdAsync(dni);
            if (user == null && existDni != null)
            {
                var newUser = new ApplicationUser() { UserName = username, Dni = dni, LoginType = 1, SecurityStamp = Convert.ToBase64String(Guid.NewGuid().ToByteArray()) };
                return await userStore.CreateAsync(newUser, password);
            }
            return null;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GenerateUserRRHH")]
        //GET api/Login/GenerateUserRRHH

        public async Task<IdentityResult> GenerateUserRRHH([FromHeader] string userName, [FromHeader] string password)
        {
            var user = await userStore.FindByNameAsync(userName);

            if (user == null)
            {
                var newUser = new ApplicationUser() { UserName = userName, LoginType = 2, SecurityStamp = Convert.ToBase64String(Guid.NewGuid().ToByteArray()) };
                return await userStore.CreateAsync(newUser, password);
            }
            return null;
        }

        [HttpGet]
        [Route("Info")]
        //GET api/Login/Info
        public ActionResult<string> Get([FromHeader] string username, [FromHeader] string password)
        {
            return this.User.Identity.Name;
        }

    }

}
