﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TCPData;

namespace LINQEx_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// Sorting Operations OrderBy, OrderByDescending, ThenBy, ThenByDescending

            ////Method Syntax
            //var results = employeeList.Join(departmentList, 
            //                            e => e.DepartmentId, d => d.Id,
            //                            (emp, dept) => new
            //                                {
            //                                    Id = emp.Id,
            //                                    FirstName = emp.FirstName,
            //                                    LastName = emp.LastName,
            //                                    AnnualSalary = emp.AnnualSalary,
            //                                    DepartmentId = emp.DepartmentId,
            //                                    DepartmentName = dept.LongName
            //                                })
            //                                .OrderBy(o => o.DepartmentId)
            //                                    .ThenByDescending(o => o.AnnualSalary);

            //foreach (var item in results)
            //    Console.WriteLine($"First Name: {item.FirstName,-10} Last Name: {item.LastName,-10} Annual Salary: {item.AnnualSalary,10}\tDepartment Name: {item.DepartmentName}");



            //// Query Syntax
            //var results = from emp in employeeList
            //              join dept in departmentList
            //              on emp.DepartmentId equals dept.Id
            //              orderby emp.DepartmentId, emp.AnnualSalary descending
            //              select new
            //              {
            //                  Id = emp.Id,
            //                  FirstName = emp.FirstName,
            //                  LastName = emp.LastName,
            //                  AnnualSalary = emp.AnnualSalary,
            //                  DepartmentId = emp.DepartmentId,
            //                  DepartmentName = dept.LongName
            //              };

            //foreach (var item in results)
            //    Console.WriteLine($"First Name: {item.FirstName,-10} Last Name: {item.LastName,-10} Annual Salary: {item.AnnualSalary,10}\tDepartment Name: {item.DepartmentName}");




            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////Grouping Operators

            ////GroupBy
            //var groupResult = from emp in employeeList
            //                      //orderby emp.DepartmentId descending
            //                  group emp by emp.DepartmentId;

            //foreach (var empGroup in groupResult)
            //{
            //    Console.WriteLine($"Department Id: {empGroup.Key}");

            //    foreach (Employee emp in empGroup)
            //    {
            //        Console.WriteLine($"\tEmployee Fullname: {emp.FirstName} {emp.LastName}");
            //    }

            //}

            ////ToLookup Operator
            ////var groupResult = employeeList.OrderBy(o => o.DepartmentId).ToLookup(e => e.DepartmentId);
            //var groupResult = employeeList.ToLookup(e => e.DepartmentId);

            //foreach (var empGroup in groupResult)
            //{
            //    Console.WriteLine($"Department Id: {empGroup.Key}");

            //    foreach (Employee emp in empGroup)
            //    {
            //        Console.WriteLine($"\tEmployee Fullname: {emp.FirstName} {emp.LastName}");
            //    }
            //}



            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// All, Any, Contains Quantifier Operators

            //// All and Any Operators
            // var annualSalaryCompare = 40000;

            //bool isTrueAll = employeeList.All(e => e.AnnualSalary > annualSalaryCompare);
            //if (isTrueAll)
            //{
            //    Console.WriteLine($"All employee annual salaries are above {annualSalaryCompare}");
            //}
            //else
            //{
            //    Console.WriteLine($"Not all employee annual salaries are above {annualSalaryCompare}");
            //}

            //bool isTrueAny = employeeList.Any(e => e.AnnualSalary > annualSalaryCompare);
            //if (isTrueAny)
            //{
            //    Console.WriteLine($"At least one employee has an annual salary above {annualSalaryCompare}");
            //}
            //else
            //{
            //    Console.WriteLine($"No employees have an annual salary above {annualSalaryCompare}");
            //}

            //// Contains Operator
            //var searchEmployee = new Employee
            //{
            //    Id = 3,
            //    FirstName = "Douglas",
            //    LastName = "Roberts",
            //    AnnualSalary = 40000.2m,
            //    IsManager = false,
            //    DepartmentId = 1
            //};

            //bool containsEmployee = employeeList.Contains(searchEmployee, new EmployeeComparer());

            //if (containsEmployee)
            //{
            //    Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was found");
            //}
            //else
            //{
            //    Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was not found");
            //}



            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //// OfType filter Operator
            //ArrayList mixedCollection = Data.GetHeterogeneousDataCollection();

            //var stringResult = from s in mixedCollection.OfType<string>()
            //                   select s;

            //var intResult = from i in mixedCollection.OfType<int>()
            //                select i;

            //foreach (var item in stringResult)
            //    Console.WriteLine(item);

            //foreach (var item in intResult)
            //    Console.WriteLine(item);

            //var employeeResults = from e in mixedCollection.OfType<Employee>()
            //                      select e;

            //foreach (var emp in employeeResults)
            //    Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");

            //var departmentResults = from d in mixedCollection.OfType<Department>()
            //                        select d;

            //foreach (var dept in departmentResults)
            //    Console.WriteLine($"{dept.Id,-5} {dept.LongName,-30} {dept.ShortName,-10}");



            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////ElementAt, ElementAtOrDefault, First, FirstOrDefault, Last, LastOrDefault, Single and SingleOrDefault Element Operators
            
            ////ElementAt, ElementAtOrDefault Operators
            //var emp = employeeList.ElementAtOrDefault(12);

            //if (emp != null)
            //{
            //    Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");
            //}
            //else
            //{
            //    Console.WriteLine("This employee record does not exist within the collection");
            //}

            ////First, FirstOrDefault, Last, LastOrDefault Operators
            //List<int> integerList = new List<int> {3,13,23,17,26,87};

            ////int result = integerList.First(i => i % 2 == 0);
            //// int result = integerList.FirstOrDefault(i => i % 2 == 0);
            //int result = integerList.LastOrDefault(i => i % 2 == 0);

            //if (result != 0)
            //{
            //    Console.WriteLine(result);
            //}
            //else
            //{
            //    Console.WriteLine("There are no even numbers in the collection");
            //}

            ////Single, SingleOrDefault Operators

            var emp = employeeList.SingleOrDefault();

            if (emp != null)
            {
                Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");
            }
            else
            {
                Console.WriteLine("This employee does not exist within the collection");
            }
            Console.ReadKey();
        }
    }

    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals([AllowNull] Employee x, [AllowNull] Employee y)
        {
            if (x.Id == y.Id && x.FirstName.ToLower() == y.FirstName.ToLower() && x.LastName.ToLower() == y.LastName.ToLower())
            {
                return true;
            }

            return false;
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}