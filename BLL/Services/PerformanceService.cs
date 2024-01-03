using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class PerformanceService: IPerformanceService
    {
        private readonly IMapper mapper;
        private IPerformanceRepository performanceRepository;
        private IHoleServices holeRepository;


        public PerformanceService(IMapper mapper, IPerformanceRepository performanceRepository, IHoleServices holeRepository)
        {
            this.mapper = mapper;
            this.holeRepository = holeRepository;
            this.performanceRepository = performanceRepository;
        }

        public async Task<PerformanceResponse> AddPerformance(PerformanceRequest request)
        {
            var hole = await holeRepository.GetByIdAsync(request.HoleID);
            if (hole == null)
            {
                throw new Exception($"Hole with id {request.HoleID} not found");
            }


            var performance = mapper.Map<Performance>(request);
            await performanceRepository.AddAsync(performance);

            return mapper.Map<PerformanceResponse>(performance);
        }

        public async Task<List<PerformanceResponse>> GetAllPerformances()
        {
            var performances = await performanceRepository.GetAllAsync();

            return mapper.Map<List<PerformanceResponse>>(performances);
        }

        public async Task<List<PerformanceResponse>> GetPerformancesByAuthor(PerformancesByAuthorRequest request)
        {
            var performances = await performanceRepository.GetPerformancesByAuthor(request.AuthorName);
            if (performances.Count == 0)
            {
                throw new Exception($"Performances with author '{request.AuthorName}' not found");
            }

            return mapper.Map<List<PerformanceResponse>>(performances);
        }

        public async Task<List<PerformanceResponse>> GetPerformancesByHole(PerformanceByHoleRequest request)
        {
            var performances = await performanceRepository.GetPerformancesByHole(request.HoleID);
            if (performances.Count == 0)
            {
                throw new Exception($"Performances with hole id {request.HoleID} not found");
            }

            return mapper.Map<List<PerformanceResponse>>(performances);
        }

        public async Task<List<PerformanceResponse>> GetPerformancesByName(PerformancesByNameRequest request)
        {
            var performances = await performanceRepository.GetPerformancesByName(request.Name);
            if (performances.Count == 0)
            {
                throw new Exception($"Performances with name {request.Name} not found");
            }

            return mapper.Map<List<PerformanceResponse>>(performances);
        }

        public async Task<List<PerformanceResponse>> GetPerformancesByRate(PerformanceByRateRequest request)
        {
            var performances = await performanceRepository.GetPerformancesByRate(request.Rate);
            if (performances.Count == 0)
            {
                throw new Exception($"Performances with rate {request.Rate} not found");
            }

            return mapper.Map<List<PerformanceResponse>>(performances);
        }
    }
}
