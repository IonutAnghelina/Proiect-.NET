using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Entities
{
    public class Item
    {
        public String Id { get; set; }
        public String Name { get; set; }

        public int Price { get; set; }

        public String Sport { get; set; }

        public ICollection<ItemShop> ItemShops { get; set; }
    }
}
