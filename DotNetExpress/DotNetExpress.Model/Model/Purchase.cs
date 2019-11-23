using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpress.Model.Model
{
    public class Purchase
    {
        public int Id { get; set; }

        public string InvoiceNo { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
      
        public virtual Product Product { get; set; }

    }
}
