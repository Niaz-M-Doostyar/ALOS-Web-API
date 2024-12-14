using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ALOS_Web_Admin.Helpers;
using ALOS_Web_Admin.Models.Api.Authentication;
using ALOS_Web_Admin.Models.Api.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ALOS_Web_Admin.Controllers.Api
{

    [Route("api/")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        private readonly alosapiContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticateController(alosapiContext context, IConfiguration configuration)
        {
            this._context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register-client")]
        public async Task<IActionResult> Login([FromQuery]LoginModel model)
        {
            var user = _context.Users.Where(e => e.Name.Equals(model.Username)).FirstOrDefault();
            //var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && LoginModel.LoginCheckViaMobileAndPinCode(user.Mobile, model.Mobile, user.Pincode, model.PinCode))
            {
                //var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    //new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                //foreach (var userRole in userRoles)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddYears(15),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                //ApplicationUserToken<T> s = new ApplicationUserToken<T>()
                //{
                //    Name = user.UserName,
                //    UserId = user.Id,
                //    Value = new JwtSecurityTokenHandler().WriteToken(token)
                //};

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromQuery] RegisterModel model)
        {
            var userExists = _context.Users.FirstOrDefault(u=>u.Name.Equals(model.Username));
            if (userExists != null)
                return NotFound( new Responses { StatusCode = "0",Status = "Error", Data = "User already exists!" });


            Users user = new Users()
            {
                Email = model.Email,
                Name = model.Username,
                Mobile = model.PhoneNumber,
                Password = model.Password,
                Pincode = model.PinCode,
                Status = model.Status,
                Country = model.Country,
                Commission = model.Commission,
                Address = model.Address,
                RememberToken = model.RememberToken,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _context.Users.Add(user);
            int result = _context.SaveChanges();
            if (result>0)
                return Ok(new Responses {StatusCode = "1", Status = "Success", Data = "User created successfully!" });
            return NotFound( new Responses { StatusCode = "0",Status = "Error", Data = "User creation failed! Please check user details and try again." });

           
        }

        //[HttpPost]
        //[Route("register-admin")]
        //public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        //{
        //    var userExists = await userManager.FindByNameAsync(model.Username);
        //    if (userExists != null)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Data = "User already exists!" });

        //    ApplicationUser user = new ApplicationUser()
        //    {
        //        Email = model.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = model.Username
        //    };
        //    var result = await userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Data = "User creation failed! Please check user details and try again." });

        //    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //    if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //    if (await roleManager.RoleExistsAsync(UserRoles.Admin))
        //    {
        //        await userManager.AddToRoleAsync(user, UserRoles.Admin);
        //    }

        //    return Ok(new Responses { Status = "Success", Data = "User created successfully!" });
        //}
    }
}