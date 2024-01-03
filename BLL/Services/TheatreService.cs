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
    public class TheatreService : ITheatreService
    {
        IMapper mapper;
        ITheatreRepository repository;
        public TheatreService(IMapper mapper, ITheatreRepository theatreRepository) 
        { 
            this.mapper = mapper; 
            this.repository = theatreRepository;
        }

        public async Task<List<TheatreResponse>> GetAllTheatres()
        {
            var theatres = await repository.GetAllAsync();
            return mapper.Map<List<TheatreResponse>>(theatres);
        }

        public async Task<List<TheatreResponse>> GetTheatreById(TheatreRequest request)
        {
            var theatres = await repository.GetByIdAsync(request.TheatreID);
            return mapper.Map<List<TheatreResponse>>(theatres);
        }

        public async Task<List<TheatreResponse>> GetTheatreByName(TheatreRequest request)
        {
            var theatres = await repository.GetTheatreByName(request.Name);
            return mapper.Map<List<TheatreResponse>>(theatres);
        }
    }
}
