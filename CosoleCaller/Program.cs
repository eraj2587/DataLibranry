using System;
using DataLibrary;

namespace CosoleCaller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DataAccessLayer dal = new DataAccessLayer();

            Employee emp = new Employee();

            emp.Email = "jeevan@gmail.com";
            emp.Employeeid = 070;
            emp.Name = "jeevan ";
            emp.Salary = 15000;
            dal.AddEmployee(emp);


            var employees = dal.GetAllEmployees();
            Console.WriteLine("AllEmployees");
            //header
            Console.WriteLine("Id\tEmailit\tName\tSalary");
            //data
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Employeeid}\t{employee.Email}\t\t{employee.Name}\t{employee.Salary}");
            }
            Console.ReadKey();
        }
    }
}
