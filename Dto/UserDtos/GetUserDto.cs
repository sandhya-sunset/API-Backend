using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServe.Dto.UserDtos
{
    public class GetUserDto
    {
         public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password{get; set;}

         public string? ConfirmPassword { get; set; }
        
    }
}