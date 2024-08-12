using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServe.Context;
using DataServe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataServe.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelPackagesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public TravelPackagesController (ApplicationDbContext context)
        {
            _context = context;
     
        }

        [ HttpGet]
        public async Task<ActionResult<IEnumerable<TravelPackages>>> Get() 
        {
            var travelPackage = await _context.TravelPackages.ToListAsync();
            return Ok(travelPackage);
        }


        [HttpPost]
        public async Task<ActionResult<TravelPackages>> Create([FromBody]TravelPackages travelPackage)
        {
            try {
                if (travelPackage == null)
                {
                    return BadRequest("TravelPackage data is required");
                }

                await _context.TravelPackages.AddAsync(travelPackage);
                await _context.SaveChangesAsync();

                return Ok(travelPackage);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

          [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TravelPackages>>> GetById(int id)
        {
            var travelPackage = await _context.TravelPackages.FindAsync(id);

            if(travelPackage == null){
                return NotFound();
            }

            return Ok(travelPackage);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<TravelPackages>>> Update (int id , TravelPackages updateTravelPackage)
        {
            try {
                 var findTravelPackage = await _context.TravelPackages.FindAsync(id);

            if(findTravelPackage == null)
            {
                return NotFound();
            }

            findTravelPackage.Name = updateTravelPackage.Name;
            findTravelPackage.ImageUrl = updateTravelPackage.ImageUrl;
            findTravelPackage.Description = updateTravelPackage.Description;
            findTravelPackage.Price = updateTravelPackage.Price;
            findTravelPackage.FreeCancellation = updateTravelPackage.FreeCancellation;
            findTravelPackage.ReserveNow = updateTravelPackage.ReserveNow;
            await _context.SaveChangesAsync();

            return Ok("Updated Sucessfully");
            } catch {
                return BadRequest();
            }  
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<TravelPackages>>> Delete(int id)
        {
            var travelPackage = await _context.TravelPackages.FindAsync(id);

            if (travelPackage == null) {
                return NotFound();
            }

            _context.TravelPackages.Remove(travelPackage);
            await _context.SaveChangesAsync();

            return Ok("Deleted Sucessfully");
        }


        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TravelPackages>>> SearchByName([FromQuery] string name)
        {
            var travelPackages = await _context.TravelPackages
                .Where(h => h.Name.Contains(name))
                .ToListAsync();

            if (!travelPackages.Any())
            {
                return NotFound();
            }

            return Ok(travelPackages);
       }






}}