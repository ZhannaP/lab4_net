using AutoMapper;

using BLL.Requests;
using BLL.Responses;
using BLL.Services;

using DAL.Entities;
using DAL.Repositories.Interfaces;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace ThatreTests.BLL_Tests
{
    public class HoleServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IHoleServices> _holeRepositoryMock;
        private readonly HoleService _holeService;

        public HoleServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _holeRepositoryMock = new Mock<IHoleServices>();
            _holeService = new HoleService(_mapperMock.Object, _holeRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllHoles_ShouldReturnMappedHoles()
        {
            // Arrange
            var holes = new List<Hall>() {
            new Hall { Id = 1, Name = "meow", NumberOfSeats = 20},
            new Hall { Id = 2, Name = "meow2", NumberOfSeats = 30}};
            _holeRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(holes);
            _mapperMock.Setup(mapper => mapper.Map<List<HoleResponse>>(It.IsAny<List<Hall>>())).Returns(new List<HoleResponse>());

            // Act
            var result = await _holeService.GetAllHoles();

            // Assert
            _holeRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<HoleResponse>>(holes), Times.Once);
        }

        [Fact]
        public async Task GetHoleByTheatreId_ShouldReturnMappedHoles()
        {
            // Arrange
            var request = new HoleByTheatreRequest { TheatreId = 1 }; 
            var holes = new List<Hall>() {
            new Hall { Id = 1, Name = "meow", NumberOfSeats = 20},
            new Hall { Id = 2, Name = "meow2", NumberOfSeats = 30}}; 
            _holeRepositoryMock.Setup(repo => repo.GetHoleByTheatreId(request.TheatreId)).ReturnsAsync(holes);
            _mapperMock.Setup(mapper => mapper.Map<List<HoleResponse>>(It.IsAny<List<Hall>>())).Returns(new List<HoleResponse>());

            // Act
            var result = await _holeService.GetHoleByTheatreId(request);

            // Assert
            _holeRepositoryMock.Verify(repo => repo.GetHoleByTheatreId(request.TheatreId), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<HoleResponse>>(holes), Times.Once);
        }
    }
}
