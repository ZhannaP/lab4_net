using AutoMapper;

using BLL.Requests;
using BLL.Responses;
using BLL.Services;

using DAL.Entities;
using DAL.Repositories.Interfaces;

using Moq;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

namespace ThatreTests.BLL_Tests
{
    public class PerformanceServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IPerformanceRepository> _performanceRepositoryMock;
        private readonly Mock<IHoleServices> _holeRepositoryMock;
        private readonly PerformanceService _performanceService;

        public PerformanceServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _performanceRepositoryMock = new Mock<IPerformanceRepository>();
            _holeRepositoryMock = new Mock<IHoleServices>();
            _performanceService = new PerformanceService(_mapperMock.Object, _performanceRepositoryMock.Object, _holeRepositoryMock.Object);
        }

        [Fact]
        public async Task AddPerformance_ShouldAddAndReturnMappedPerformance()
        {
            // Arrange
            var request = new PerformanceRequest
            {
                HoleID = 1,
                Name = "TestPerformance",
                AuthorName = "TestAuthor",
                Rate = 5,
            };

            var hole = new Hall { Id = 1 };
            _holeRepositoryMock.Setup(repo => repo.GetByIdAsync(request.HoleID)).ReturnsAsync(hole);

            var performance = new Performance();
            _mapperMock.Setup(mapper => mapper.Map<Performance>(request)).Returns(performance);

            // Act
            var result = await _performanceService.AddPerformance(request);

            // Assert
            _holeRepositoryMock.Verify(repo => repo.GetByIdAsync(request.HoleID), Times.Once);
            _performanceRepositoryMock.Verify(repo => repo.AddAsync(performance), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<PerformanceResponse>(performance), Times.Once);
            Xunit.Assert.Null(result);
        }

        [Fact]
        public async Task GetAllPerformances_ShouldReturnMappedPerformances()
        {
            // Arrange
            var performances = new List<Performance>();
            _performanceRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(performances);
            _mapperMock.Setup(mapper => mapper.Map<List<PerformanceResponse>>(performances)).Returns(new List<PerformanceResponse>());

            // Act
            var result = await _performanceService.GetAllPerformances();

            // Assert
            _performanceRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<PerformanceResponse>>(performances), Times.Once);
            Xunit.Assert.NotNull(result);
        }

        [Fact]
        public async Task GetPerformancesByAuthor_ShouldReturnMappedPerformances()
        {
            // Arrange
            var request = new PerformancesByAuthorRequest { AuthorName = "TestAuthor" };
            var performances = new List<Performance> { new Performance() };
            _performanceRepositoryMock.Setup(repo => repo.GetPerformancesByAuthor(request.AuthorName)).ReturnsAsync(performances);
            _mapperMock.Setup(mapper => mapper.Map<List<PerformanceResponse>>(performances)).Returns(new List<PerformanceResponse>());

            // Act
            var result = await _performanceService.GetPerformancesByAuthor(request);

            // Assert
            _performanceRepositoryMock.Verify(repo => repo.GetPerformancesByAuthor(request.AuthorName), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<PerformanceResponse>>(performances), Times.Once);
            Xunit.Assert.NotNull(result);
        }

        [Fact]
        public async Task GetPerformancesByHole_ShouldReturnMappedPerformances()
        {
            // Arrange
            var request = new PerformanceByHoleRequest { HoleID = 1 };
            var performances = new List<Performance> { new Performance() };
            _performanceRepositoryMock.Setup(repo => repo.GetPerformancesByHole(request.HoleID)).ReturnsAsync(performances);
            _mapperMock.Setup(mapper => mapper.Map<List<PerformanceResponse>>(performances)).Returns(new List<PerformanceResponse>());

            // Act
            var result = await _performanceService.GetPerformancesByHole(request);

            // Assert
            _performanceRepositoryMock.Verify(repo => repo.GetPerformancesByHole(request.HoleID), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<PerformanceResponse>>(performances), Times.Once);
            Xunit.Assert.NotNull(result);
        }

        [Fact]
        public async Task GetPerformancesByName_ShouldReturnMappedPerformances()
        {
            // Arrange
            var request = new PerformancesByNameRequest { Name = "TestPerformance" };
            var performances = new List<Performance> { new Performance() };
            _performanceRepositoryMock.Setup(repo => repo.GetPerformancesByName(request.Name)).ReturnsAsync(performances);
            _mapperMock.Setup(mapper => mapper.Map<List<PerformanceResponse>>(performances)).Returns(new List<PerformanceResponse>());

            // Act
            var result = await _performanceService.GetPerformancesByName(request);

            // Assert
            _performanceRepositoryMock.Verify(repo => repo.GetPerformancesByName(request.Name), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<PerformanceResponse>>(performances), Times.Once);
            Xunit.Assert.NotNull(result);
        }

        [Fact]
        public async Task GetPerformancesByRate_ShouldReturnMappedPerformances()
        {
            // Arrange
            var request = new PerformanceByRateRequest { Rate = 5 };
            var performances = new List<Performance> { new Performance() };
            _performanceRepositoryMock.Setup(repo => repo.GetPerformancesByRate(request.Rate)).ReturnsAsync(performances);
            _mapperMock.Setup(mapper => mapper.Map<List<PerformanceResponse>>(performances)).Returns(new List<PerformanceResponse>());

            // Act
            var result = await _performanceService.GetPerformancesByRate(request);

            // Assert
            _performanceRepositoryMock.Verify(repo => repo.GetPerformancesByRate(request.Rate), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<PerformanceResponse>>(performances), Times.Once);
            Xunit.Assert.NotNull(result);
        }
    }
}
