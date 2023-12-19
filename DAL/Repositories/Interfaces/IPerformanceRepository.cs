using DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IPerformanceRepository : IGenericRepository<Performance>
    {
        Task<List<Performance>> GetPerformancesByAuthor(string AuthorName);
        Task<List<Performance>> GetPerformancesByRate(int Rate);
        Task<List<Performance>> GetPerformancesByName(string Name);
        Task<List<Performance>> GetPerformancesByHole(int HoleId);
    }
}
