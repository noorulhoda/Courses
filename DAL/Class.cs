using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public enum Gender{
        male,
        female
    }
    public class Class
    {
        public int ID { set; get; }

        [Required]
        public char number { set; get; }

        [Required]
        [RegularExpression(@"[0-9]{1,2}")]
        public int studentsMinAge { set; get; }

        [Required]
        [RegularExpression(@"[0-9]{1,2}")]
        public int studentsMaxAge { set; get; }

        public string  image { set; get; }
        [Required]
        public Gender studentsGender{set; get;}

        public string classLink { set; get; }

        public string classLinkPassword { set; get; }

        public DateTime startTime { set; get; }

        public DateTime endTime { set; get; }

        public ICollection<Student> students { set; get; }
       
        public Teacher teacher { set; get; }

    }
}
