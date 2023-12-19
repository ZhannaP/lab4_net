using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IPerformanceService
    {
        Task<List<PerformanceResponse>> GetAllPerformances();
        Task<List<PerformanceResponse>> GetPerformancesByAuthor(PerformancesByAuthorRequest request);
        Task<List<PerformanceResponse>> GetPerformancesByHole(PerformanceByHoleRequest request);
        Task<List<PerformanceResponse>> GetPerformancesByName(PerformancesByNameRequest request);
        Task<List<PerformanceResponse>> GetPerformancesByRate(PerformanceByRateRequest request);
        Task<PerformanceResponse> AddPerformance(PerformanceRequest request);
    }
}
