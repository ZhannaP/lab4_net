using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface ICheckoutRepository : IGenericRepository<Checkout>
    {
        Task<List<Checkout>> GetTicketsByStatus(int PerformanceID, int StatusID);
        Task<List<Checkout>> GetCheckouts(int PerformanceID);
    }
}
