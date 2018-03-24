using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.GBD.Entities
{
    public class UnitOfMeasurement
    {
        public UnitOfMeasurement()
        {
            this.InventoryItems = new HashSet<InventoryItem>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
