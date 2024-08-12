using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServe.Context;
using DataServe.Dto.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataServe.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

         public AuthController(ApplicationDbContext context)
        {
            _context = context;
            // _tokenService = tokenService;



        }


          [HttpPost("SignIn")]
          public async Task<IActionResult> UserLogin ([FromBody] SignInDto GetSignInDto)
          {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u  => u.UserName == GetSignInDto.UserName);

                if (user == null)
                {
                    return BadRequest("Username does not exist");
                }

                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(GetSignInDto.Password, user.Password);
                if (isPasswordValid)
                {
                    return BadRequest("Password is incorrect");
                }
                 return Ok("User Login Successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

                

          }
    }
}