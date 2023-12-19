using DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface ICheckoutRepository : IGenericRepository<Checkout>
    {
        Task<List<Checkout>> GetTicketsByStatus(int PerformanceID, int StatusID);
        Task<List<Checkout>> GetAllTickets(int PerformanceID);
    }
}
