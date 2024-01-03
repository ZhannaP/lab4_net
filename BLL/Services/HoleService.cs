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
    public class HoleService : IHoleService
    {
        private readonly IMapper mapper;
        private IHoleServices holeRepository;
        private IHoleServices object1;
        private IMapper object2;

        public HoleService(IMapper mapper, IHoleServices holeRepository)
        {
            this.mapper = mapper;
            this.holeRepository = holeRepository;
        }

        public HoleService(IHoleServices object1, IMapper object2)
        {
            this.object1 = object1;
            this.object2 = object2;
        }

        public async Task<List<HoleResponse>> GetAllHoles()
        {
            var holes = await holeRepository.GetAllAsync();
            return mapper.Map<List<HoleResponse>>(holes);
        }

        public async Task<List<HoleResponse>> GetHoleByTheatreId(HoleByTheatreRequest request)
        {
            var holes = await holeRepository.GetHoleByTheatreId(request.TheatreId);
            return mapper.Map<List<HoleResponse>>(holes);
        }
    }
}
