using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public interface ISolutionFeedbackRepository : IRepository<int, SolutionFeedback>
    {
        Task<IList<SolutionFeedback>> GetFeedbacksForSolution(int solutionId);
        Task<IList<SolutionFeedback>> GetFeedbacksByEmployee(int employeeId);

    }
}
