using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExpress.Model.Model
{
    public class Product
    {
        public int Id { get; set; }
        
        public string Code { get; set; }
        public string Name { get; set; }
        public string Reorder_lavel { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }




    }
}
