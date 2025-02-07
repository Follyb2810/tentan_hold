using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using namespace tenant_api.Dtos;
using Microsoft.AspNetCore.Http;
using namespace tenant_api.Models;
using namespace tenant_api.Utils;

namespace namespace tenant_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Jwt _jwt;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, Jwt jwt)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwt = jwt;
        }

        // Register Action
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Add role after user creation
                    await _userManager.AddToRoleAsync(user, "User");
                    return Ok(new { Message = "User Registered Successfully" });
                }

                // Return error message from registration failure
                return BadRequest(new { Message = "Unable to Register User", Errors = result.Errors });
            }

            return BadRequest("Invalid data provided.");
        }

        // Login Action
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDtos model)
        {
            if (ModelState.IsValid)
            {
                var userExist = await _userManager.FindByNameAsync(model.Email);
                if (userExist != null && await _userManager.CheckPasswordAsync(userExist, model.Password))
                {
                    var result = await _signInManager.PasswordSignInAsync(userExist, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        // Generate JWT token asynchronously
                        var token = await _jwt.GenerateJwt(userExist);  // Generate JWT token for the user
                        return Ok(new { Message = "User Logged In Successfully", Token = token });
                    }
                    return Unauthorized(new { Message = "Invalid Credentials" });
                }

                return BadRequest(new { Message = "Invalid Credentials" });
            }

            return BadRequest("Invalid data provided.");
        }
    }
}
