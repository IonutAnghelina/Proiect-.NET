using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Entities
{
    public class Manager
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


        //public string ShopId { get; set; }


        public Shop Shop { get; set; }
    }
}
