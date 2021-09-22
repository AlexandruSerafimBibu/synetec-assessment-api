using AutoMapper;
using NUnit.Framework;
using SynetecAssessment.Api.Services.Mapper;
using SynetecAssessment.Persistence;
using SynetecAssessment.UnitTesting;
using SynetecAssessmentApi.Services;
using System.Linq;

namespace SynetecAssessmentApi.Test
{
	[TestFixture]
    public class EmployeeServiceTest
    {

        EmployeeService _employeeService;

        [OneTimeSetUp]
        public void Setup()
        {
            AppDbContext mockDBContext = MockDBContext.GetMockDBContext("EmployeeTests");
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            _employeeService = new EmployeeService(mockDBContext, mapper);
        }

        [Test]
        public void GetAsync_All()
        {
            var result = _employeeService.GetAsync();

            Assert.AreEqual(3, result.Result.Count());
        }

        [Test]
        public void GetAsync_ById()
        {
            var result = _employeeService.GetAsync(1);

            Assert.AreEqual("Employee no. 1", result.Result.Fullname);
        }

        [Test]
        public void GetAsync_ById_Error()
        {
            var result = _employeeService.GetAsync(-1);

            Assert.AreEqual("Employee with Id -1 does not exist.", result.Exception.InnerException.Message);
        }
    }
}