using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Exam
    {
        public int ID { set; get; }
        
        [ForeignKey("student")]
        public int studentID { set; get; }
        public virtual Student student { set; get; }
        
        public int degree { set; get; }
        public int isPassed { set; get;}
    }
}
