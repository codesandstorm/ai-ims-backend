using AIIMS.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIIMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        public AnalyticsController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        // GET: api/analytics/deadstock/90
        [HttpGet("deadstock/{days}")]
        [Authorize]
        public async Task<IActionResult> GetDeadStock(int days)
        {
            var result = await _analyticsService.GetDeadStockItems(days);
            return Ok(result);
        }

        // GET: api/analytics/low-stock
        [HttpGet("low-stock")]
        [Authorize]
        public async Task<IActionResult> GetLowStock()
        {
            var result = await _analyticsService.GetLowStockItems();
            return Ok(result);
        }

        // POST: api/analytics/generate-reorder
        [HttpPost("generate-reorder")]
        [Authorize]
        public async Task<IActionResult> GenerateReorder()
        {
            await _analyticsService.GenerateReorderSuggestions();
            return Ok("Reorder suggestions generated successfully.");
        }
    }
} 