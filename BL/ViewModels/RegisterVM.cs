
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{

    public enum UserType
    {
        Teacher,
        Student
    }
  /*  public enum Gender
    {
        Male,
        Female
    }*/
    public class RegisterVM : LoginVM
    {
        //[Required]
        //public string UserName { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //public string PasswordHash { get; set; }
      

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Required]
        public UserType userType { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public int age{ get; set; }
        [Required]
        public Gender gender { set; get; }
     
        public string image { set; get; }

    }
}
