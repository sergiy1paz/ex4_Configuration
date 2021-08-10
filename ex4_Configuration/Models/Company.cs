using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex4_Configuration.Models
{
    public class Company
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public int Employees { get; set; }

        public override string ToString()
        {
            return $"Company title = { Title }\n" +
                $"Address = { Address }\n" +
                $"Number of employees = { Employees }\n";
        }
    }
}
