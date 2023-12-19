using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IHoleService
    {
        Task<List<HoleResponse>> GetAllHoles();
        Task<List<HoleResponse>> GetHoleByTheatreId(HoleByTheatreRequest request);
    }
}
