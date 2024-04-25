using Data;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Calculations
{
    public static class PredictedAgeCalculator
    {
        // Hardcoded for now, but will be replaced with a more dynamic solution
        private static double _suggestedWithdrawalRate = 0.0545;

        public static int GetPredictedRetirementAge(UserInputs userInputs)
        {
            var birthDate = userInputs.BirthDate;
            var currentInvestmentValue = userInputs.CurrentSavings;
            var monthlyContribution = userInputs.MonthlyContribution;
            var annualReturnRate = userInputs.AnnualReturnRate;
            var retirementExpenseRate = userInputs.RetirementExpenseRate;

            var fiNumber = GetFiNumber(retirementExpenseRate);
            var yearsUntilRetirement = GetYearsUntilRetirement(annualReturnRate, monthlyContribution, currentInvestmentValue, fiNumber);
            var predictedRetirementAge = GetRoundedAge(birthDate) + yearsUntilRetirement;

            return predictedRetirementAge;
        }

        private static int GetYearsUntilRetirement(double annualReturnRate, double monthlyContribution, double currentInvestmentValue, double fiNumber)
        {
            var monthsUntilRetirement = Financial.NPer(annualReturnRate / 12, -monthlyContribution, -currentInvestmentValue, fiNumber);
            return (int)Math.Ceiling(monthsUntilRetirement / 12);
        }

        private static double GetFiNumber(double retirementExpenseRate)
        {
            return retirementExpenseRate / _suggestedWithdrawalRate;
        }

        private static int GetRoundedAge(DateTime birthDate)
        {
            var currentDate = DateTime.Now;
            var age = currentDate.Year - birthDate.Year;
            return age;
        }
    }
}
