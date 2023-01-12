using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinancialsAPI.Data;
using FinancialsAPI.Models;
using Microsoft.AspNetCore.Identity;
using FinancialsAPI.Token;

namespace FinancialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityUserController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IJWTTokenGenerator _jwtToken;

        public IdentityUserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IJWTTokenGenerator jwtToken)
        {
            _jwtToken = jwtToken;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // Login API login
        // Only username and password will be required to authenticate
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin model)
        {
            // Check for username
            var userFromDB = await _userManager.FindByNameAsync(model.Username);

            if (userFromDB == null)
            {
                return BadRequest();
            }

            // Check for password, false => not to block the user if wrong password
            var result = await _signInManager.CheckPasswordSignInAsync(userFromDB, model.Password, false);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return Ok( new 
            { 
                result = result,
                username = userFromDB.UserName,
                email = userFromDB.Email,
                token = _jwtToken.GenerateToken(userFromDB)
            });
        }

        // Login API register
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister model)
        {
            var userToCreate = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Username
            };

            // Create User
            var result = await _userManager.CreateAsync(userToCreate, model.Password);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
