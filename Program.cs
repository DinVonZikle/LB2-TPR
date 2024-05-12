using System;
using System.Collections.Generic;
using static PayrollCalculatorNS.Program;

namespace PayrollCalculatorNS
{
    public class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee { Name = "John", Position = "manager", Salary = 5000 },
                new Employee { Name = "Doe", Position = "developer", Salary = 4000 },
                new Employee { Name = "Jane", Position = "intern", Salary = 2000 }
            };

            var positions = new List<Position>()
            {
                new Position { PositionName = "manager", SalaryCoefficient = 1.5m },
                new Position { PositionName = "developer", SalaryCoefficient = 1.2m },
                new Position { PositionName = "intern", SalaryCoefficient = 1.0m }
            };

            var payrollCalculator = new PayrollCalculator(positions);
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

    public class Position
    {
        public string PositionName { get; set; }
        public decimal SalaryCoefficient { get; set; }
    }

    public class PayrollCalculator
    {
        private List<Position> positions;

        public PayrollCalculator(List<Position> positions)
        {
            this.positions = positions;
        }

        public decimal CalculateTotalPayroll(List<Employee> employees)
        {
            decimal totalPayroll = 0;

            foreach (var employee in employees)
            {
                ValidateSalary(employee.Salary);
                decimal coefficient = GetCoefficientByPosition(employee.Position);
                totalPayroll += employee.Salary * coefficient;
            }
            return totalPayroll;
        }

        private decimal GetCoefficientByPosition(string position)
        {
            foreach (var pos in positions)
            {
                if (pos.PositionName == position)
                {
                    return pos.SalaryCoefficient;
                }
            }
            throw new InvalidUserPositionException(position);
        }

        private void ValidateSalary(decimal salary)
        {
            if (salary <= 0)
            {
                throw new InvalidSalaryException();
            }
        }
    }

    public class InvalidUserPositionException : Exception
    {
        public InvalidUserPositionException(string position)
            : base($"Неправильно вказана посада користувача: {position}")
        {
        }
    }

    public class InvalidSalaryException : Exception
    {
        public InvalidSalaryException()
            : base($"Неправильна зарплата.")
        {
        }
    }
}