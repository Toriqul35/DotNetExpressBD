using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetExpress.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DotNetExpress.Model
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "Code Can Not be Empty")]
        [MaxLength(4, ErrorMessage = " Code Can't be more than 4 char")]
        public string Code { get; set; }

        
        [Required(ErrorMessage = "Name Can Not be Empty")]
        [Display(Name = "Product Name:")]
        public string Name { get; set; }
       
        public string ReorderLevel { get; set; }
        public string Description { get; set; }
        public Category category { get; set; }

        public List<Product> products { get; set; }
        public List<SelectListItem> CategorySelectListItems { get; set; }

    }
}