using BLL.Requests;
using BLL.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab4_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : Controller
    {
        private readonly IPerformanceService performanceService;

        public PerformanceController(IPerformanceService performanceService)
        {
            this.performanceService = performanceService;
        }

        [HttpPost("GetByRate")]
        public async Task<IActionResult> GetPerformancesByRate(int Rate)
        {
            PerformanceByRateRequest request = new();
            request.Rate = Rate;

            var result = await performanceService.GetPerformancesByRate(request);

            return Ok(result);
        }

        [HttpPost("GetByAuthor")]
        public async Task<IActionResult> GetPerformancesByAuthor(PerformancesByAuthorRequest request)
        {
            var result = await performanceService.GetPerformancesByAuthor(request);

            return Ok(result);
        }

        [HttpPost("GetByHole")]
        public async Task<IActionResult> GetPerformancesByHole(PerformanceByHoleRequest request)
        {
            var result = await performanceService.GetPerformancesByHole(request);

            return Ok(result);
        }

        [HttpPost("GetByName")]
        public async Task<IActionResult> GetPerformancesByName(PerformancesByNameRequest request)
        {
            var result = await performanceService.GetPerformancesByName(request);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPerformances()
        {
            var result = await performanceService.GetAllPerformances();
            return Ok(result);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddPerformances(PerformanceRequest request)
        {
            var result = await performanceService.AddPerformance(request);
            return Ok(result);
        }

    }
}

