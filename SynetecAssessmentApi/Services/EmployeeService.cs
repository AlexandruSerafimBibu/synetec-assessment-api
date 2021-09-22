using Microsoft.EntityFrameworkCore;
using SynetecAssessment.Domain;
using SynetecAssessmentApi.Dtos;
using SynetecAssessment.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace SynetecAssessmentApi.Services
{
	public interface IEmployeeService
	{
        Task<IEnumerable<EmployeeDto>> GetAsync();
        Task<EmployeeDto> GetAsync(int id);
        Task<decimal> CalculateTotalSalary();
    }
	public class EmployeeService : IEmployeeService
	{
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

		public EmployeeService(AppDbContext dbContext, IMapper autoMapper)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
			_mapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
		}

		/// <summary>
		/// Get all employees
		/// </summary>
		/// <returns>IEnumerable<EmployeeDto> of all employees</returns>
		public async Task<IEnumerable<EmployeeDto>> GetAsync()
        {
            return await _dbContext
                .Employees
                .Include(e => e.Department)
                .Select(e => _mapper.Map<EmployeeDto>(e)) 
                .ToListAsync();
        }

        /// <summary>
        /// Get Employee by Id
        /// </summary>
        /// <returns>An EmployeeDto</returns>
		public async Task<EmployeeDto> GetAsync(int id)
		{
            var dbEmployee = await _dbContext.Employees
                                            .Include(e => e.Department)
                                            .FirstOrDefaultAsync(e => e.Id == id);
            if(dbEmployee == null)
			{
                throw new Exception($"Employee with Id {id} does not exist.");
			}

            return _mapper.Map<EmployeeDto>(dbEmployee);
        }

        /// <summary>
		/// Get the total salary budget for the company
		/// </summary>
		/// <returns>the salary budget</returns>
        public async Task<decimal> CalculateTotalSalary()
		{
            return await _dbContext.Employees.SumAsync(item => item.Salary);
        }

    }
}
