using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   
   
    public class Student
    {
        [Key]
        [ForeignKey("user")]
        public string ID { set; get; }

        public ApplicationUserIdentity user { set; get; }
        
        public string firstName { set; get; }
        public string lastName { set; get; }
        public int age { set; get; }
        //
        [DefaultValue("download.jpg")]
        public string image { set; get; } 
        
        public string password { set; get; }
        public string gender{ set; get; }



        //public ICollection<Exam> exams { set; get; }
    }
}
