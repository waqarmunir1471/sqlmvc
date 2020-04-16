using System.ComponentModel.DataAnnotations;
using System;
namespace SQLMVC.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Display(Name="First Name : ")]
        [Required(ErrorMessage="First Name is Required")]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Display(Name="Last Name : ")]
        [Required(ErrorMessage="First Name is Required")]
        [MinLength(3)]
        public string LastName { get; set; }
        [Display(Name="Email : ")]
        [Required(ErrorMessage="Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name="Password : ")]
        [Required(ErrorMessage="Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        // The MySQL DATETIME type can be represented by a DateTime
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}