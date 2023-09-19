using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationSettings appSettings;

        public ApplicationUserController(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager,IOptions<ApplicationSettings> _appSettings)
        {
            this.appSettings = _appSettings.Value;
            this.userManager = _userManager;
            this.signInManager = _signInManager;
        }

        [HttpPost]
        [Route("Register")]

        // POST request :: /api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            model.Role = "Viewer";
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName       // Password will be encrypted that's why not mentioned here...
            };

            try
            {
                var result =await userManager.CreateAsync(applicationUser, model.Password);  /// Password will be encrypted
                await userManager.AddToRoleAsync(applicationUser, model.Role);
                return Ok(result);
            } catch(Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.UserName);
            if(user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]{
                        new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JWT_Secret)),SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect! Please try again!" });
            }
        }
    }
}
