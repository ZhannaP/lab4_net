using BLL.Requests;
using BLL.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab4_net.Controllers
{
    public class HoleController : Controller
    {
        private readonly IHoleService holeService;

        public HoleController(IHoleService holeService)
        {
            this.holeService = holeService;
        }

        [HttpGet("GetAllHalls")]
        public async Task<IActionResult> GetAllHalls()
        {
            var result = await holeService.GetAllHoles();

            return Ok(result);
        }

        [HttpPost("GetByHallTheatreId")]
        public async Task<IActionResult> GetHallByTheatreId(int TheatreId)
        {
            HoleByTheatreRequest request = new();
            request.TheatreId = TheatreId;
            var result = await holeService.GetHoleByTheatreId(request);
            return Ok(result);
        }
    }
}
