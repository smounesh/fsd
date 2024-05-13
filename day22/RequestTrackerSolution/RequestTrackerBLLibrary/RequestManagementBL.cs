using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class RequestManagementBL : IRequestManagementBL
    {
        private readonly IRequestRepository _requestRepository;

        public RequestManagementBL(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository ?? throw new ArgumentNullException(nameof(requestRepository));
        }

        public RequestManagementBL()
        {
            _requestRepository = new RequestRepository();
        }

        public async Task<Request> RaiseRequest(Request request)
        {
            return await _requestRepository.Add(request);
        }

        public async Task<IList<Request>> GetAllRequests()
        {
            return await _requestRepository.GetAll();
        }

        public async Task<IList<Request>> GetRequestsByEmployee(int employeeId)
        {
            return await _requestRepository.GetRequestsByEmployee(employeeId);
        }

        public async Task<Request> MarkRequestAsClosed(int requestId)
        {
            var request = await _requestRepository.Get(requestId);
            if (request != null)
            {
                request.RequestStatus = "Closed";
                return await _requestRepository.Update(request);
            }
            return null;
        }
    }
}
