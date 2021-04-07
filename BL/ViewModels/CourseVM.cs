using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BL.ViewModels
{
    public class CourseVM
    {
        public int ID { set; get; }

        [Required]
        [Display(Name = "Title")]
        public string title { set; get; }

        [Required]
        [MinLength(10, ErrorMessage = "Must more than 10 Character")]
        [Display(Name = "Description")]
        public string description { set; get; }


        [Display(Name = "Image")]
        public string image { set; get; }
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{1,3}")]
        [Display(Name = "Hours")]
        public int hours { set; get; }

        public int Category_ID { set; get; }
    }
}
