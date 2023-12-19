using BLL.Requests;
using BLL.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab4_net.Controllers
{
    public class TheatreController : Controller
    {
        private readonly ITheatreService theatreService;
        public TheatreController(ITheatreService theatreService)
        {
            this.theatreService = theatreService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTheatres()
        {
            var result = await theatreService.GetAllTheatres();

            return Ok(result);
        }

        [HttpPost("GetByTheatreId")]
        public async Task<IActionResult> GetHallByTheatre(TheatreRequest request)
        {
            var result = await theatreService.GetTheatreById(request);
            return Ok(result);
        }


    }
}
