using crudapp_ado.net_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crudapp_ado.net_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> obj = db.GetEmployees(); 
            return View(obj);
        }

        //GET : CreateNew
        public ActionResult Create()
        {
            
            return View();
        }

        //POST : Create/Submit
        [HttpPost]

        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDBContext context = new EmployeeDBContext();
                    bool check = context.AddEmployee(emp);
                    if (check == true)
                    {
                        TempData["InsertMassage"] = "Data has been Inserted Succesfully.";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //GET : Update
        public ActionResult Edit(int id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            var row = context.GetEmployees().Find(model => model.id == id);
            return View(row);
        }

        //Update Save
        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            if (ModelState.IsValid == true)
            {
                EmployeeDBContext context = new EmployeeDBContext();
                bool check = context.UpdateEmployee(emp);
                if (check == true)
                {
                    TempData["UpdateMassage"] = "Data has been Updated Succesfully.";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        //GET : Confarm Delete ?
        public ActionResult Delete(int id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            var row = context.GetEmployees().Find(model => model.id == id);
            return View(row);
        }

        //GET : Delete
        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            bool check = context.DeleteEmployee(id); ;
            if (check == true)
            {
                TempData["DeleteMassage"] = "Data has been Deleted Succesfully.";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return View();
        }

        //GET : Details
        public ActionResult Details(int id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            var row = context.GetEmployees().Find(model => model.id == id);
            return View(row);
        }
    }
}