using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDUsingMVCwithAdoDotNet.Models
{
    public class LocalUnitModel
    {
        [Key]
        public int LocalUnitId { get; set; }
        public int DistrictId { get; set; }
        public string LocalUnitName { get; set; }
        public string LocalUnitNameLocal { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}