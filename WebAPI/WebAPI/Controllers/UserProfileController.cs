using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;

        public UserProfileController(UserManager<ApplicationUser> _userManager)
        {
            this.userManager = _userManager;
        }

        [HttpGet]  // api/UserProfile
        [Authorize]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await userManager.FindByIdAsync(userId);
            return new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.UserName
            };
        }
    }
}
