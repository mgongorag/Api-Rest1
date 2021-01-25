using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int  idUSer { get; set; }
        [Required(ErrorMessage = "The first name is required")]
        [StringLength(50,MinimumLength = 3, ErrorMessage = "First Name should be minimum 3 characters and a maximum of 50 characters")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "The last name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name should be minimum 3 characters and a maximum of 50 characters")]
        public string lastName { get; set; }
        [Required (ErrorMessage = "The birthday is required")]
        [RegularExpression("^\\d{4}([\\-/.])(0?[1-9]|1[1-2])\\1(3[01]|[12][0-9]|0?[1-9])$")]
        public string birthday { get; set; }
        public int idGenter { get; set; }
        [ForeignKey("idGenter")]
        public Gender gender { get; set; }
        [Required(ErrorMessage = "The username is required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Username should be minimum 3 characters and a maximum of 15 characters")]
        [RegularExpression("([a-z]{1,1})([a-z0-9_]{3,15})", ErrorMessage = "Only characters and numeric values are allowed")]
        public string username { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&])([A-Za-z\\d$@$!%*?&]|[^ ]){8,30}$", ErrorMessage = "the password needs at least 8 characters, numerical values a capital letter and a sign")]
        public string password { get; set; }
        public bool isVerificate { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime lastSession { get; set; }

    }
}
