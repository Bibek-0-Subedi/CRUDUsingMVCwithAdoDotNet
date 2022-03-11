using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDUsingMVCwithAdoDotNet.Models
{
    public class StateModel
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateNameLocal { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}