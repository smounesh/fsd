using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Threading.Tasks;

namespace RequestTrackerFEAPP
{
    public class Admin
    {
        private Employee admin;

        public async Task StartAdmin(Employee employee)
        {
            admin = employee;
            Console.WriteLine($"Hi {employee.Name}");
            int choice;
            do
            {
                ShowAdminMenu();
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
                        await ProvideSolution();
                        break;
                    case 7:
                        await CloseRequest();
                        break;
                    case 8:
                        await ViewFeedbacks();
                        break;
                    case 9:
                        return;
                }
            } while (choice != 9);
        }

        private void ShowAdminMenu()
        {
            Console.WriteLine("1. Raise Request\n2. View Request Status\n3. View Solutions\n4. Give Feedback\n" +
                "5. Respond to Solution\n6. Provide Solution\n7. Mark Request as Closed\n8. View Feedbacks\n9. Exit");
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
                    RequestRaisedBy = admin.Id,
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
                var requestList = await requestBL.ViewAllRequest();

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
                var solutionList = await solutionBL.ViewAllSolutions();
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
            await ViewSolutionListByRequestId(admin.Id);
        }

        private async Task RespondToSolution()
        {
            await GetSolutionByEmployeeId(admin.Id);
        }

        private async Task ProvideSolution()
        {
            await ViewRequests();
            Console.WriteLine("Enter the request ID:");
            int requestId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the solution you need to provide:");
            string providedSolution = Console.ReadLine();
            try
            {
                EmployeeSolutionBL solutionBL = new EmployeeSolutionBL();
                SolutionRequest solution = new SolutionRequest
                {
                    RequestId = requestId,
                    SolutionDescription = providedSolution,
                    SolvedBy = admin.Id,
                    SolvedDate = DateTime.Now,
                    IsSolved = true
                };
                int result = await solutionBL.AddSolution(solution);
                Console.WriteLine($"Solution added to request ID {requestId} successfully. Solution ID: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task CloseRequest()
        {
            await ShowAllOpenRequests(admin.Id);
        }

        private async Task ViewFeedbacks()
        {
            try
            {
                EmployeeFeedBackBL feedbackBL = new EmployeeFeedBackBL();
                var feedbackList = await feedbackBL.GetFeedBack(admin.Id);
                Console.WriteLine("Feedback Id | Solution Id | Rating | Remarks | Feedback By (Id) | Feedback Date");
                foreach (var feedback in feedbackList)
                {
                    Console.WriteLine($"{feedback.FeedbackId} | {feedback.SolutionId} | {feedback.Rating} | {feedback.Remarks} | {feedback.FeedbackBy} | {feedback.FeedbackDate}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task ViewRequests()
        {
            try
            {
                EmployeeRequestBL requestBL = new EmployeeRequestBL();
                var requestList = await requestBL.ViewAllRequest();
                Console.WriteLine("Request Id | Raised By (Id) | Request Message | Request Date | Request Status");
                foreach (var request in requestList)
                {
                    if (request.RequestStatus == "open")
                    {
                        Console.WriteLine($"{request.RequestNumber} | {request.RequestRaisedBy} | {request.RequestMessage} | {request.RequestDate} | {request.RequestStatus}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task ShowAllOpenRequests(int id)
        {
            try
            {
                EmployeeRequestBL requestBL = new EmployeeRequestBL();
                var openRequestList = await requestBL.ViewAllOpenRequest();
                Console.WriteLine("Request Id | Raised By (Id) | Request Message | Request Date | Request Status");
                foreach (var request in openRequestList)
                {
                    Console.WriteLine($"{request.RequestNumber} | {request.RequestRaisedBy} | {request.RequestMessage} | {request.RequestDate} | {request.RequestStatus}");
                }
                await CloseRequest(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task CloseRequest(int id)
        {
            try
            {
                Console.WriteLine("Enter request ID to mark as closed:");
                int requestId = Convert.ToInt32(Console.ReadLine());
                EmployeeRequestBL requestBL = new EmployeeRequestBL();
                int result = await requestBL.CloseRequest(requestId, id);
                Console.WriteLine($"Request ID {result} closed successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
                    FeedbackBy = admin.Id,
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

        private async Task GetSolutionByEmployeeId(int id)
        {
            try
            {
                EmployeeSolutionBL solutionBL = new EmployeeSolutionBL();
                var solutionList = await solutionBL.ViewSolutionsById(id);
                Console.WriteLine("Solution Id | Request Id | Solved By (Id) | Solution | Solved Date | Raiser Comment");
                if (solutionList.Count > 0)
                {
                    foreach (var solution in solutionList)
                    {
                        Console.WriteLine($"{solution.SolutionId} | {solution.RequestId} | {solution.SolvedBy} | " +
                            $"{solution.SolutionDescription} | {solution.SolvedDate} | {solution.RequestRaiserComment}");
                    }
                    await AddCommentToSolution();
                }
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