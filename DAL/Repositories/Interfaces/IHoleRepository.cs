using DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IHoleServices : IGenericRepository<Hall>
    {
        Task<List<Hall>> GetHoleByID(int HoleID);
        Task<List<Hall>> GetHoleByTheatreId(int TheatreId);
    }
}
