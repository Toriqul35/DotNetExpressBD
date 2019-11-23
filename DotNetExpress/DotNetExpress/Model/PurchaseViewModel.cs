using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DotNetExpress.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace DotNetExpress.Model
{
    public class PurchaseViewModel
    {

        public int Id { get; set; }

       


        [Required(ErrorMessage = "Can not be Empty")]
        [MaxLength(4, ErrorMessage = "Maximum Lenght is 4")]
        [MinLength(4, ErrorMessage = "Must be 4 Lenght")]
        public string InvoiceNo { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<SelectListItem> SupplierSelect { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public List<SelectListItem> ProductSelect { get; set; }
        public List<Purchase> Purchase{ get; set; }
       

    }
}