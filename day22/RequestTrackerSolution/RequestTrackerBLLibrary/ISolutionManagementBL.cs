using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public interface ISolutionManagementBL
    {
        Task<RequestSolution> ProvideSolution(RequestSolution solution);
        Task<IList<RequestSolution>> GetAllSolutions();
        Task<IList<RequestSolution>> GetSolutionsForRequest(int requestId);
        Task<IList<RequestSolution>> GetSolutionsByEmployee(int employeeId);
        Task<RequestSolution> RespondToSolution(int solutionId, string adminResponse); // Add RespondToSolution method
    }
}
