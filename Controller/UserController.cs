using DataServe.Context;
using DataServe.Models;
using Microsoft.AspNetCore.Mvc;
using DataServe.Dto;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using DataServe.Dto.UserDtos;
using Microsoft.EntityFrameworkCore;

namespace DataServe.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetUsers()
        {
            try{
                var user = await _context.Users.ToListAsync();
            if(user == null)
            {
                return NotFound("No User Data Found");
            }

            var getUserDto = user.Select (u => new GetUserDto
            {
                Id = u.Id,
                Username = u.UserName,
                Email = u.Email,
                Password = u.Password,
            });

            return Ok(new { message = "The User Data fetched Successfully!", getUserDto });

            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        
      
        
      
        [HttpPost("SignUp")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto createUserDto)
        {
            try
            {
                // Check if the email already exists
                var emailExists = await _context.Users.SingleOrDefaultAsync(u => u.Email == createUserDto.Email);
                if (emailExists != null)
                {
                    return BadRequest("Email already exists.");
                }

                // Check if the username already exists
                var usernameExists = await _context.Users.SingleOrDefaultAsync(u => u.UserName == createUserDto.Username);
                if (usernameExists != null)
                {
                    return BadRequest("Username already exists.");
                }

                // Check if passwords match
                if (createUserDto.Password != createUserDto.ConfirmPassword)
                {
                    return BadRequest("Passwords do not match.");
                }
                var HashPassword = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);
                // Create a new user
                var newUser = new User
                {
                    UserName = createUserDto.Username,
                    Email = createUserDto.Email,
                    Password = HashPassword
                };
              
                // Add the new user to the database
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                return Ok("User created successfully.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound("No User Data Found");
                }
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Ok(new { message = "User Deleted Successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        

     }
  }}
