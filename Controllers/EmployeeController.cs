using CRUDUsingMVCwithAdoDotNet.Models;
using CRUDUsingMVCwithAdoDotNet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsingMVCwithAdoDotNet.Controllers
{
    public class EmployeeController : Controller
    {
        //GET: Employee/GetAllEmpDetails
        public ActionResult GetAllEmpDetails()
        {
            EmpRepository EmpRepo = new EmpRepository();
            ModelState.Clear();
            return View(EmpRepo.GetAllEmployees());
        }

        //GET: Employee/AddEmployee
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employee/AddEmployee    
        [HttpPost]
        public ActionResult AddEmployee(EmpModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpRepository EmpRepo = new EmpRepository();

                    if (EmpRepo.AddEmployee(Emp))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        //GET: Employee/EditEmpDetails/5
        public ActionResult EditEmpDetails(int id)
        {
            EmpRepository EmpRepo = new EmpRepository();

            return View(EmpRepo.GetAllEmployees().Find(Emp => Emp.Empid == id));

        }

        //POST: Employee/EditEmpDetails/5
        [HttpPost]
        public ActionResult EditEmpDetails(int id, EmpModel obj)
        {
            try
            {
                EmpRepository EmpRepo = new EmpRepository();

                EmpRepo.UpdateEmployee(obj);

                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        //GET: Employee/DeleteEmp/5
        public ActionResult DeleteEmp(int id)
        {
            try
            {
                EmpRepository EmpRepo = new EmpRepository();
                if (EmpRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";
                }
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }
        public JsonResult GetState()
        {
            EmpRepository empRepository= new EmpRepository();
            List<StateModel> st = empRepository.GetAllStates();
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDistrict(string id)
        {
            EmpRepository empRepository = new EmpRepository();
            List<DistrictModel> st = empRepository.GetAllDistricts(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetLocalUnit(string id)
        {
            EmpRepository empRepository = new EmpRepository();
            List<LocalUnitModel> st = empRepository.GetAllLocalUnitModels(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }

    }
}