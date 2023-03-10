using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssetsMVC1.Models
{
    public class Asset
    {

        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }

        public string typeName(Item item)
        {
            return item.Brand + " " + item.GetType().Name.ToString();
        }

        public string printDetails(Item item, Office office)
        {
            string chosenColor = "greenText";
            DateTime dateNow = DateTime.Now;
            DateTime dateLife = this.PurchaseDate.AddYears(2).AddMonths(6);
            TimeSpan diff = dateNow - dateLife;
            int res = DateTime.Compare(dateLife, dateNow);
            if (res < 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                chosenColor = "yellowText";
            }
            dateLife = this.PurchaseDate.AddYears(2).AddMonths(9);
            TimeSpan diff2 = dateNow - dateLife;
            res = DateTime.Compare(dateLife, dateNow);
            if (res < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                chosenColor = "redText";
            }
            //Console.WriteLine(item.GetType().Name.ToString().PadRight(14) + " " + item.Brand.PadRight(14) + " " +item.Model.PadRight(14) + " " + office.Name.PadRight(14) + " " + this.PurchaseDate.ToString("dd/MM/yyyy").PadRight(14) + " " + item.Price.ToString().PadRight(14) + " " + office.Currency.PadRight(10) + " " + (item.Price * office.Rate));
            //Console.WriteLine(item.GetType().Name.ToString().PadRight(14) + " " + item.Brand.PadRight(14) + " " + item.Model.PadRight(14) + " " + office.Name.PadRight(14) + " " + this.PurchaseDate.ToString("dd/MM/yyyy").PadRight(14) + " " + item.Price.ToString().PadRight(14) + " " + office.Currency.PadRight(10) + " " + (item.Price * Convert.ToDouble(office.Rate)).ToString("#.##").PadRight(17));
            //Console.ResetColor();
            return chosenColor;
        }

    }


}
