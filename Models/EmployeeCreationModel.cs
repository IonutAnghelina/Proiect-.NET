using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Models
{
    public class EmployeeCreationModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int Salary { get; set; }

        public DateTime HireDate { get; set; }

        public string ShopId { get; set; }
    }
}
