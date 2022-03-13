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
            var dt = addressRepository.GetAllStates();
            var dr = addressRepository.GetAllDistricts();
            var dl = addressRepository.GetAllLocalUnitModels();

            ViewModel VM = new ViewModel();
            //foreach (var d in dt)
            //{
            //    StateModel SM = new StateModel();




            //}

            VM.StateModel = dt;
            VM.DistrictModel = dr;
            VM.LocalUnitModel = dl;

            ModelState.Clear();
            return View(VM);
        }

        public ActionResult GetState()
        {
            AddressRepository addressRepository = new AddressRepository();
            ModelState.Clear();
            return RedirectToAction("Index",addressRepository.GetAllStates());
        }
        public ActionResult GetDistrict()
        {
            AddressRepository addressRepository = new AddressRepository();
            ModelState.Clear();
            return View(addressRepository.GetAllDistricts());
        }
        public ActionResult GetLocalUnit()
        {
            AddressRepository addressRepository = new AddressRepository();
            ModelState.Clear();
            return View(addressRepository.GetAllLocalUnitModels());
        }
    }
}