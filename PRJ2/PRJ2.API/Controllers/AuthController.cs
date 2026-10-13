
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PRJ2.API.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PRJ2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> usermanager;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<IdentityUser>usermanager,IConfiguration configuration)
        {
            this.usermanager = usermanager;
            this.configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDTO request)
        {
            var user = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.Email,
            };
            var result = await usermanager.CreateAsync(user, request.Password);
            if(result.Succeeded)
            {
                var role = await usermanager.AddToRoleAsync(user,request.Role);
                if(role.Succeeded)
                {
                    return Ok("user registere successfully with role");
                }

                await usermanager.DeleteAsync(user);
                return BadRequest(role.Errors);
            }

            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO request)
        {
            var user = await usermanager.FindByNameAsync(request.userName);
            if (user == null)
            {
                return BadRequest("Invalid username or password");
            }
            var result = await usermanager.CheckPasswordAsync(user, request.password);
            if (!result)
            {
                return BadRequest("Invalid username or password");
            }

            var roles = await usermanager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                 issuer: configuration["Jwt:Issuer"],
                 audience: configuration["Jwt:Audience"],
                 claims: claims,
                 expires: DateTime.UtcNow.AddMinutes(
                     Convert.ToDouble(configuration["Jwt:DurationInMinutes"])),
    signingCredentials: credentials
                     );

            return Ok(new{
                
          
                
                token = new JwtSecurityTokenHandler().WriteToken(token)});
            {

            };
        }
    }
}
