using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public enum CategoryTitles 
    {
        development,
        desgin,
    }
    public class Category
    {
        public int ID { set; get; }

        [Required]
        public string title { set; get; }

        [Required]
        [MinLength(50,ErrorMessage ="Must more than 50 Character")]
        public string description { set; get; }

    
        public string image { set; get; }

        public ICollection<Course> courses { set; get; }
    }
}
