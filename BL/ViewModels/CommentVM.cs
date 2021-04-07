using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class CommentVM
    {
        public int ID { set; get; }

        public string Content { set; get; }

        [ForeignKey("course")]
        public int courseID { set; get; }
        public virtual Course course { set; get; }

        [ForeignKey("user")]
        public string userID { set; get; }
        public virtual ApplicationUserIdentity user { set; get; }
    }
}
