using BLL.Requests;
using BLL.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ITheatreService
    {
        Task<List<TheatreResponse>> GetAllTheatres();
        Task<List<TheatreResponse>> GetTheatreById(TheatreRequest request);
    }
}
