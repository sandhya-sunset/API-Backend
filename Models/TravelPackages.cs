using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataServe.Models
{
    public class TravelPackages
    {
        [Key]

        public int Id {get; set;}

        public string Name{get; set;} = string.Empty;

        public string Description{get; set;} = string.Empty;
    
        public int Price{get; set;} 

        public List<string> ImageUrl {get; set;} = new List<string>();

        public bool FreeCancellation {get; set;} = false;
        public bool ReserveNow {get; set;} = false;
        

  
        
    }
}