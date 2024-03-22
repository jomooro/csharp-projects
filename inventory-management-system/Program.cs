using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static Dictionary<string, int> inventory = new Dictionary<string, int>();

    static void Main(string[] args)
    {
        LoadInventoryFromFile("inventory.txt");

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("***** Welcome to Inventory Management System *****");
            Console.WriteLine();
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Quantity");
            Console.WriteLine("3. Buy");
            Console.WriteLine("4. Sell");
            Console.WriteLine("5. View Inventory");
            Console.WriteLine("6. Save Inventory");
            Console.WriteLine("7. Exit");
            Console.WriteLine();
            Console.Write("Select an option: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    UpdateQuantity();
                    break;
                case 3:
                    Buy();
                    break;
                case 4:
                    Sell();
                    break;
                case 5:
                    ViewInventory();
                    break;
                case 6:
                    SaveInventoryToFile("inventory.txt");
                    Console.WriteLine("Inventory saved successfully.");
                    break;
                case 7:
                    Console.WriteLine("Thank you for using the Inventory Management System.");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
    }

    static void AddProduct()
    {
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine()?.Trim() ?? "";

        if (string.IsNullOrEmpty(productName))
        {
            Console.WriteLine("Product name cannot be empty.");
            return;
        }

        if (inventory.ContainsKey(productName))
        {
            Console.WriteLine("Product already exists in inventory.");
            return;
        }

        Console.Write("Enter initial quantity: ");
        int quantity;
        if (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }

        inventory.Add(productName, quantity);
        Console.WriteLine("Product added to inventory.");
    }

    static void UpdateQuantity()
    {
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine()?.Trim() ?? "";

        if (!inventory.ContainsKey(productName))
        {
            Console.WriteLine("Product does not exist in inventory.");
            return;
        }

        Console.Write("Enter new quantity: ");
        int newQuantity;
        if (!int.TryParse(Console.ReadLine(), out newQuantity) || newQuantity < 0)
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }

        inventory[productName] = newQuantity;
        Console.WriteLine("Quantity updated successfully.");
    }

    static void Buy()
    {
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine()?.Trim() ?? "";

        if (!inventory.ContainsKey(productName))
        {
            Console.WriteLine("Product does not exist in inventory.");
            return;
        }

        Console.Write("Enter quantity to buy: ");
        int quantity;
        if (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }

        inventory[productName] += quantity;
        Console.WriteLine($"{quantity} units of {productName} bought successfully.");
    }

    static void Sell()
    {
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine()?.Trim() ?? "";

        if (!inventory.ContainsKey(productName))
        {
            Console.WriteLine("Product does not exist in inventory.");
            return;
        }

        Console.Write("Enter quantity to sell: ");
        int quantity;
        if (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }

        if (inventory[productName] < quantity)
        {
            Console.WriteLine("Not enough stock to sell.");
            return;
        }

        inventory[productName] -= quantity;
        Console.WriteLine($"{quantity} units of {productName} sold successfully.");
    }

    static void ViewInventory()
    {
        Console.WriteLine("\nCurrent Inventory:");
        foreach (var item in inventory)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    static void LoadInventoryFromFile(string fileName)
    {
        if (!File.Exists(fileName))
            return;

        string[] lines = File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 2)
            {
                string productName = parts[0].Trim();
                int quantity;
                if (int.TryParse(parts[1], out quantity))
                {
                    inventory[productName] = quantity;
                }
            }
        }
    }

    static void SaveInventoryToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var item in inventory)
            {
                writer.WriteLine($"{item.Key},{item.Value}");
            }
        }
    }
}
