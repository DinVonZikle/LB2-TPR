using System;
using System.Collections.Generic;

namespace PayrollCalculatorNS
{
    public class Program
    {
        public class InvalidUserTypeException : Exception
        {
            public InvalidUserTypeException() : base("Неправильний тип користувача.") { }
        }


        static void Main(string[] args)
        {
            var employees = new List<Employee>
        {
            new Employee { Name = "John", Position = "manager", Salary = 5000 },
            new Employee { Name = "Doe", Position = "developer", Salary = 4000 },
            new Employee { Name = "Jane", Position = "intern", Salary = 2000 }
        };

            var payrollCalculator = new PayrollCalculator();
            var totalPayroll = payrollCalculator.CalculateTotalPayroll(employees);

            Console.WriteLine($"Total payroll: {totalPayroll}");
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }

    public class PayrollCalculator
    {
        public decimal CalculateTotalPayroll(List<Employee> employees)
        {
            decimal totalPayroll = 0;
            foreach (var employee in employees)
            {
                if (employee.Position == "manager")
                {
                    totalPayroll += employee.Salary * 1.5m;
                }
                else if (employee.Position == "developer")
                {
                    totalPayroll += employee.Salary * 1.2m;
                }
                else
                {
                    totalPayroll += employee.Salary;
                }
            }
            return totalPayroll;
        }
    }

}