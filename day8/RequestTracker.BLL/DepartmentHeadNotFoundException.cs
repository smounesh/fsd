using System;

namespace RequestTrackerBLL
{
    public class DepartmentHeadNotFoundException : Exception
    {
        public DepartmentHeadNotFoundException() : base("Department head not found")
        {
        }
    }
}
