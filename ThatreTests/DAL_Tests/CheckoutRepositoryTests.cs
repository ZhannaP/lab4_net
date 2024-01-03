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
    public class CheckoutRepositoryTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fix;
        private readonly ICheckoutRepository _checkoutRepository;

        public CheckoutRepositoryTests(DatabaseFixture fixture)
        {
            _fix = fixture;
            _checkoutRepository = new CheckoutRepository(_fix.Context);
        }

        [Fact]
        public async Task GetCheckoutsByPerformanceIdTest()
        {
            var checkouts = await _checkoutRepository.GetCheckouts(1);

            Xunit.Assert.NotNull(checkouts);
        }

        [Fact]
        public async Task GetCheckoutsByPerformanceAndTIcketStatus_Test()
        {
            var checkouts = await _checkoutRepository.GetTicketsByStatus(1,1);

            Xunit.Assert.NotNull(checkouts);
        }
    }
}
