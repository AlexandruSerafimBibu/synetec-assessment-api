using Microsoft.EntityFrameworkCore;
using SynetecAssessment.Persistence;
using SynetecAssessment.Domain;

namespace SynetecAssessment.UnitTesting
{
	public static class MockDBContext
	{
		public static AppDbContext GetMockDBContext(string dbName)
		{

			var options = new DbContextOptionsBuilder<AppDbContext>()
			  .UseInMemoryDatabase(databaseName: dbName)
			  .Options;

			var context = new AppDbContext(options);

			context.Departments.Add(new Department(1, "Dept. no. 1", "Description 1"));
			context.Departments.Add(new Department(2, "Dept. no. 2", "Description 2"));

			context.Employees.Add(new Employee(1, "Employee no. 1", "Job 1", 3500, 1));
			context.Employees.Add(new Employee(2, "Employee no. 2", "Job 2", 2999, 2));
			context.Employees.Add(new Employee(3, "Employee no. 3", "Job 3", 1234, 2));

			context.SaveChanges();

			return context;
		}
	}
}