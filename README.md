# Order Processing Console Application

This is a simple .NET console application that processes data from JSON files representing orders, products, and ingredients. The application performs validation, filters out invalid data, and calculates the total required ingredients.

## 📁 Files Used

- `orders.json`
- `products.json`
- `ingredients.json`

## 📦 Models

There are three main models:

- **Order** – Contains a list of products, calculates product quantity and total price for order.
- **Product** – Has a name, price, and up to 5 ingredients.
- **Ingredient** – Must have a name and a price greater than zero.

## ✅ Validation Rules

### Ingredient
- Must have a non-empty name.
- Must have a price > 0.

### Product
- Must have a non-empty name.
- Price must be greater than the total cost of its ingredients.
- Can have up to 5 ingredients.

### Order
- Must contain at least one product.
- `CreatedAt` must be less than `DeliveryAt`.
- If **any** product or ingredient inside the order is invalid, the **entire order is considered invalid**.

## 🔄 Application Flow

1. The application loads the data from the three JSON files.
2. Combines them into a single collection of `Order` objects.
3. Iterates through each order and checks for validity.
4. Valid orders are printed to the console.
5. At the end of the run, the total required quantity of each ingredient (across all valid orders) is displayed.
