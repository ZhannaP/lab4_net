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
    public class TheatreRepository : GenericRepository<Theatre>, ITheatreRepository
    {
        public TheatreRepository(TheatreContext context) : base(context)
        {
        }

        public async Task<List<Theatre>> GetTheatreByName(string Name)
        {
            List<Theatre> performances = new();
            performances = await context.Theatres.Where(p => p.Name == Name).ToListAsync();
            return performances;
        }
    }
}
