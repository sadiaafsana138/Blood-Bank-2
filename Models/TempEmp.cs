using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBank.Models
{
    public class TempEmp
    {

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string EmpId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string EmpPass { get; set; }
    }
}