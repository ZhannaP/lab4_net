using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ITicketService
    {
        Task<List<TicketResponse>> GetAllTickets();
        Task<List<TicketResponse>> GetTicketsBySeatNumber(TicketRequest request);
        Task<List<TicketResponse>> GetTicketsByPerformance(TicketRequest request);
        Task<List<TicketResponse>>  GetBoughtSeats(TicketRequest request);
    }
}
