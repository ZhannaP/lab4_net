using AutoMapper;
using BLL.Requests;
using BLL.Responses;

using BLL;
using BLL.Services;

using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DAL.Entities;

namespace ThatreTests.BLL_Tests
{
    public class TicketServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IPerformanceRepository> _performanceRepositoryMock;
        private readonly Mock<ITicketRepository> _ticketRepositoryMock;
        private readonly TicketService _ticketService;

        public TicketServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _performanceRepositoryMock = new Mock<IPerformanceRepository>();
            _ticketRepositoryMock = new Mock<ITicketRepository>();
            _ticketService = new TicketService(_mapperMock.Object, _performanceRepositoryMock.Object, _ticketRepositoryMock.Object);
        }

        [Fact]
        public async Task GetCheckouts_ShouldReturnMappedTickets()
        {
            // Arrange
            var tickets = new List<Ticket>() { new Ticket { LastName = "meow", FirstName = "meow", MiddleName = "meow", Id = 1,  PerformaceId = 1, Price = 100, SeatNumber = 1},
            new Ticket { LastName = "meow1", FirstName = "meow1", MiddleName = "meow1", Id = 2,  PerformaceId = 1, Price = 100, SeatNumber = 21}}; ;
            _ticketRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(tickets);
            _mapperMock.Setup(mapper => mapper.Map<List<TicketResponse>>(It.IsAny<List<Ticket>>())).Returns(new List<TicketResponse>());

            // Act
            var result = await _ticketService.GetCheckouts();

            // Assert
            _ticketRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<TicketResponse>>(tickets), Times.Once);
        }

        [Fact]
        public async Task GetTicketsByPerformance_ShouldReturnMappedTickets()
        {
            // Arrange
            var request = new TicketRequest();
            var tickets = new List<Ticket>()  { new Ticket { LastName = "meow", FirstName = "meow", MiddleName = "meow", Id = 1,  PerformaceId = 1, Price = 100, SeatNumber = 1},
            new Ticket { LastName = "meow1", FirstName = "meow1", MiddleName = "meow1", Id = 2,  PerformaceId = 1, Price = 100, SeatNumber = 21}}; ;
            _ticketRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(tickets);
            _mapperMock.Setup(mapper => mapper.Map<List<TicketResponse>>(It.IsAny<List<Ticket>>())).Returns(new List<TicketResponse>());

            // Act
            var result = await _ticketService.GetTicketsByPerformance(request);

            // Assert
            _ticketRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<TicketResponse>>(tickets), Times.Once);
        }

        [Fact]
        public async Task GetBoughtSeats_ShouldReturnMappedTickets()
        {
            // Arrange
            var request = new TicketRequest { PerformanceId = 1 };
            var tickets = new List<Ticket>()  { new Ticket { LastName = "meow", FirstName = "meow", MiddleName = "meow", Id = 1,  PerformaceId = 1, Price = 100, SeatNumber = 1},
            new Ticket { LastName = "meow1", FirstName = "meow1", MiddleName = "meow1", Id = 2,  PerformaceId = 1, Price = 100, SeatNumber = 21}}; ;
            _ticketRepositoryMock.Setup(repo => repo.GetBoughtSeats(request.PerformanceId)).ReturnsAsync(tickets);
            _mapperMock.Setup(mapper => mapper.Map<List<TicketResponse>>(It.IsAny<List<Ticket>>())).Returns(new List<TicketResponse>());

            // Act
            var result = await _ticketService.GetBoughtSeats(request);

            // Assert
            _ticketRepositoryMock.Verify(repo => repo.GetBoughtSeats(request.PerformanceId), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<TicketResponse>>(tickets), Times.Once);
        }

        [Fact]
        public async Task GetTicketsBySeatNumber_ShouldReturnMappedTickets()
        {
            // Arrange
            var request = new TicketRequest { PerformanceId = 1 };
            var tickets = new List<Ticket>() { new Ticket { LastName = "meow", FirstName = "meow", MiddleName = "meow", Id = 1,  PerformaceId = 1, Price = 100, SeatNumber = 1},
            new Ticket { LastName = "meow1", FirstName = "meow1", MiddleName = "meow1", Id = 2,  PerformaceId = 1, Price = 100, SeatNumber = 21}};
            _ticketRepositoryMock.Setup(repo => repo.GetBoughtSeats(request.PerformanceId)).ReturnsAsync(tickets);
            _mapperMock.Setup(mapper => mapper.Map<List<TicketResponse>>(It.IsAny<List<Ticket>>())).Returns(new List<TicketResponse>());

            // Act
            var result = await _ticketService.GetTicketsBySeatNumber(request);

            // Assert
            _ticketRepositoryMock.Verify(repo => repo.GetBoughtSeats(request.PerformanceId), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<TicketResponse>>(tickets), Times.Once);
        }
    }
}
