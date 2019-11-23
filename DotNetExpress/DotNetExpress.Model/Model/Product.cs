using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpress.Model.Model
{
    public class Product
    {

        public Product()
        {
            ProductId = new List<Purchase>();
        }
        public int Id { get; set; }
        
        public string Code { get; set; }
        public string Name { get; set; }
        public string Reorder_lavel { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<Purchase> ProductId { get; set; }
    }
}

