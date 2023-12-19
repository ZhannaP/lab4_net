using DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface ITheatreRepository : IGenericRepository<Theatre>
    {
        Task<List<Theatre>> GetTheatreByName(string Name);
    }
}
