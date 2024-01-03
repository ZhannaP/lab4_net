using AutoMapper;

using BLL.Requests;
using BLL.Responses;
using BLL.Services;

using DAL.Entities;
using DAL.Repositories.Interfaces;

using Moq;

using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

namespace ThatreTests.BLL_Tests
{
    public class TheatreServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITheatreRepository> _theatreRepositoryMock;
        private readonly TheatreService _theatreService;

        public TheatreServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _theatreRepositoryMock = new Mock<ITheatreRepository>();
            _theatreService = new TheatreService(_mapperMock.Object, _theatreRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllTheatres_ShouldReturnMappedTheatres()
        {
            // Arrange
            var theatres = new List<Theatre>() { new Theatre { Id = 1, Name = "meow", Address = "meow", Phone = "0000000"} };
            _theatreRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(theatres);
            _mapperMock.Setup(mapper => mapper.Map<List<TheatreResponse>>(It.IsAny<List<Theatre>>())).Returns(new List<TheatreResponse>());

            // Act
            var result = await _theatreService.GetAllTheatres();

            // Assert
            _theatreRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<TheatreResponse>>(theatres), Times.Once);
        }

        //[Fact]
        //public async Task GetTheatreByName_ShouldReturnMappedTheatres()
        //{
        //    // Arrange
        //    var request = new TheatreRequest { TheatreID = 1, Name = "Meow" };
        //    var theatres = new List<Theatre>() { new Theatre { TheatreID = 1, Name = "Meow", Address = "meow", Phone = "0000000" } };
        //    _theatreRepositoryMock.Setup(repo => repo.GetTheatreByName(request.Name)).ReturnsAsync(theatres);
        //    _mapperMock.Setup(mapper => mapper.Map<List<TheatreResponse>>(It.IsAny<List<Theatre>>())).Returns(new List<TheatreResponse>());

        //    // Act
        //    var result = await _theatreService.GetTheatreByName(request);

        //    // Assert
        //    _theatreRepositoryMock.Verify(repo => repo.GetByIdAsync(request.TheatreID), Times.Once);
        //    _mapperMock.Verify(mapper => mapper.Map<List<TheatreResponse>>(theatres), Times.Once);
        //}
    }
}
