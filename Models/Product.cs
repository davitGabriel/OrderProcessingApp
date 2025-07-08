using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingApp.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public override bool IsValid()
        {
            return Price > 0 &&
                   Price > Ingredients.Sum(i => i.Price) &&
                   Ingredients.Count > 0 &&
                   Ingredients.Count <= 5 &&
                   !String.IsNullOrWhiteSpace(Name) &&
                   Ingredients.All(i => i.IsValid());
        }
    }
}
