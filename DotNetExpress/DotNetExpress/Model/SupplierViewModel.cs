using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetExpress.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DotNetExpress.Model
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        [Remote("CheckExist","Supplier", ErrorMessage ="The Code is exists")]
        [Required(ErrorMessage ="Please assign code")]
        [MinLength(4, ErrorMessage ="Code Must be 4 Length")]
        [MaxLength(4,ErrorMessage = "Code Must be 4 Length")]
        public String Code { get; set; }
        [Required(ErrorMessage ="Must be Assign Name")]
        [Remote("CheckExist", "Supplier", ErrorMessage = "The Code is exists")]
        public string Name { get; set; }

        public string Address { get; set; }
        [Required(ErrorMessage = "What is Email ?")]
        //[Remote("CheckExist", "Supplier", ErrorMessage = "The Code is exists")]
        public string Email { get; set; }
        [Required(ErrorMessage = "What is Cell Number ? ")]
        //[Remote("CheckExist", "Supplier", ErrorMessage = "The Code is exists")]
        public string Contact { get; set; }
        public string Contact_Person { get; set; }



        public List<Supplier> Suppliers { get; set; }


    }
}