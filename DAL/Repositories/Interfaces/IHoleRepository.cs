using DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IHoleRepository : IGenericRepository<Hole>
    {
        Task<List<Hole>> GetHoleByID(int HoleID);
        Task<List<Hole>> GetHoleByName(string Name);
    }
}
