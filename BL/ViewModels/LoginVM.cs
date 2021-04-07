using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
   public class LoginVM
    {
      
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string PasswordHash { get; set; }

   
    }
}
