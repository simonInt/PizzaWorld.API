using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pizzaWorld.Dtos;
using pizzaWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaWorld.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        public readonly IMapper _mapper;
        public readonly UserManager<User> _userManager;
        public readonly RoleManager<Role> _roleManager;
        public AuthController(IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
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

        [HttpPost("signin")]
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
                return Ok();
            }
            return BadRequest("Mot de passe incorrect");
        }
        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Le rôle doit avoir un nom");
            };

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
    }


}
