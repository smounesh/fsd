using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class User
    {
        private Employee user;

        public async Task StartUser(Employee employee)
        {
            user = employee;
            Console.WriteLine($"Hi {employee.Name}");
            int choice;
            do
            {
                ShowUserMenu();
                Console.WriteLine("Enter the choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        await RaiseRequest();
                        break;
                    case 2:
                        await ViewRequestStatus();
                        break;
                    case 3:
                        await ViewSolutions();
                        break;
                    case 4:
                        await GiveFeedback();
                        break;
                    case 5:
                        await RespondToSolution();
                        break;
                    case 6:
                        return;
                }
            } while (choice != 6);
        }

        private void ShowUserMenu()
        {
            Console.WriteLine("1. Raise Request\n2. View Request Status\n3. View Solutions\n4. Give Feedback\n" +
                "5. Respond to Solution\n6. Exit");
        }

        private async Task RaiseRequest()
        {
            Console.WriteLine("Enter the request message:");
            string message = Console.ReadLine();
            try
            {
                Request request = new Request
                {
                    RequestMessage = message,
                    RequestDate = DateTime.Now,
                    RequestRaisedBy = user.Id,
                    RequestStatus = "open"
                };
                EmployeeRequestBL requestBL = new EmployeeRequestBL();
                int result = await requestBL.AddRequest(request);
                Console.WriteLine($"Request raised successfully. Request ID: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task ViewRequestStatus()
        {
            try
            {
                EmployeeRequestBL requestBL = new EmployeeRequestBL();
                var requestList = await requestBL.ViewRequest(user.Id);
                Console.WriteLine("Request Id | Request Status");
                foreach (var request in requestList)
                {
                    Console.WriteLine($"{request.RequestNumber} | {request.RequestStatus}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task ViewSolutions()
        {
            try
            {
                EmployeeSolutionBL solutionBL = new EmployeeSolutionBL();
                var solutionList = await solutionBL.ViewSolutionsById(user.Id);
                Console.WriteLine("Solution Id | Request Id | Solved By (Id) | Solution | Solved Date | Raiser Comment");
                foreach (var solution in solutionList)
                {
                    string raiserComment = solution.RequestRaiserComment ?? "No Comments";
                    Console.WriteLine($"{solution.SolutionId} | {solution.RequestId} | {solution.SolvedBy} | " +
                        $"{solution.SolutionDescription} | {solution.SolvedDate} | {raiserComment}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task GiveFeedback()
        {
            await ViewSolutionListByRequestId(user.Id);
        }

        private async Task RespondToSolution()
        {
            await AddCommentToSolution();
        }

        private async Task ViewSolutionListByRequestId(int id)
        {
            try
            {
                var requestList = await GetRequestListByEmployeeId(id);
                EmployeeSolutionBL solutionBL = new EmployeeSolutionBL();
                bool isSolutionAvailable = false;
                Console.WriteLine("Solution Id | Request Id | Solved By (Id) | Solution | Solved Date | Raiser Comment");
                foreach (var request in requestList)
                {
                    var solutionList = await solutionBL.GetSolutionsByRequestId(request.RequestNumber);
                    if (solutionList.Count > 0)
                    {
                        isSolutionAvailable = true;
                        foreach (var solution in solutionList)
                        {
                            Console.WriteLine($"{solution.SolutionId} | {solution.RequestId} | {solution.SolvedBy} | " +
                                $"{solution.SolutionDescription} | {solution.SolvedDate} | {solution.RequestRaiserComment}");
                        }
                    }
                }
                if (isSolutionAvailable)
                {
                    await AddFeedback();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task<List<Request>> GetRequestListByEmployeeId(int id)
        {
            try
            {
                EmployeeRequestBL requestBL = new EmployeeRequestBL();
                var requestList = await requestBL.ViewRequest(id);
                return requestList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task AddFeedback()
        {
            try
            {
                Console.WriteLine("Enter the solution ID to give feedback:");
                int solutionId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter rating for the solution:");
                float rating = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter remarks:");
                string remarks = Console.ReadLine();
                SolutionFeedback feedback = new SolutionFeedback
                {
                    Rating = rating,
                    Remarks = remarks,
                    SolutionId = solutionId,
                    FeedbackBy = user.Id,
                    FeedbackDate = DateTime.Now
                };
                EmployeeFeedBackBL feedbackBL = new EmployeeFeedBackBL();
                await feedbackBL.AddFeedBack(feedback);
                Console.WriteLine($"Feedback added successfully for solution ID {solutionId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task AddCommentToSolution()
        {
            try
            {
                Console.WriteLine("Enter the solution ID to add comment:");
                int solutionId = Convert.ToInt32(Console.ReadLine());
                EmployeeSolutionBL solutionBL = new EmployeeSolutionBL();
                var solution = await solutionBL.GetSolutionById(solutionId);
                Console.WriteLine("Enter the comment for the solution:");
                string comment = Console.ReadLine();
                solution.RequestRaiserComment = comment;
                int result = await solutionBL.AddRespondToSolution(solution);
                Console.WriteLine($"Comment added to solution ID {result} successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}