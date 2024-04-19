using System;

namespace RequestTrackerBLL
{
    public class DepartmentNotFoundException : Exception
    {
        public DepartmentNotFoundException() : base("Department not found")
        {
        }
    }
}
