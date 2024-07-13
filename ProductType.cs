using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reductio___Absurdum
{
    public class ProductType
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ProductType(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
