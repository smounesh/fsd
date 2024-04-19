using System;

namespace RequestTrackerBLL
{
    public class DuplicateDepartmentNameException : Exception
    {
        public DuplicateDepartmentNameException() : base("Department name already exists")
        {
        }
    }
}
