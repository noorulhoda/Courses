using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BL.ViewModels
{
    public class CategoryVM
    {
        public int ID { set; get; }
        [Required]
        public string title { set; get; }

        [Required]
        [MinLength(10, ErrorMessage = "Must more than 10 Character")]
        public string description { set; get; }

        [Display(Name = "Image")]
        public string image { set; get; }
       
        public HttpPostedFileBase ImageFile { get; set; }

    }
}
