using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TicketRepository : GenericRepository<Performance>//, ITicketRepository
    {
        public TicketRepository(TheatreContext context) : base(context)
        {
        }

        public Task<List<Ticket>> GetBoughtSeats(int performanceId)
        {
            throw new NotImplementedException();
        }

    }
}
