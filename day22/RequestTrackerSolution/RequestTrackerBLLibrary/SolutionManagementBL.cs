using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class SolutionManagementBL : ISolutionManagementBL
    {
        private readonly IRequestSolutionRepository _solutionRepository;

        public SolutionManagementBL(IRequestSolutionRepository solutionRepository)
        {
            _solutionRepository = solutionRepository;
        }

        public async Task<RequestSolution> ProvideSolution(RequestSolution solution)
        {
            return await _solutionRepository.Add(solution);
        }

        public async Task<IList<RequestSolution>> GetAllSolutions()
        {
            return await _solutionRepository.GetAll();
        }

        public async Task<IList<RequestSolution>> GetSolutionsForRequest(int requestId)
        {
            return await _solutionRepository.GetSolutionsForRequest(requestId);
        }

        public async Task<IList<RequestSolution>> GetSolutionsByEmployee(int employeeId)
        {
            return await _solutionRepository.GetSolutionsByEmployee(employeeId);
        }

        public async Task<RequestSolution> RespondToSolution(int solutionId, string adminResponse)
        {
            {
                var solution = await _solutionRepository.Get(solutionId);
                if (solution != null)
                {
                    solution.AdminResponse = adminResponse;

                    await _solutionRepository.Update(solution);

                    return solution;
                }
                return null;
            }
        }
    }
}
