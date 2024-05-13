using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerModelLibrary;


namespace RequestTrackerDALLibrary
{
    public interface IRequestRepository : IRepository<int, Request>
    {
        Task<IList<Request>> GetAllRequests();
        Task<IList<Request>> GetRequestsByEmployee(int userId);
    }
}
