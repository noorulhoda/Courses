using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Course
    {
        public int ID { set; get; }

        [Required]
        public string title { set; get; }

        [Required]
        [MinLength(50, ErrorMessage = "Must more than 50 Character")]
        public string description { set; get; }

        
        public string image { set; get; }

        [Required]
        [RegularExpression(@"[0-9]{1,3}")]
        public int hours { set; get; }

        public ICollection<Class> classes { set; get; }
        public ICollection<Comment> comments { set; get; }


    }
}
