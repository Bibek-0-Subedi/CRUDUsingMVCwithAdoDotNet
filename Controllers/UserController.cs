using CRUDUsingMVCwithAdoDotNet.Models;
using CRUDUsingMVCwithAdoDotNet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsingMVCwithAdoDotNet.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            EmpRepository empRepository = new EmpRepository();
            ModelState.Clear();
            return View(empRepository.GetAllUser());
        }

        //GET: Employee/AddEmployee
        public ActionResult Create()
        {
            EmpRepository EmpRepo = new EmpRepository();
            return View();
        }

        // POST: Employee/AddEmployee    
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpRepository empRepository = new EmpRepository();

                    if (empRepository.AddUser(user))
                    {
                        ViewBag.Message = "User details added successfully";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}