using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServe.Dto
{
    public class ReviewDto
    {
        
        public int? Rating {get; set;}

        public string?  ReviewText {get; set;}
         
         //Foreign key to Hotel
        public int? HotelId{get; set;} 

        public int? UserId{get; set;} 



    }
}