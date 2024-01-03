using DAL.Context;
using DAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatreTests
{
    public class DatabaseFill : IDisposable
    {
        TheatreContext context;

        public void Dispose()
        {
            context.Dispose();
        }

        DatabaseFill()
        {
            var options = new DbContextOptionsBuilder<TheatreContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            context = new TheatreContext(options);
            SeedTestData().Wait();
        }

        private async Task SeedTestData()
        {
            Random random = new Random();

            List<TicketStatus> statuses = new List<TicketStatus>
            {
                new TicketStatus() { StatusName = "Куплений" },
                new TicketStatus() { StatusName = "Заброньований"}
            };
            await context.TicketStatuses.AddRangeAsync(statuses);

            List<TicketType> types = new List<TicketType>()
            {
                new TicketType() { TicketTypeName = "Звичайний" },
                new TicketType() { TicketTypeName = "Віп" },
                new TicketType() { TicketTypeName = "Преміум" }
            };
            await context.TicketTypes.AddRangeAsync(types);

            List<Hall> halls = new List<Hall>()
            {
                new Hall { Name = "Великий зал", NumberOfSeats = 40},
                new Hall { Name = "Малий зал", NumberOfSeats = 20 }
            };
            await context.Holes.AddRangeAsync(halls);

            List<Theatre> theatres = new List<Theatre>()
            {
                new Theatre { Name = "Драмтеатр"},
                new Theatre { Name = "Театр Ляльок" }
            };
            await context.Theatres.AddRangeAsync(theatres);

            List<Performance> performances = new List<Performance>()
            {
                new Performance{Name = "Meow", Author = "Meow Moew", Description="meow", Rate=5},
                new Performance { Name = "Woof", Author = "Woof Woof", Description="woof", Rate=1}
            };
            await context.Performances.AddRangeAsync(performances);
            await context.SaveChangesAsync();

            List<Checkout> options = new List<Checkout>()
            {
                new Checkout() { TicketStatusId=1, PerformanceID = 1, AmountOfTickets = 50, Price = 100},
                new Checkout() {  TicketStatusId=2, PerformanceID = 2, AmountOfTickets = 20, Price = 200},
                new Checkout() {  TicketStatusId=3, PerformanceID = 1, AmountOfTickets = 10, Price = 300 },

            };
            await context.Checkouts.AddRangeAsync(options);
            await context.SaveChangesAsync();

            List<Ticket> tickets = new List<Ticket>()
            {
                new Ticket() { Price=100, FirstName="Meow", LastName="Meow", MiddleName="Meow", SeatNumber=1 },
                new Ticket() { Price=200, FirstName="Meow1", LastName="Meow1", MiddleName="Meow1", SeatNumber=2},
                new Ticket() { Price=300, FirstName="Meow2", LastName="Meow2", MiddleName="Meow2", SeatNumber=3 },
                new Ticket() { Price=400, FirstName="Meow3", LastName="Meow3", MiddleName="Meow3", SeatNumber=4 }
            };
            await context.Tickets.AddRangeAsync(tickets);
            await context.SaveChangesAsync();
        }
    }
}
