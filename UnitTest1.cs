using PayrollCalculatorNS;

namespace TestPayrollCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestThreeEmployeesSum()
        {
            var payrollCalculator = new PayrollCalculator();

            var employees = new List<Employee> {
                new Employee { Name = "John", Position = "manager", Salary = 5000 },
                new Employee { Name = "Doe", Position = "developer", Salary = 4000 },
                new Employee { Name = "Jane", Position = "intern", Salary = 2000 }
            };

            var totalPayroll = payrollCalculator.CalculateTotalPayroll(employees);

            Assert.AreEqual(14300, totalPayroll);
        }

        [TestMethod]
        public void TestZeroEmployeesSum()
        {
            var payrollCalculator = new PayrollCalculator();

            var employees = new List<Employee>
            {

            };
            var totalPayroll = payrollCalculator.CalculateTotalPayroll(employees);

            Assert.AreEqual(0, totalPayroll);
        }
    }
}