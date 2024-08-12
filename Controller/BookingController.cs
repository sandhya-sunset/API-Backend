// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using DataServe.Context;
// using DataServe.Dto;
// using DataServe.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace DataServe.Controller
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class BookingController : ControllerBase
//     {
//         private readonly ApplicationDbContext _context;
//         public BookingController(ApplicationDbContext context)
//         {
//             _context = context;
//         }
//         [HttpGet]

//         public  async Task <ActionResult<Booking>> GetBooking(int id)
//         {
//             var booking = await _context.Bookings
//                                  .Include(b => b.User)
//                                  .Include(b => b.Hotel)
//                                  .FirstOrDefaultAsync(b => b.BookingId == id);
            
//             if (booking == null)
//             {
//                 return NotFound();

//             }

//             return booking;
//         }

//         [HttpPost]
//         public async Task<ActionResult<Booking>> PostBooking(BookingDto bookingDto)
//         {
//             var booking = new Booking()
//             {
//                 BookingDate = bookingDto.BookingDate,
//                 UserId = bookingDto.UserId,
//                 HotelId = bookingDto.HotelId,
                
//             };
//              _context.Bookings.Add(booking);
//              await _context.SaveChangesAsync();
//              return CreatedAtAction(nameof (GetBooking), new { id = booking.BookingId }, booking);
        
//         } 

//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutBooking(int id, Booking booking)
//         {
//             if (id!= booking.BookingId)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(booking).State = EntityState.Modified;

//             try{
//                 await _context.SaveChangesAsync();
//             }

//             catch (DbUpdateConcurrencyException )
//             {
//                 if (!BookingExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }
            
//             return NoContent();
//         }

//         private bool BookingExists(int id)
//         {
//             return _context.Bookings.Any(e => e.BookingId == id);
//         }


        
// }
// }