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


        public CategoryViewModel()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }


        [Required(ErrorMessage = "Code Can Not be Empty")]
        [MaxLength(4, ErrorMessage = " Code Can't be more than 4 char")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name Can Not be Empty")]
        [Display(Name = "Product Name:")]
        public string Name { get; set; }
      

        public virtual List<Product> Products { get; set; } //Lazy Loading.
        public List<Category> categories { get;  set; }
    }
}