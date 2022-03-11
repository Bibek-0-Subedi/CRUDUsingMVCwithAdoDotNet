using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDUsingMVCwithAdoDotNet.Models
{
    public class DistrictModel
    {
        [Key]
        public int DistrictId { get; set; }
        public int StateId { get; set; }
        public string DistrictName { get; set; }
        public string DistrictNameLocal { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}