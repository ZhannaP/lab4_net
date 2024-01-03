using DAL.Repositories;
using DAL.Repositories.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace ThatreTests.DAL_Tests
{
    public class HoleRepositoryTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fix;
        private readonly IHoleServices _holeRepository;

        public HoleRepositoryTests(DatabaseFixture fixture)
        {
            _fix = fixture;
            _holeRepository = new HoleRepository(_fix.Context);
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            var holes = await _holeRepository.GetAllAsync();

            Xunit.Assert.NotNull(holes);
        }

        [Fact]
        public async Task GetHoleByTheatreIdTest()
        {
            int id = 1;
            var holes = await _holeRepository.GetHoleByTheatreId(id);

            Xunit.Assert.NotNull(holes);           
        }

    }
}
