using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reductio___Absurdum
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvilable { get; set; }
        public ProductType ProductTypedId { get; set; }

        DateTime DateStocked { get; set; }

        public int DaysOnShelf
        {
            get
            {
                TimeSpan timeOnShelf = DateTime.Now - DateStocked;
                return timeOnShelf.Days;
            }
        }
        public Product(string name, decimal price, bool isAvilable, ProductType productTypedId, DateTime dateStocked)
        {
            Name = name;
            Price = price;
            IsAvilable = isAvilable;
            ProductTypedId = productTypedId;
            DateStocked = dateStocked;
        }
    }
}
