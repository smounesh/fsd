using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public interface IRequestManagementBL
    {
        Task<Request> RaiseRequest(Request request);
        Task<IList<Request>> GetAllRequests();
        Task<IList<Request>> GetRequestsByEmployee(int employeeId);
        Task<Request> MarkRequestAsClosed(int requestId);
    }
}
