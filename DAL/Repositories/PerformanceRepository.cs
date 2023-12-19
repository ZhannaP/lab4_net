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
    public class PerformanceRepository : GenericRepository<Performance>, IPerformanceRepository
    {
        public PerformanceRepository(TheatreContext context) : base(context)
        {
        }

        public async Task<List<Performance>> GetPerformancesByName(string name)
        {
            List<Performance> performances = new();
            performances = await context.Performances.Where(p => p.Name == name).ToListAsync();
            return performances;
        }

        public async Task<List<Performance>> GetPerformancesByAuthor(string AuthorName)
        {
            List<Performance> performances = new();
            performances = await context.Performances.Where(p => p.Author == AuthorName).ToListAsync();
            return performances;
        }

        public async Task<List<Performance>> GetPerformancesByRate(int Rate)
        {
            List<Performance> performances = new();
            performances = await context.Performances.Where(p => p.Rate == Rate).ToListAsync();
            return performances;
        }

        public async Task<List<Performance>> GetPerformancesByHole(int HoleId)
        {
            List<Performance> performances = new();
            performances = await context.Performances.Where(p => p.HoleID.Id == HoleId).ToListAsync();
            return performances;
        }
    }
}
