using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly DataAccessLayer dal;
        public EmployeeController()
        {
            dal = new DataAccessLayer();
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var allEmployees = dal.GetAllEmployees();
            List<EmployeeModel> employeeModel = new List<EmployeeModel>();
            allEmployees.ForEach(employee =>
            {
                employeeModel.Add(new EmployeeModel
                {
                    Email = employee.Email,
                    Employeeid = employee.Employeeid,
                    Name = employee.Name,
                    Salary = employee.Salary
                });
            });

            return View(employeeModel);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int employeeId)
        {
            var allEmployees = dal.GetAllEmployees();
            //LINQ queries
            var employeeDetails = allEmployees.Where(x => x.Employeeid == employeeId).FirstOrDefault();

            if (employeeDetails != null)
            {
                var employeeDbModel = new EmployeeModel
                {
                    Email = employeeDetails.Email,
                    Salary = employeeDetails.Salary,
                    Name = employeeDetails.Name
                };
                return View(employeeDbModel);
            }
            
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var employeeId = new Random().Next(1000);
                var newEmployeeModel = new EmployeeModel
                {
                    Employeeid = employeeId,
                    Email = collection.FirstOrDefault(x=>x.Key=="Email").Value,
                    Name = collection.FirstOrDefault(x => x.Key == "Name").Value,
                    Salary =Convert.ToInt32(collection.FirstOrDefault(x => x.Key == "Salary").Value)
                };

                var dbEmployeeModel = new Employee()
                {
                    Employeeid = newEmployeeModel.Employeeid,
                    Email = newEmployeeModel.Email,
                    Name = newEmployeeModel.Name,
                    Salary = newEmployeeModel.Salary
                };

                dal.AddEmployee(dbEmployeeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
