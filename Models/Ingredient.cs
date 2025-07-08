using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingApp.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public override bool IsValid()
        {
            return Price > 0 &&
                   !String.IsNullOrWhiteSpace(Name);
        }
    }
}
