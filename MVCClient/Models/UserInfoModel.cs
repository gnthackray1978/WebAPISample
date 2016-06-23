using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVCClient.Helper;

namespace MVCClient.Models
{
    public class UserInfoModel
    {
        private DateTime _date = DateTime.Now;

        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter the first name.")]        
        [ValidateForIllegalChars(@"!*.[]")]
        [StringLength(20)]
        public string FirstName { get; set; }

       
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter the last name.")]
        [ValidateForIllegalChars(@"!*.[]")]
        [StringLength(20)]
        public string LastName { get; set; }

       
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please enter the dob.")]       
        [DataType(DataType.Date)]
        [ValidateAge(18)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth
        {
            get { return _date; }
            set { _date = value; }
        }

    }


}