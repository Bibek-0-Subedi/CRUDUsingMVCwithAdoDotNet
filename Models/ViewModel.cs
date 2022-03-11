using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDUsingMVCwithAdoDotNet.Models
{
    public class ViewModel
    {
        public IEnumerable<StateModel> StateModels { get; set; }
        public IEnumerable<DistrictModel> DistrictModels { get; set; }
        public IEnumerable<LocalUnitModel> LocalUnitModels { get; set; }
    }
}