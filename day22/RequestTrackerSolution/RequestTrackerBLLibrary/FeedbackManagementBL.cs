using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class FeedbackManagementBL : IFeedbackManagementBL
    {
        private readonly ISolutionFeedbackRepository _feedbackRepository;

        public FeedbackManagementBL(ISolutionFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<SolutionFeedback> GiveFeedback(SolutionFeedback feedback)
        {
            return await _feedbackRepository.Add(feedback);
        }

        public async Task<IList<SolutionFeedback>> GetAllFeedbacks()
        {
            return await _feedbackRepository.GetAll();
        }

        public async Task<IList<SolutionFeedback>> GetFeedbacksForSolution(int solutionId)
        {
            return await _feedbackRepository.GetFeedbacksForSolution(solutionId);
        }

        public async Task<IList<SolutionFeedback>> GetFeedbacksByEmployee(int employeeId)
        {
            return await _feedbackRepository.GetFeedbacksByEmployee(employeeId);
        }
    }
}
