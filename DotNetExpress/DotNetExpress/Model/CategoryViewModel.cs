using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetExpress.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DotNetExpress.Model
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Can not be Empty")]
        [MaxLength(4, ErrorMessage = "Maximum Lenght is 4")]
        [Display(Name = "Code : ")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please input Name ")]
        public string Name { get; set; }

        public List<Category> Categories { get; set; }
    }
}