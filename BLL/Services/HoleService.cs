using AutoMapper;

using BLL.Requests;
using BLL.Responses;

using DAL.Repositories;
using DAL.Repositories.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class HoleService : IHoleService
    {
        private readonly IMapper mapper;
        private IHoleRepository holeRepository;

        public HoleService(IMapper mapper, IHoleRepository holeRepository)
        {
            this.mapper = mapper;
            this.holeRepository = holeRepository;
        }

        public async Task<List<HoleResponse>> GetAllHoles()
        {
            var holes = await holeRepository.GetAllAsync();
            return mapper.Map<List<HoleResponse>>(holes);
        }

        public async Task<List<HoleResponse>> GetHoleByTheatreId(HoleByTheatreRequest request)
        {
            var holes = await holeRepository.GetHoleByTheateId(request.TheatreId);
            return mapper.Map<List<HoleResponse>>(holes);
        }
    }
}
