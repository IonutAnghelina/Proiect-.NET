using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Models
{
    public class ShopCreationModel
    {
        public string Id { get; set; }

        public string ManagerId { get; set; }

        public string City { get; set; }

        public DateTime OpenningDay { get; set; }

        public int NoEmployees { get; set; }

    }
}
