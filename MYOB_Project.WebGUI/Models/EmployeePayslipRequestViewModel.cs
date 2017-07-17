using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace MYOB_Project.WebGUI.Models
{
    public class EmployeePayslipRequestViewModel
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }

        [DisplayName("Annual Income")]
        [Required(ErrorMessage = "Please enter Annual Income")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter positive integer value for Annual Income")]
        public decimal AnnualIncome { get; set; }

        [DisplayName("Super Rate")]
        [Required(ErrorMessage = "Please enter Super Rate")]
        [Range(0, 50, ErrorMessage = "Please enter Super Rate between 0 and 50")]
        public decimal SuperRate { get; set; }

        [Required(ErrorMessage = "Please enter Month")]
        [Range(1, 12, ErrorMessage = "Please enter Month between 1 and 12")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Please enter Year")]
        public int Year { get; set; }
    }
}