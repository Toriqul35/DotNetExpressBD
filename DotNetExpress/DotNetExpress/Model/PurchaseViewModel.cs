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


        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

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
        [Display(Name = "Manufactured Date")]
        [DataType(DataType.Date)]
        public DateTime? ManufactureDate { get; set; }

        [Display(Name = "Expire Date")]
        [DataType(DataType.Date)]
        public DateTime? ExpireDate { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Can not be Empty")]
        public decimal Quantity { get; set; }

        [Display(Name = "Unit Price(Tk)")]
        [Required(ErrorMessage = "Can not be Empty")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Total Price (Tk)")]
        [Required(ErrorMessage = "Can not be Empty")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Previous Unit (Tk)")]
        [Required(ErrorMessage = "Can not be Empty")]
        public decimal PreviousUnit { get; set; }

        [Display(Name = "Previous MRP(Tk)")]
        public decimal PreviousMRP { get; set; }

        [Display(Name = "Total MRP(Tk)")]
        [Required(ErrorMessage = "Can not be Empty")]

        public decimal MRP { get; set; }

        [Display(Name = "Remarks")]
        [Required(ErrorMessage = "Can not be Empty")]
        public string Remarks { get; set; }
        public List<Purchase> Purchase{ get; set; }
       

    }
}