using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetExpress.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DotNetExpress.Model
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Can not be Empty")]
        [MaxLength(4, ErrorMessage = "Maximum Lenght is 4")]
        [Display(Name = "Code : ")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please input Name ")]
        public string Name { get; set; }

        public string Address { get; set; }
        [Required(ErrorMessage = "Please input email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please fill up Contact")]
        public string Contact { get; set; }
        public string Loyolty_Point { get; set; }

        public List<Customer> Customers { get; set; }

    }
}