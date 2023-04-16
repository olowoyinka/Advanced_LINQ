using System;
using System.Collections.Generic;
using System.Linq;
using TCPData;
using TCPExtensions;

namespace TCPApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3

            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            var resultList = from emp in employeeList
                             join dept in departmentList
                             on emp.DepartmentId equals dept.Id
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 Manager = emp.IsManager,
                                 Department = dept.LongName
                             };

            foreach (var employee in resultList)
            {
                Console.WriteLine($"First Name: {employee.FirstName}");
                Console.WriteLine($"Last Name: {employee.LastName}");
                Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
                Console.WriteLine($"Manager: {employee.Manager}");
                Console.WriteLine($"Department: {employee.Department}");
                Console.WriteLine();
            }

            var averageAnnualSalary = resultList.Average(s => s.AnnualSalary);
            var highestAnnualSalary = resultList.Max(s => s.AnnualSalary);
            var lowestAnnualSalary = resultList.Min(s => s.AnnualSalary);

            Console.WriteLine($"Average Annual Salary: {averageAnnualSalary}");
            Console.WriteLine($"Highest Annual Salary: {highestAnnualSalary}");
            Console.WriteLine($"Lowest Annual Salary: {lowestAnnualSalary}");


            // 1

            //List<Employee> employeeList = Data.GetEmployees();
            //var filteredEmployees = employeeList.Filter(emp => !emp.IsManager);
            //foreach (var employee in filteredEmployees)
            //{
            //    Console.WriteLine($"First Name: {employee.FirstName}");
            //    Console.WriteLine($"Last Name: {employee.LastName}");
            //    Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
            //    Console.WriteLine($"Manager: {employee.IsManager}");
            //    Console.WriteLine();
            //}
            //Console.ReadKey();

            // 2

            //List<Department> departmentList = Data.GetDepartments();
            //var filteredDepartments = departmentList.Where(s => s.ShortName == "FN" || s.ShortName == "HR");
            //foreach (var department in filteredDepartments)
            //{
            //    Console.WriteLine($"Id: {department.Id}");
            //    Console.WriteLine($"Short Name: {department.ShortName}");
            //    Console.WriteLine($"Long Name: {department.LongName}");
            //    Console.WriteLine();
            //}
            //Console.ReadKey();
        }
    }
}