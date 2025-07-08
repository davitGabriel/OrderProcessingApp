using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingApp.Models
{
    public class Order : BaseEntity
    {
        // Quantity of products in order
        public int ProductQuantity
        {
            get { return Products?.Count ?? 0; }
        }

        // Total price of order
        public decimal TotalPrice
        {
            get { return Products?.Sum(p => p.Price) ?? 0; }
        }

        public DateTime CreatedAt { get; set; }

        public DateTime DeliveryAt { get; set; }

        public string DeliveryAddress { get; set; }

        public List<Product> Products { get; set; }

        public override bool IsValid()
        {
            return ProductQuantity > 0 &&
                   CreatedAt < DeliveryAt &&
                   !String.IsNullOrWhiteSpace(DeliveryAddress) &&
                   Products.All(p => p.IsValid());
        }
    }
}
