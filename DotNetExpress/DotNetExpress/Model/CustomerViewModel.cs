﻿using System;
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

        [Remote("CheckExist", "Customer", ErrorMessage = "The Code is exists")]
        [Required(ErrorMessage = "Can not be Empty")]
        [MaxLength(4, ErrorMessage = "Maximum Lenght is 4")]
        [MinLength(4, ErrorMessage = "Must be 4 Lenght")]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please input Name ")]
        
        public string Name { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("CheckExist", "Customer", ErrorMessage = "The Email is exists")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please fill up Contact")]
        [Remote("CheckExist", "Customer", ErrorMessage = "The Contact is exists")]
        public string Contact { get; set; }

        public string Loyolty_Point { get; set; }
        public List<Customer> Customers { get; set; }

    }
}