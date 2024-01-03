using DAL.Repositories.Interfaces;
using DAL.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace ThatreTests.DAL_Tests
{
    public class PerformanceRepositoryTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fix;
        private readonly IPerformanceRepository _performanceRepository;

        public PerformanceRepositoryTests(DatabaseFixture fixture)
        {
            _fix = fixture;
            _performanceRepository = new PerformanceRepository(_fix.Context);
        }

        [Fact]
        public async Task GetPerformancesByAuthorTest()
        {
            string name = "";
            var performances = await _performanceRepository.GetPerformancesByAuthor(name);

            Xunit.Assert.Null(performances);
        }

        [Fact]
        public async Task GetPerformancesByHoleTest()
        {
            var performances = await _performanceRepository.GetPerformancesByHole(1);

            Xunit.Assert.NotNull(performances);
        }

        [Fact]
        public async Task GetPerformancesByNameTest()
        {
            var performances = await _performanceRepository.GetPerformancesByName("");

            Xunit.Assert.Null(performances);
        }

        [Fact]
        public async Task GetPerformancesByRateTest()
        {
            var performances = await _performanceRepository.GetPerformancesByRate(1);

            Xunit.Assert.NotNull(performances);
        }
    }
}
