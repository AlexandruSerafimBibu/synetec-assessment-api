using SynetecAssessmentApi.Dtos;
using System;
using System.Threading.Tasks;
using SynetecAssessmentApi.Utils;

namespace SynetecAssessmentApi.Services
{

	public interface IBonusPoolService
    {
        Task<BonusPoolCalculatorResultDto> CalculateBonusForEmployeeAsync(decimal bonusPoolAmount, int selectedEmployeeId);
    }

    public class BonusPoolService : IBonusPoolService
    {
		private readonly IEmployeeService _employeeService;

		public BonusPoolService(IEmployeeService employeeService)
		{
			_employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
		}

		public async Task<BonusPoolCalculatorResultDto> CalculateBonusForEmployeeAsync(decimal bonusPoolAmount, int selectedEmployeeId)
		{
			//load the details of the selected employee using the Id
			EmployeeDto employee = await _employeeService.GetAsync(selectedEmployeeId);

			return new BonusPoolCalculatorResultDto
			{
				Employee = employee,
				Amount = BonusCalculator.CalculateBonusAllocationAmount(bonusPoolAmount, employee.Salary, await _employeeService.CalculateTotalSalary())
			};
		}
	}
}
