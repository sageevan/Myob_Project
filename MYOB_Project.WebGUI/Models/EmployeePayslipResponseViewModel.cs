using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MYOB_Project.WebGUI.Models
{
    public class EmployeePayslipResponseViewModel
    {
        [DisplayName("Name")]
        public string FullName { get; set; }

        [DisplayName("Pay Period")]
        public string PayPeriod { get; set; }

        [DisplayName("Gross Income")]
        [DisplayFormat(DataFormatString = "${0:#,0}")]
        public decimal GrossIncome { get; set; }

        [DisplayName("Income Tax")]
        [DisplayFormat(DataFormatString = "${0:#,0}")]
        public decimal IncomeTax { get; set; }

        [DisplayName("Net Income")]
        [DisplayFormat(DataFormatString = "${0:#,0}")]
        public decimal NetIncome { get; set; }

        [DisplayFormat(DataFormatString = "${0:#,0}")]
        public decimal Super { get; set; }
    }
}