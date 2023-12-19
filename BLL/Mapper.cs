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

            CreateMap<Ticket, TicketResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(scr => scr.Id));

            CreateMap<HoleRequest, HoleResponse>().ForMember(dest => dest.HoleId, opt => opt.MapFrom(scr => scr.HoleId));

            CreateMap<TheatreRequest, TheatreResponse>().ForMember(dest => dest.TheatreID, opt => opt.MapFrom(scr => scr.TheatreID));
        }
        
    }
}
