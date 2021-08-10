using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex4_Configuration.Models
{
    public class User
    {
        public string Name { get; init; }
        public int Age { get; init; }
        public decimal Salary { get; set; }
        public Company Company { get; set; }
        public List<string> Languages { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Name = { Name }\n" +
                $"Age = { Age }\n" +
                $"Salary = { Salary }\n");


            if (Languages is not null)
            {
                sb.Append("Languages: \n");
                foreach (var lang in Languages)
                {
                    sb.Append($"\t{lang}\n");
                }
            }

            if (Company is not null)
            {
                sb.Append(Company.ToString());
            }

            return sb.ToString();
        }
    }
}
