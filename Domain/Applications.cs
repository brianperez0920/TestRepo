using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public partial class Applications
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double AnnualIncome { get; set; }
        public double MonthlyDebt { get; set; }
    }
}
