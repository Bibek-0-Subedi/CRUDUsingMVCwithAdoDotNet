using CRUDUsingMVCwithAdoDotNet.Models;
using CRUDUsingMVCwithAdoDotNet.Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsingMVCwithAdoDotNet.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        public ActionResult Index()
        {
            AddressRepository addressRepository = new AddressRepository();
            ModelState.Clear();
            ViewData["States"] = addressRepository.GetAllStates();
            ViewData["District"] = addressRepository.GetAllDistricts();
            ViewData["LocalUnit"] = addressRepository.GetAllLocalUnitModels();
            ViewModel viewModel = new ViewModel();
            viewModel.StateModels = GetAllStates();
            viewModel.DistrictModels = GetAllDistricts();
            viewModel.LocalUnitModels = GetAllLocalUnitModels();


            return View();
        }
    }
}