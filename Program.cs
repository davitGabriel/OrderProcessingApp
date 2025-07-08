using OrderProcessingApp.Models;
using OrderProcessingApp.Repositories;
using OrderProcessingApp.Services;

var repository = new JsonRepository();
var orderService = new OrderService(repository);
var orders = orderService.GetOrders();
var totalAmountOfIngredients = orderService.GetTotalAmountOfIngredients(orders.ToList());

DisplayValidOrders(orders);

Console.WriteLine($"\nAmount of ingredients required: { totalAmountOfIngredients }");

Console.ReadLine();

static void DisplayValidOrders(IEnumerable<Order> orders)
{
    Console.WriteLine("=====Valid Orders Summary=====");

    var invalidOrders = new List<Order>();

    foreach (var order in orders)
    {
        if (!order.IsValid())
            continue;

        Console.WriteLine($"\nOrder ID: {order.Id}, Created At: {order.CreatedAt}, Delivery At: {order.DeliveryAt}, Total Price: {order.TotalPrice}");
        foreach (var product in order.Products)
        {
            Console.WriteLine($"\tProduct Name: {product.Name}, Price: {product.Price}");
            foreach (var ingredient in product.Ingredients)
            {
                Console.WriteLine($"\t\tIngredient Name: {ingredient.Name}, Price: {ingredient.Price}");
            }
        }
    }
}