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
    public class TheatreRepositoryTests: IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fix;
        private readonly ITheatreRepository _theatreRepository;

        public TheatreRepositoryTests(DatabaseFixture fix)
        {
            _fix = fix;
            _theatreRepository = new TheatreRepository(_fix.Context);
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            var theatres = await _theatreRepository.GetAllAsync();

            Xunit.Assert.NotNull(theatres);
        }

        [Fact]
        public async Task GetTheatreByNameTest()
        {
            string name = "Meow";
            var theatre = await _theatreRepository.GetTheatreByName(name);

            Xunit.Assert.Null(theatre);
        }
    }
}
