using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class TeacherVM
    {

        public string ID { set; get; }
        public string firstName { set; get; }
        public string lastName { set; get; }
        public int age { set; get; }
        public string gender { set; get; }
        public string password { set; get; }
        public string image { set; get; }
        public string specialty { set; get; }
        public ApplicationUserIdentity user { set; get; }

    }
}
