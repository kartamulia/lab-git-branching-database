using Lab.GBD.Entities.Data;
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

                AddInventoryItem(dbContext);
                ReadInventoryItems(dbContext);
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

        private static void AddInventoryItem(GBDDbContext dbContext)
        {
            try
            {
                var result = dbContext.InventoryItems.Add(new Entities.InventoryItem()
                {
                    Name = "Inventory Item 1",
                    UnitOfMeasure = Entities.UnitOfMeasure.Box,
                    UnitPrice = 100
                });

                dbContext.SaveChanges();

                Console.WriteLine($"Inventory Item {result.Entity.Name} with Id: {result.Entity.Id} added.");
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
                var inventoryItems = dbContext.InventoryItems.ToList();

                Console.WriteLine();
                inventoryItems?.ForEach(x => Console.WriteLine($"Id: {x.Id}; Name: {x.Name}; UoM: {x.UnitOfMeasure}; Price: {x.UnitPrice}"));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
