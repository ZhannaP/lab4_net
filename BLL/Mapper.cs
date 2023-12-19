using AutoMapper;

using BLL.Requests;
using BLL.Responses;

using DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<Performance, PerformanceResponse>().ForMember(dest => dest.PerformanceID, opt => opt.MapFrom(scr => scr.Id));

            CreateMap<PerformanceRequest, Performance>();
        }
        
    }
}
