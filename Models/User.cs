using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataServe.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string ? Email { get; set; } 
       

        public string Role { get; set; } = string.Empty;

        
        public string? Password { get; set; } 

        public string? ConfirmPassword { get; set; } 

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

         public ICollection<Booking> Bookings { get; set; } = new List<Booking>();



        
        
    }
}