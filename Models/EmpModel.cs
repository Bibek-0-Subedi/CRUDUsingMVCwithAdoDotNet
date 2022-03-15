using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDUsingMVCwithAdoDotNet.Models
{
    public class EmpModel
    {
        [Key]
        [Display(Name = "ID")]
        public int Empid { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "State field is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "District field is required")]
        [Range(1,int.MaxValue, ErrorMessage = "You must select a district")]
        public string District { get; set; }

        [Required(ErrorMessage = "LocalUnit field is required")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a LocalUnit")]
        public string LocalUnit { get; set; }

        public List<StateModel> StateModel { get; set; }
        public List<DistrictModel> DistrictModel { get; set; }
        public List<LocalUnitModel> LocalUnitModel { get; set; }
    }


}