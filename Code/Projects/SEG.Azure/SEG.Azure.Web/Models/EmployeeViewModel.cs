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

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        public string LName { get; set; }

        [DisplayName("Age")]
        public byte Age { get; set; }

        [DisplayName("DOB")]
        [Required(ErrorMessage = "Please enter Date Of Birth")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Datetime")]
        [DisplayFormat(ApplyFormatInEditMode = true, 
            ConvertEmptyStringToNull = true, 
            DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        [DisplayName("Active")]
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}