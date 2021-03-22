using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLibrary
{
    public class DataAccessLayer
    {
        public string connectionstring = @"Server=(LocalDb)\MSSQLLocalDB;Database=EmployeeDB;Trusted_Connection=True;";

        //GetallEmployees
        public List<Employee> GetAllEmployees()
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Employee";
            cmd.Connection = connection;

            var reader = cmd.ExecuteReader();

            List<Employee> resultEmployees = new List<Employee>();
            while (reader.Read())
            {
                resultEmployees.Add(new Employee
                {
                    Employeeid = Convert.ToInt32(reader["EmployeeId"]),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    Salary = Convert.ToInt32(reader["Salary"]),
                });

            }
            reader.Close();
            return resultEmployees;
        }

        //GetEmployeeById
        public Employee GetAllEmployeeById(int employeeid)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from Employee where employeeid={employeeid}";
            cmd.Connection = connection;

            var reader = cmd.ExecuteReader();

            Employee resultEmployee = new Employee();
            while (reader.Read())
            {

                resultEmployee = new Employee
                {
                    Employeeid = Convert.ToInt32(reader["EmployeeId"]),
                    Name = reader["Name"].ToString(),
                    Email = reader["EmailId"].ToString(),
                    Salary = Convert.ToInt32(reader["Salary"]),
                };
            }
            reader.Close();
            return resultEmployee;
        }       

        //AddEmployee
        public void AddEmployee(Employee emp)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $" insert into Employee(Employeeid, Name,Email, Salary)" +
                                $"Values({emp.Employeeid}, '{emp.Name}', '{emp.Email}', {emp.Salary})";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }

        //UpdateEmployee
        public void UpdateEmployee(Employee emp)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"update Employee set Salary={emp.Salary}, Name='{emp.Name}', Email='{emp.Email}' where employeeid={emp.Employeeid}";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }

        //DeleteEmployeedById
        public void DeleteEmployee(int employeeId)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete employee where employeeid={employeeId}";
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }
    }

    public class Employee
    {
        public int Employeeid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
    }

    /*
     
    //create database
    create database EmployeeDB

    //create table
    Create table Employee
    (
     EmployeeId int,
     Name varchar(50),
     Email varchar(50),
     Salary int
    )

     //select rows
     select * from Employee
     where employeeid=123

    //insert new employee
     insert into Employee(Employeeid, Name,Email, Salary)
     Values(345,'Jeevan','jeevanbalwalekar@gmail.com',25000)

    //update employee
    update Employee set Salary=30000 where employeeid=123

    //Delete employee
    delete Employee where employeeid=123
    */
}