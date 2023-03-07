using CRUD_Empleado.Models;
using CRUD_Empleado.Repository;
using CRUD_Empleado.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_Empleado.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee employee;

        public HomeController(IEmployee employee)
        {
            this.employee = employee;
        }

        public IActionResult Index()
        {
            try
            {
                var Getempresult = employee.GetEmployee().Result;
                ViewBag.Employee = Getempresult;
                return View();
            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee empmodel)
        {
            if (ModelState.IsValid)
            {
                employee.CreateEmployee(empmodel);
            }
            ViewBag.message = "Data Saved Successfully..";

            ModelState.Clear();
            return View();
        }

        public IActionResult Edit(int id)
        {
            EmployeeViewmodel empview = new EmployeeViewmodel()
            {
                viewEmployee = employee.GetEmployeeById(id)
            };
            return View(empview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewmodel viewEmployee)
        {
            Employee empmodel = new Employee()
            {
                id = viewEmployee.id,
                firstName = viewEmployee.firstName,
                lastName = viewEmployee.lastName,
                job = viewEmployee.job,
                salary = viewEmployee.salary,
                hiredate = viewEmployee.hiredate
            };
            var result = employee.UpdateEmployee(empmodel);
            ModelState.Clear();
            return View();
        }

        public IActionResult Delete(int id)
        {
            EmployeeViewmodel empview = new EmployeeViewmodel()
            {
                viewEmployee = employee.GetEmployeeById(id)
            };
            return View(empview);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(EmployeeViewmodel viewmodel)
        {
            var result =  employee.DeleteEmployee(viewmodel.id);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}