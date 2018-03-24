using Lab.GBD.Entities.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.GBD.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new GBDDbContext();

            try
            {
                //AddUnitOfMeasurement(dbContext);
                //AddInventoryItem(dbContext);
                ReadInventoryItems(dbContext);
                ReadUnitOfMeasurements(dbContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (dbContext != null) dbContext.Dispose();
            }

            Console.ReadLine();
        }

        private static void AddUnitOfMeasurement(GBDDbContext dbContext)
        {
            try
            {
                var result = dbContext.UnitOfMeasurements.Add(new Entities.UnitOfMeasurement()
                {
                    Name = "Box"
                });

                dbContext.SaveChanges();

                Console.WriteLine();
                Console.WriteLine($"Unit of measurement Id: {result.Entity.Id} Name: {result.Entity.Name} added.");

            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void AddInventoryItem(GBDDbContext dbContext)
        {
            try
            {
                var boxUoM = dbContext.UnitOfMeasurements.FirstOrDefault(x => x.Name == "Box");
                if (boxUoM != null)
                {
                    var result = dbContext.InventoryItems.Add(new Entities.InventoryItem()
                    {
                        Name = "Inventory Item 1",
                        UnitOfMeasurementId = boxUoM.Id,
                        UnitPrice = 100
                    });

                    dbContext.SaveChanges();
                    Console.WriteLine($"Inventory Item {result.Entity.Name} with Id: {result.Entity.Id} added.");
                }
                else
                {
                    Console.WriteLine("None Inventory Item added.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void ReadInventoryItems(GBDDbContext dbContext)
        {
            try
            {
                var inventoryItems = dbContext.InventoryItems
                    .Include(x => x.UnitOfMeasurement)
                    .ToList();

                Console.WriteLine();
                Console.WriteLine("Read inventory items:");
                inventoryItems?.ForEach(x => Console.WriteLine($"Id: {x.Id}; Name: {x.Name}; UoM: {x.UnitOfMeasurement.Name}; Price: {x.UnitPrice}"));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void ReadUnitOfMeasurements(GBDDbContext dbContext)
        {
            try
            {
                var uoms = dbContext.UnitOfMeasurements
                    .Include(x => x.InventoryItems)
                    .ToList();

                Console.WriteLine();
                Console.WriteLine("Read unit of measurements:");
                uoms.ForEach(uom =>
                {
                    Console.WriteLine($"Uom Id: {uom.Id}; Name: {uom.Name}");
                    Console.WriteLine($"UoM {uom.Name} inventory items:");
                    uom.InventoryItems?.ToList().ForEach(inventoryItem =>
                    {
                        Console.WriteLine($"Inventory Item Id: {inventoryItem.Id}; Name: {inventoryItem.Name}");
                    });
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
