using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public interface IFeedbackManagementBL
    {
        Task<SolutionFeedback> GiveFeedback(SolutionFeedback feedback);
        Task<IList<SolutionFeedback>> GetAllFeedbacks();
        Task<IList<SolutionFeedback>> GetFeedbacksForSolution(int solutionId);
        Task<IList<SolutionFeedback>> GetFeedbacksByEmployee(int employeeId);
    }
}
