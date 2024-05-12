using PayrollCalculatorNS;

namespace TestPayrollCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestThreeEmployeesSum()
        {
            var employees = new List<Employee> {
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

            Assert.AreEqual(14300, totalPayroll);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserPositionException))]
        public void TestZeroEmployeesSum()
        {
            var employees = new List<Employee> {
                new Employee { Name = "John", Position = "manager", Salary = 5000 },
                new Employee { Name = "Doe", Position = "developer", Salary = 4000 },
                new Employee { Name = "Jane", Position = "someone", Salary = 2000 }
            };

            var positions = new List<Position>()
            {
                new Position { PositionName = "manager", SalaryCoefficient = 1.5m },
                new Position { PositionName = "developer", SalaryCoefficient = 1.2m },
                new Position { PositionName = "intern", SalaryCoefficient = 1.0m }
            };

            var payrollCalculator = new PayrollCalculator(positions);

            var totalPayroll = payrollCalculator.CalculateTotalPayroll(employees);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidSalaryException))]
        public void TestInvalidSalaryInput()
        {
            var employees = new List<Employee> {
                new Employee { Name = "John", Position = "manager", Salary = 5000 },
                new Employee { Name = "Doe", Position = "developer", Salary = 4000 },
                new Employee { Name = "Jane", Position = "intern", Salary = -1242 }
            };

            var positions = new List<Position>()
            {
                new Position { PositionName = "manager", SalaryCoefficient = 1.5m },
                new Position { PositionName = "developer", SalaryCoefficient = 1.2m },
                new Position { PositionName = "intern", SalaryCoefficient = 1.0m }
            };

            var payrollCalculator = new PayrollCalculator(positions);

            var totalPayroll = payrollCalculator.CalculateTotalPayroll(employees);
        }
    }
}