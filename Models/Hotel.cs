using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataServe.Models
{
    public class Hotel
    {
         [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
         public float Price { get; set; } 

        public bool FreeCancellation{ get; set; } = false;

        public bool ReserveNow { get; set; } = false;

        


        public List<string> ImageUrl { get; set; } = new List<string>();

        //Navigation property : A hotel can have many reviews
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        // public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

 

    }
}