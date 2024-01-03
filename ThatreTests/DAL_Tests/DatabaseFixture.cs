using DAL.Context;
using DAL.Entities;

using Microsoft.EntityFrameworkCore;

namespace ThatreTests.DAL_Tests
{
    public class DatabaseFixture : IDisposable
    {
        public TheatreContext Context;

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<TheatreContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            Context = new TheatreContext(options);
            TestData().Wait();
        }

        private async Task TestData()
        {
            List<Performance> performances = new List<Performance>()
            {
                new Performance{Name = "Назва1", Author = "Meow", Description="Meow", Rate = 1},
                new Performance{Name = "Назва2", Author = "Meow2", Description="Meow2", Rate = 2},
            };
            await Context.Performances.AddRangeAsync(performances);
            await Context.SaveChangesAsync();

            List<Checkout> checkots = new List<Checkout>()
            {
                new Checkout() { TicketStatusId = 1, PerformanceID = 1, AmountOfTickets = 50, Price = 100},
                new Checkout() { TicketStatusId = 1, PerformanceID = 1, AmountOfTickets = 50, Price = 100},
                new Checkout() { TicketStatusId = 1, PerformanceID = 1, AmountOfTickets = 50, Price = 100},
                new Checkout() { TicketStatusId = 1, PerformanceID = 1, AmountOfTickets = 50, Price = 100},
                new Checkout() { TicketStatusId = 1, PerformanceID = 1, AmountOfTickets = 50, Price = 100},
            };
            await Context.Checkouts.AddRangeAsync(checkots);
            await Context.SaveChangesAsync();

            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket() {  SeatNumber = 2 },
                new Ticket() {SeatNumber = 4 },
                new Ticket() {  SeatNumber = 6 },
                new Ticket() { SeatNumber = 3 }
            };
            await Context.Tickets.AddRangeAsync(tickets);
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}