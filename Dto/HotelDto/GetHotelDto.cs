using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServe.Dto.HotelDto
{
    public class GetHotelDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public float Price { get; set; }
        public string Description { get; set; } = string.Empty;

         public List<string> ImageUrl {get; set;} = new List<string>();

        public bool FreeCancellation { get; set; } = false;

        public bool ReserveNow { get; set; } = false;
        
    }
}