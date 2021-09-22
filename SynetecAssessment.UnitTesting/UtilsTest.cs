using AutoMapper;
using NUnit.Framework;
using SynetecAssessment.Api.Services.Mapper;
using SynetecAssessment.Persistence;
using SynetecAssessment.UnitTesting;
using SynetecAssessmentApi.Services;
using SynetecAssessmentApi.Utils;

namespace SynetecAssessmentApi.Test
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void CalculateBonusForEmployeeAsync_Ok()
        {
            decimal result = BonusCalculator.CalculateBonusAllocationAmount(12.5M, 15, 60);

            Assert.AreEqual(3.12M, result);
        }
    }
}