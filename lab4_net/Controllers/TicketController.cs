﻿using BLL.Requests;
using BLL.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab4_net.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService ticketService;

        [HttpGet("GetAllTickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            var result = await ticketService.GetAllTickets();

            return Ok(result);
        }

        [HttpPost("GetTicketsByPerformanceId")]
        public async Task<IActionResult> GetTicketsByPerformance(int performanceId)
        {
            TicketRequest request = new();
            request.PerformanceId = performanceId;
            var result = await ticketService.GetTicketsByPerformance(request);
            return Ok(result);
        }

        [HttpPost("GetBoughtSeats")]
        public async Task<IActionResult> GetBoughtSeats()
        {
            TicketRequest request = new();
            var result = await ticketService.GetBoughtSeats(request);
            return Ok(result);
        }
    }
}
