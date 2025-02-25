using CashFlow.Application.Reports;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.WebReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IDailyConsolidatedReportService dailyConsolidatedReportService;

        public ReportController(IDailyConsolidatedReportService dailyConsolidatedReportService)
        {
            this.dailyConsolidatedReportService = dailyConsolidatedReportService;
        }

        [HttpGet("daily-Consolidated-report/{filterDate}")]
        public async Task<IActionResult> DailyConsolidatedReport(DateTime filterDate)
        {
            try
            {
                var report = await dailyConsolidatedReportService.GenerateReport(filterDate);

                return Ok(report);
            }
            catch (Exception ex)
            {               
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
