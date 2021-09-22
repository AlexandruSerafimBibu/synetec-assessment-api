using System;

namespace SynetecAssessmentApi.Utils
{
	/// <summary>
	/// Class which implements the bonus calculation
	/// </summary>
	public static class BonusCalculator
	{
		/// <summary>
		/// Calculate the bonus allocation for the employee
		/// </summary>
		/// <returns>the bonus</returns>
		public static decimal CalculateBonusAllocationAmount(decimal bonusPoolAmount, decimal employeeSalary, decimal totalSalary)
		{
			// "employeeSalary / totalSalary" is the %
			return Decimal.Round(employeeSalary / totalSalary * bonusPoolAmount, 2);
		}
	}
}
