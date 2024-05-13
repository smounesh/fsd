using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerFEAPP
{
    internal class UserMenu
    {
        private readonly IRequestManagementBL _requestManagementBL;

        public UserMenu(IRequestManagementBL requestManagementBL)
        {
            _requestManagementBL = requestManagementBL;
        }

        public UserMenu()
        {
            _requestManagementBL = new RequestManagementBL();
        }

        public async Task Start(Employee user)
        {
            Console.WriteLine($"Welcome, {user.Name} (User)!");
            await ShowUserMenu(user);
        }

        private async Task ShowUserMenu(Employee user)
        {
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View Request Status");
            Console.WriteLine("3. View Solutions");
            Console.WriteLine("4. Give Feedback");
            Console.WriteLine("5. Respond to Solution");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your choice:");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    await RaiseRequest(user);
                    break;
                case 2:
                    await ViewRequestStatus(user);
                    break;
                case 3:
                    await ViewSolutions(user);
                    break;
                case 4:
                    await GiveFeedback(user);
                    break;
                case 5:
                    await RespondToSolution(user);
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    await ShowUserMenu(user);
                    break;
            }
        }

        private async Task RaiseRequest(Employee user)
        {
            try
            {
                Console.WriteLine("- Raise Request");
                Console.WriteLine("Enter request message:");
                string message = Console.ReadLine();
                Request newRequest = new Request { RequestMessage = message, RequestRaisedBy = user.Id };
                var result = await _requestManagementBL.RaiseRequest(newRequest);
                Console.WriteLine($"Request raised successfully. Request number: {result.RequestNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            await ShowUserMenu(user);
        }

        private async Task ViewRequestStatus(Employee user)
        {
            try
            {
                Console.WriteLine("- View Request Status");
                var requests = await _requestManagementBL.GetRequestsByEmployee(user.Id);
                foreach (var request in requests)
                {
                    Console.WriteLine($"Request Number: {request.RequestNumber}, Message: {request.RequestMessage}, Status: {request.RequestStatus}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            await ShowUserMenu(user);
        }

        private async Task ViewSolutions(Employee user)
        {
            try
            {
                Console.WriteLine("- View Solutions");
                // Implement logic to view solutions
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            await ShowUserMenu(user);
        }

        private async Task GiveFeedback(Employee user)
        {
            try
            {
                Console.WriteLine("- Give Feedback");
                // Implement logic to give feedback
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            await ShowUserMenu(user);
        }

        private async Task RespondToSolution(Employee user)
        {
            try
            {
                Console.WriteLine("- Respond to Solution");
                // Implement logic to respond to solution
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            await ShowUserMenu(user);
        }
    }
}
