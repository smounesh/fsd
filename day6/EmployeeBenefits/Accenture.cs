using System;

namespace EmployeeBenefits
{
    public class Accenture : Employee, GovtRulesInterface
    {
        public Accenture(int id, string name, string dept, string desc, double salary) : base(id, name, dept, desc, salary) { }

        public double EmployeePF(double basicSalary)
        {
            return 0.24 * basicSalary;
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }

        public string LeaveDetails()
        {
            return "2 days of Casual Leave per month\r\n5 days of Sick Leave per year\r\n5 days of Privilege Leave per year";
        }
    }
}
