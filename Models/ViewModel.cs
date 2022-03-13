using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDUsingMVCwithAdoDotNet.Models
{
    public class ViewModel
    {
        public List<StateModel> StateModel { get; set; }
        public List<DistrictModel> DistrictModel { get; set; }
        public List<LocalUnitModel> LocalUnitModel { get; set; }
    }
    
}