using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DotNetExpress.Model.Model
{
    public class Purchase
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public string InvoiceNo { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public virtual Product Product { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpireDate { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PreviousUnit { get; set; }
        public decimal PreviousMRP { get; set; }

        public decimal MRP { get; set; }
        public string Remarks { get; set; }




    }
}
