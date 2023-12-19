using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal interface ITicketService
    {
        Task<List<TicketResponse>> GetAllTickets();
        Task<List<TicketResponse>> GetTicketsBySeatNumber(PerformancesByAuthorRequest request);
        Task<List<TicketResponse>> GetTicketsByPerformance(PerformanceByHoleRequest request);
    }
}
