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
    public class HoleRepository : GenericRepository<Hole>, IHoleRepository
    {
        public HoleRepository(TheatreContext context) : base(context)
        {
        }

        public Task<List<Hole>> GetHoleByID(int HoleID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Hole>> GetHoleByName(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
