﻿using AutoMapper;

using BLL.Requests;
using BLL.Responses;

using DAL.Repositories.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMapper mapper;
        private IPerformanceRepository performanceRepository;
        private ITicketRepository ticketRepository;

        public TicketService(IMapper mapper, IPerformanceRepository performanceRepository, ITicketRepository ticketRepository)
        {
            this.mapper = mapper;
            this.ticketRepository = ticketRepository;
            this.performanceRepository = performanceRepository;
        }

        public async Task<List<TicketResponse>> GetCheckouts()
        {

            var tickets = await ticketRepository.GetAllAsync();

            return mapper.Map<List<TicketResponse>>(tickets);

        }

        public async Task<List<TicketResponse>> GetTicketsByPerformance(TicketRequest request)
        {
            var tickets = await ticketRepository.GetAllAsync();

            return mapper.Map<List<TicketResponse>>(tickets);
        }

        public async Task<List<TicketResponse>> GetBoughtSeats(TicketRequest request)
        {
            var tickets = await ticketRepository.GetBoughtSeats(request.PerformanceId);
            return mapper.Map<List<TicketResponse>>(tickets);
        }

        public async Task<List<TicketResponse>> GetTicketsBySeatNumber(TicketRequest request)
        {
            var tickets = await ticketRepository.GetBoughtSeats(request.PerformanceId);
            return mapper.Map<List<TicketResponse>>(tickets);
        }
    }
}
