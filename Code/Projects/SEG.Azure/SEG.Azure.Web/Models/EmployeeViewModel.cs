using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SEG.Azure.Web.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter First Name")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        [DisplayName("Last Name")]
        public string LName { get; set; }

        [DisplayName("Age")]
        public byte Age { get; set; }

        [DisplayName("DOB")]
        [Required(ErrorMessage = "Please enter DOB")]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        [DisplayName("Active")]
        public bool IsActive { get; set; }
    }
}