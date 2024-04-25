using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserInputs
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public int TargetRetirementAge { get; set; } = 65;
        public int LifeExpectancy { get; set; } = 90;
        public double CurrentSavings { get; set; }
        public double MonthlyContribution { get; set; }
        public double AnnualReturnRate { get; set; }
        public double RetirementExpenseRate { get; set; }
    }
}
