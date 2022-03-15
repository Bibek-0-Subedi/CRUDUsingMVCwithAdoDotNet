using CRUDUsingMVCwithAdoDotNet.Models;
using CRUDUsingMVCwithAdoDotNet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsingMVCwithAdoDotNet.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public string status;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        /*public ActionResult Index(string username)
        {
            EmpRepository empRepository = new EmpRepository();
            User user = new User();
            user = empRepository.GetUserById(username);
            user.

        }*/
    }
}