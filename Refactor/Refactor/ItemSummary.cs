using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor
{
    public class ItemSummary
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public int Bonus { get; set; }
    }

    public class BillSummary
    {
        public List<ItemSummary> Items { get; set; } = new List<ItemSummary>();
        public double TotalAmount { get; set; }
        public int TotalBonus { get; set; }
    }

}
