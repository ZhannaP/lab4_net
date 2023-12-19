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
    public class HoleRepository : GenericRepository<Hall>, IHoleRepository
    {
        public HoleRepository(TheatreContext context) : base(context)
        {
        }

        public async Task<List<Hall>> GetHoleByID(int HoleId)
        {
            List<Hall> halls = new();
            halls = await context.Holes.Where(p => p.Id == HoleId).ToListAsync();
            return halls;
        }

        public async Task<List<Hall>> GetHoleByTheatreId(int TheatreId)
        {
            List<Hall> halls = new();
            halls = await context.Holes.Where(p => p.TheatreID.Id == TheatreId).ToListAsync();
            return halls;
        }
    }
}
