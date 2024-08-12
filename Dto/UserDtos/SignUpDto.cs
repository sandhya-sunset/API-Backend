using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServe.Dto.UserDtos
{
    public class SignUpDto
    {
         public string? Username { get; set; }
         public string? Password { get; set; }

         public string? ConfirmPassword { get; set; }
        
    }
}