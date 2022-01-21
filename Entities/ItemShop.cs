using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Entities
{
    public class ItemShop
    {
        public String ItemId { get; set; }
        public String ShopId { get; set; }

        public Item Item { get; set; }

        public Shop Shop { get; set; }

        public int Quantity { get; set; }
    }
}
