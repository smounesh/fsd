using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerFEAPP
{
    internal class AdminMenu
    {
        private readonly IRequestManagementBL _requestManagementBL;

        public AdminMenu()
        {
            _requestManagementBL = new RequestManagementBL();
        }

        public async Task Start(Employee admin)
        {
            Console.WriteLine($"Welcome, {admin.Name} (Admin)!");
            await ShowAdminMenu(admin);
        }

        private async Task ShowAdminMenu(Employee admin)
        {
            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View Requests");
            Console.WriteLine("3. View Solutions");
            Console.WriteLine("4. Give Feedback");
            Console.WriteLine("5. Respond to Solution");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your choice:");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    await RaiseRequest(admin);
                    break;
                case 2:
                    await ViewRequests(admin);
                    break;
                case 3:
                    await ViewSolutions(admin);
                    break;
                case 4:
                    await GiveFeedback(admin);
                    break;
                case 5:
                    await RespondToSolution(admin);
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    await ShowAdminMenu(admin);
                    break;
            }
        }

        private async Task RaiseRequest(Employee admin)
        {
            try
            {
                Console.WriteLine("- Raise Request");
                Console.WriteLine("Enter request message:");
                string message = Console.ReadLine();
                Request newRequest = new Request { RequestMessage = message, RequestRaisedBy = admin.Id };
                var result = await _requestManagementBL.RaiseRequest(newRequest);
                Console.WriteLine($"Request raised successfully. Request number: {result.RequestNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            await ShowAdminMenu(admin);
        }

        private async Task ViewRequests(Employee admin)
        {
            try
            {
                Console.WriteLine("- View Requests");
                var requests = await _requestManagementBL.GetAllRequests();
                foreach (var request in requests)
                {
                    Console.WriteLine($"Request Number: {request.RequestNumber}, Message: {request.RequestMessage}, Status: {request.RequestStatus}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            await ShowAdminMenu(admin);
        }

        private async Task ViewSolutions(Employee admin)
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
            await ShowAdminMenu(admin);
        }

        private async Task GiveFeedback(Employee admin)
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
            await ShowAdminMenu(admin);
        }

        private async Task RespondToSolution(Employee admin)
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
            await ShowAdminMenu(admin);
        }
    }
}
