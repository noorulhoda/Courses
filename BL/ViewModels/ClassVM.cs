using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class ClassVM
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

        public string image { set; get; }
        [Required]
        public DAL.Gender studentsGender { set; get; }

        public string classLink { set; get; }

        public string classLinkPassword { set; get; }

        public DateTime startTime { set; get; }

        public DateTime endTime { set; get; }
    }
}
