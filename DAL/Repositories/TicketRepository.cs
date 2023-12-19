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
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(TheatreContext context) : base(context)
        {
        }



        public async Task<List<Ticket>> GetBoughtSeats(int performanceId)
        {
            var boughtSeats = await context.Tickets.Where(x => x.PerformaceId == performanceId).ToListAsync();
            return boughtSeats;
        }

    }
}
