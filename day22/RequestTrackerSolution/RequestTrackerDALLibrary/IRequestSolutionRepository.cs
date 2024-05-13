using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public interface IRequestSolutionRepository : IRepository<int, RequestSolution>
    {
        Task<IList<RequestSolution>> GetSolutionsForRequest(int requestId);
        Task<IList<RequestSolution>> GetSolutionsByEmployee(int employeeId);
    }
}
