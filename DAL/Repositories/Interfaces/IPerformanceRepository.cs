using DAL.Entities;

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
