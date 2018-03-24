using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.GBD.Entities
{
    public class InventoryItem
    {
        public InventoryItem()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public UnitOfMeasure UnitOfMeasure { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
