using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DotNetExpress.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace DotNetExpress.Model
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        

        [Required(ErrorMessage = "Can not be Empty")]
        [MaxLength(6, ErrorMessage = "Maximum Lenght is 6")]
        [MinLength(4, ErrorMessage = "Must be 4 Lenght")]
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Required(ErrorMessage = "what is product Name ?")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Should be assign oder lavel")]
        public string Reorder_lavel { get; set; }
        [Required(ErrorMessage = "Please write your Opines")]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
        public List<SelectListItem> CategorySelectListItems { get; set; }


    }
}