// See https://aka.ms/new-console-template for more information

using BaristaMatic.Models;
using System.Text.RegularExpressions;

// Main code
string? choice;
bool quite = false;

// Initialize inventory and menu
Inventory inventory = new();
Menu menu = new(inventory);
inventory.Display();
menu.Display();

// Loop until quite (Q/q)
do
{
    choice = Console.ReadLine();

    if (string.IsNullOrEmpty(choice))
        continue;
    else
        choice = Regex.Replace(choice, @"\s+", "");

    switch (choice)
    {
        case "1":
        case "2":
        case "3":
        case "4":  
        case "5":
        case "6":
            menu.MakeDrink(Int32.Parse(choice) - 1);
            break;
        case "R":
        case "r":
            inventory.Restock();
            break;
        case "Q":
        case "q":
            quite = true;
            break;
        default:
            Console.WriteLine(string.Format("Invalid selection:: {0}", choice));
            break;
    }
    inventory.Display();
    menu.Display();
} while (!quite);
