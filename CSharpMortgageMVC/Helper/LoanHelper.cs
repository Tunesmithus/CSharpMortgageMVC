using CSharpMortgageMVC.Models;

namespace CSharpMortgageMVC.Helper
{
    public  class LoanHelper
    {
        public Loan GetPayments(Loan loan)
        {
            //calculate monthly payment
            loan.Payment = CalcPayment(loan.LoanAmount, loan.InterestRate, loan.TermMonths);

            //create loop from 1 to the term
            var balance = loan.LoanAmount;
            var totalInterest = 0.0m;
            var monthlyInterest = 0.0m;
            var monthlyPrincipal = 0.0m;
            var monthlyRate = CalcMonthlyRate(loan.InterestRate);

            //loop over each month until we reach the term of the loan
            for (int month = 1; month <= loan.TermMonths; month++)
            {
                monthlyInterest = CalcMonthlyInterest(balance, monthlyRate);
                totalInterest += monthlyInterest;
                monthlyPrincipal = loan.Payment - monthlyInterest;
                balance -= monthlyPrincipal;

                LoanPayment loanPayment = new()
                {
                    Month = month,
                    Payment = loan.Payment,
                    MonthlyPrincipal = monthlyPrincipal,
                    MonthlyInterest = monthlyInterest,
                    TotalInterest = totalInterest,
                    Balance = balance
                };

                //Push payment into the loan model
                loan.Payments.Add(loanPayment);
            };

            loan.TotalInterest = totalInterest;
            loan.TotalCost = loan.LoanAmount + totalInterest;

            return loan;
        }


        private decimal CalcPayment(decimal amount, decimal rate, int term)
        {

            decimal monthlyRate = CalcMonthlyRate(rate);

            var rateD = Convert.ToDouble(monthlyRate);
            var amountD = Convert.ToDouble(amount);

            var paymentD = (amountD * rateD) / (1 - Math.Pow(1 + rateD, -term));

            return Convert.ToDecimal(paymentD);
        }

        private decimal CalcMonthlyRate(decimal rate)
        {
            return rate / 1200;
        }

        private decimal CalcMonthlyInterest(decimal balance, decimal monthlyRate)
        {
            return balance * monthlyRate;
        }


    }
}
