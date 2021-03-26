using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using pizzaWorld.Dtos;
using pizzaWorld.Models;
using pizzaWorld.Settings;

namespace pizzaWorld.Controllers
{
    [ApiController]
    [Route("auth")]

    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IOptionsSnapshot<JwtSettings> _jwtSettings;

        public AuthController(IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings;
        }


        [HttpPost("signup")]

        public async Task<IActionResult> SignUp([FromBody] UserSignUpDto userSignUpDto)
        {
            var user = _mapper.Map<User>(userSignUpDto);

            var userCreateResult = await _userManager.CreateAsync(user, userSignUpDto.Password);

            if (userCreateResult.Succeeded)
            {
                return Created(string.Empty, string.Empty);
            }

            return Problem(userCreateResult.Errors.First().Description, null, 400);
        }

        [HttpPost("signIn")]

        public async Task<IActionResult> SignIn([FromBody] UserLoginDto userLoginDto)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userLoginDto.Email);

            if (user is null)
            {
                return NotFound("L'utilisateur n'existe pas.");
            }

            var userSigninResult = await _userManager.CheckPasswordAsync(user, userLoginDto.Password);

            if (userSigninResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(GenerateJwt(user, roles));
            }

            return BadRequest("Mot de passe incorrect.");
        }

        [HttpPost("Roles")]

        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {

            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("le rôle doit avoir un nom");
            }

            var newRole = new Role
            {
                Name = roleName
            };

            var roleResult = await _roleManager.CreateAsync(newRole);

            if (roleResult.Succeeded)
            {
                return Ok();
            }

            return Problem(roleResult.Errors.First().Description, null, 400);
        }

        [HttpPost("user/{userEmail}/role")]
        public async Task<IActionResult> AddUserToRole(string userEmail, [FromBody] string roleName)
        {

            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userEmail);
            var result = await _userManager.AddToRoleAsync(user, roleName);


            if (result.Succeeded)
            {
                return Ok();
            }

            return Problem(result.Errors.First().Description, null, 400);
        }

        private string GenerateJwt(User user, IList<string> roles)

        {

            var claims = new List<Claim>

            {

                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),

                new Claim(ClaimTypes.Name, user.UserName),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())            };



            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));

            claims.AddRange(roleClaims);



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.Value.ExpirationInDays));



            var token = new JwtSecurityToken(

                issuer: _jwtSettings.Value.Issuer,

                audience: _jwtSettings.Value.Issuer,

                claims,

                expires: expires,

                signingCredentials: creds

            );



            return new JwtSecurityTokenHandler().WriteToken(token);

        }



        /*
        public string GenerateJwt(User user, IList<string>, roles);
        {

            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userEmail);
            var result = await _userManager.AddToRoleAsync(user, roleName);


            if (result.Succeeded)
            {
                return Ok();
            }

            return Problem(result.Errors.First().Description, null, 400);
        }*/



    }


}