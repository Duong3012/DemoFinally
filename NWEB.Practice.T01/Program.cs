using NWEB.Practice.T01.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWEB.Practice.T01
{
    class Program
    {
        static void Main(string[] args)
        {
            FlowerShopDbContext db = new FlowerShopDbContext();
            var result = db.Flowers.ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.FlowerName}-{item.Price}-{item.Description}");
            }

            Console.ReadLine();
        }
    }
}
