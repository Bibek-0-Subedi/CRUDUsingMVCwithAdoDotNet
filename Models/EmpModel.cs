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

        [Required(ErrorMessage = "City field is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address field is required")]
        public string Address { get; set; }
    }

}