using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
	[Route("api/[controller]")]
	public class EmployeeController : Controller
	{
		private readonly IEmployeeService _employeeService;

		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
		}

		[HttpGet]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Get()
		{
			try
			{
				return Ok(await _employeeService.GetAsync());
			}
			catch (Exception e)
			{
				return BadRequest($"Something went wrong. {e.Message}. Inner exception: {e.InnerException}");
			}
		}
	}
}
