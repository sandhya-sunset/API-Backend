using System.Linq.Expressions;
using DataServe.Context;
using DataServe.Dto;
using DataServe.Dto.HotelDto;
using DataServe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataServe.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelController(ApplicationDbContext Context)
        {
            _context = Context;
        }
        [HttpGet]

        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotel = await _context.Hotels.ToListAsync();
                if (hotel == null)
                {
                    return NotFound("No Hotel Data Found");
                }

                var createHotelDTO = hotel.Select(h => new GetHotelDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    Price = h.Price,
                    ImageUrl = h.ImageUrl,
                    Description = h.Description,
                    FreeCancellation = h.FreeCancellation,
                    ReserveNow = h.ReserveNow
                });

                return Ok(new { message = "The Hotel Data fetched Successfully!", createHotelDTO });
            }
            catch (Exception ex)
            {


                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]

        public async Task<IActionResult> CreateHotel([FromBody] HotelDto createhotelDto)

        {
            //without using Dto
            // try{
            //     if (hotel== null)
            //     {
            //         return BadRequest("Hotel is null");
            //     }
            //     await _context.Hotels.AddAsync(hotel);
            //     await _context.SaveChangesAsync();

            //     return Ok(hotel);
            // }
            // catch(Exception ex)
            // {
            //     Console.WriteLine($"Error:{ex.Message}");
            //     if (ex.InnerException!=null)
            //     {
            //         Console.WriteLine($"InnerException:{ex.InnerException.Message}");
            //     }
            //     return BadRequest(ex.Message);
            // }

            //for Dto

            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }
                var hotel = new Hotel
                {
                  Name = createhotelDto.Name,
                  Price = createhotelDto .Price,
                  ImageUrl = createhotelDto .ImageUrl,
                  Description = createhotelDto.Description,
                  FreeCancellation = createhotelDto.FreeCancellation,


                };

                await _context.Hotels.AddAsync(hotel);
                await _context.SaveChangesAsync();

                var response = new
                {
                    message = "Hotel created successfully",
                    hotel

                };

                return CreatedAtAction(nameof (GetHotelById), new { id = hotel.Id }, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }
        }

        [HttpGet("id")]

        public async Task<IActionResult> GetHotelById(int id )
        {
            try
            {
                var hotelById = await _context.Hotels.FindAsync(id);
                if(hotelById == null)
                {
                    return NotFound("Given Hotel Id is not Found");

                }
                var createHotelDtoById = new HotelDto
                {
                    Name = hotelById.Name,
                    Price = hotelById.Price,
                    ImageUrl = hotelById.ImageUrl,
                    Description = hotelById.Description,
                    FreeCancellation = hotelById.FreeCancellation,
                    ReserveNow = hotelById.ReserveNow

                };

                return Ok(new {message = "Given Id Details:", createHotelDtoById});

                
            } catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateHotel(int Id, [FromBody] HotelDto updateHotelDto)
        {
            try
            {
                var hotelToUpdate = await _context.Hotels.FindAsync(Id);

                if (hotelToUpdate == null)
                {
                    return NotFound("Given Hotel ID is not Found");
                }

                hotelToUpdate.Name = updateHotelDto.Name;
                hotelToUpdate.Price = updateHotelDto.Price;
                hotelToUpdate.ImageUrl = updateHotelDto.ImageUrl;
                hotelToUpdate.Description = updateHotelDto.Description;
                hotelToUpdate.FreeCancellation = updateHotelDto.FreeCancellation;
                hotelToUpdate.ReserveNow = updateHotelDto.ReserveNow;


                _context.Entry(hotelToUpdate).State = EntityState.Modified;


                await _context.SaveChangesAsync();
                return Ok(new { message = "Hotel is Updated Successfully!!", hotelToUpdate });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
            
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteHotel(int Id)
        {
            try
            {
                var hotel = await _context.Hotels.FindAsync(Id);
                if (hotel == null)
                {
                    return NotFound("Hotel is not Found");
                }
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Hotel is Deleted Successfully!!", hotel });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchHotel(string name)
        {
            try
            {
                var hotel = await _context.Hotels.Where(h => h.Name!.Contains(name)).ToListAsync();
                if (hotel == null)
                {
                    return NotFound("Hotel Name is not Found");
                }
                return Ok(new { message = "Related Hotel Name are Found Successfully!!", hotel });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }



}
}