using System.ComponentModel.DataAnnotations;

namespace CSharpMortgageMVC.Models
{
    public class Loan
    {
        public decimal LoanAmount { get; set; }

        public int TermMonths { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal InterestRate { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal Payment { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal TotalInterest { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal TotalCost { get; set; }

        public List<LoanPayment> Payments { get; set; } = new List<LoanPayment>();



    }
}
