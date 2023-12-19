using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CheckoutRepository : GenericRepository<Checkout>, ICheckoutRepository
    {
        public CheckoutRepository(TheatreContext context) : base(context)
        {
        }

        public async Task<List<Checkout>> GetAllTickets(int PerformanceID)
        {
            var tickets = await context.Checkouts.Where(x => x.PerformanceID == PerformanceID).ToListAsync();
            return tickets;
        }

        public async Task<List<Checkout>> GetTicketsByStatus(int PerformanceID, int StatusID)
        {
            var tickets = await context.Checkouts.Where(x => x.PerformanceID == PerformanceID && x.TicketStatusId == StatusID).ToListAsync();
            return tickets;
        }
    }
}
