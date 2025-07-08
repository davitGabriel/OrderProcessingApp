using OrderProcessingApp.Models;
using OrderProcessingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderProcessingApp.Services
{
    public class OrderService
    {
        private readonly JsonRepository _repository;

        public OrderService(JsonRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Order> GetOrders()
        {
            var _orders = _repository.LoadData<Order>("orders.json");
            var _products = _repository.LoadData<Product>("products.json");
            var _ingredients = _repository.LoadData<Ingredient>("ingredients.json");

            var ordersList = new List<Order>();

            foreach (var order in _orders)
            {
                var orderProducts = new List<Product>();

                foreach (var product in order.Products)
                {
                    var orderProduct = _products.FirstOrDefault(p => p.Id == product.Id);
                    if (orderProduct == null) continue;
                    
                    var productIngredients = new List<Ingredient>();

                    foreach (var ingredient in orderProduct.Ingredients)
                    {
                        var productIngredient = _ingredients.FirstOrDefault(i => i.Id == ingredient.Id);
                    
                        if (productIngredient != null)
                        {
                            productIngredients.Add(productIngredient);
                        }
                    }
                    orderProduct.Ingredients = productIngredients;

                    orderProducts.Add(orderProduct);
                }
                order.Products = orderProducts;

                ordersList.Add(order);
            }

            return ordersList;
        }

        public decimal GetTotalAmountOfIngredients(List<Order> orders)
        {
            decimal totalAmountOfIngredients = 0;

            foreach (var order in orders)
            {
                if (!order.IsValid())
                    continue;

                foreach (var product in order.Products)
                {
                    foreach (var ingredient in product.Ingredients)
                    {
                        totalAmountOfIngredients += ingredient.Price;
                    }
                }
            }

            return totalAmountOfIngredients;
        }
    }
}
