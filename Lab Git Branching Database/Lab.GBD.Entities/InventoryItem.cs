﻿using System;
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

        public int UnitOfMeasurementId { get; set; }

        public UnitOfMeasurement UnitOfMeasurement { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
