using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class BonusPoolController : Controller
    {
        private readonly IBonusPoolService _bonusPoolService;
        
		public BonusPoolController(IBonusPoolService bonusPoolService)
		{
			_bonusPoolService = bonusPoolService ?? throw new ArgumentNullException(nameof(bonusPoolService));
		}
		
        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CalculateBonusForEmployee([FromBody] CalculateBonusDto request)
		{
			try
			{
                BonusPoolCalculatorResultDto bonusPoolCalculatorResult = await _bonusPoolService.CalculateBonusForEmployeeAsync(
                request.TotalBonusPoolAmount,
                request.SelectedEmployeeId);
                if (bonusPoolCalculatorResult == null)
                {
                    throw new Exception($"SelectedEmployeeId is not specified or employee with Id {request.SelectedEmployeeId} does not exist.");
                }

                return Ok(bonusPoolCalculatorResult);
            }
            catch(Exception e)
			{
                return BadRequest($"Something went wrong. {e.Message}. Inner exception: {e.InnerException}");
			}
        }
    }
}
