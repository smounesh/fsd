using System;

namespace RequestTrackerBLL
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException() : base("Employee not found")
        {
        }
    }
}
