using AutoMapper;
using NUnit.Framework;
using SynetecAssessment.Api.Services.Mapper;
using SynetecAssessment.Persistence;
using SynetecAssessment.UnitTesting;
using SynetecAssessmentApi.Services;

namespace SynetecAssessmentApi.Test
{
    [TestFixture]
    public class BonusPoolServiceTests
    {

        BonusPoolService _bonusPoolService;

        [OneTimeSetUp]
        public void Setup()
        {
            AppDbContext mockDBContext = MockDBContext.GetMockDBContext("BonusPoolTests");
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            _bonusPoolService = new BonusPoolService(new EmployeeService(mockDBContext, mapper));
        }

        [Test]
        public void CalculateBonusForEmployeeAsync_Ok()
        {
            var result = _bonusPoolService.CalculateBonusForEmployeeAsync(5555, 1);

            Assert.AreEqual("Employee no. 1", result.Result.Employee.Fullname);
            Assert.AreEqual("Job 1", result.Result.Employee.JobTitle);
            Assert.AreEqual(3500, result.Result.Employee.Salary);
            Assert.AreEqual("Dept. no. 1", result.Result.Employee.Department.Title);
            Assert.AreEqual("Description 1", result.Result.Employee.Department.Description);
            Assert.AreEqual(2514.22M, result.Result.Amount);
        }

        [Test]
        public void CalculateBonusForEmployeeAsync_No_EmployeeId()
        {
            var result = _bonusPoolService.CalculateBonusForEmployeeAsync(10000, 0);

            Assert.AreEqual("Employee with Id 0 does not exist.", result.Exception.InnerException.Message);
        }

        [Test]
        public void CalculateAsync_Invalid_EmployeeId()
        {
            var result = _bonusPoolService.CalculateBonusForEmployeeAsync(10000, -1);

            Assert.AreEqual("Employee with Id -1 does not exist.", result.Exception.InnerException.Message);
        }
    }
}