using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetExpress.Model;
using DotNetExpress.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DotNetExpress.Model
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Remote("CheckExist", "Product", ErrorMessage = "The Code is exists")]
        [Required(ErrorMessage = "Can not be Empty")]
        [MaxLength(4, ErrorMessage = "Maximum Lenght is 4")]
        [MinLength(4,ErrorMessage ="Must be 4 lenght")]
        [Display(Name = "Code ")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please input Name ")]
        [Remote("CheckExist", "Product", ErrorMessage = "The Name is exists")]
        public string Name { get; set; }

        public List<Category> Categories { get; set; }

    }
}