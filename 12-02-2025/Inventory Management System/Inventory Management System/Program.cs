using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Inventory_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            while (true)
            {
                Console.WriteLine("\nInventory Management System");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Update Quantity");
                Console.WriteLine("4. Search for an item based on Item Id or Name");
                Console.WriteLine("5. Display Inventory");
                Console.WriteLine("6. Sort by Name");
                Console.WriteLine("7. Sort by Price");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Item Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Item ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Price: ");
                        double price = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Where do you want to add item? \n1. At the beginning \n2. At the end \n3. At a specific Position");
                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                inventory.AddItemAtBeginning(name, id, quantity, price);
                                break;
                            case 2:
                                inventory.AddItemAtEnd(name, id, quantity, price);
                                break;
                            case 3:
                                Console.Write("Enter the position where you want to add item:");
                                int position = Convert.ToInt32(Console.ReadLine());
                                inventory.AddAtASpecificPosition(name, id, quantity, price, position);
                                break;
                        }
                        break;
                    case 2:
                        Console.Write("Enter Item ID to remove: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        inventory.RemoveBasedOnID(id);
                        break;
                    case 3:
                        Console.Write("Enter Item ID to update quantity: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new quantity: ");
                        quantity = Convert.ToInt32(Console.ReadLine());
                        inventory.UpdateQuantity(id, quantity);
                        break;
                    case 4:
                        Console.WriteLine("Search By \n1.Item Id \n2.Item Name?");
                        int search = Convert.ToInt32(Console.ReadLine());
                        switch (search)
                        {
                            case 1:
                                Console.WriteLine("Enter Item id:");
                                int searchId = Convert.ToInt32(Console.ReadLine());
                                inventory.SearchItemByID(searchId); break;
                            case 2:
                                Console.WriteLine("Enter Item Price:");
                                string searchName = Console.ReadLine();
                                inventory.SearchItemByName(searchName);
                                break;
                            default:
                                Console.WriteLine("Invalid option choosen");
                                break;
                        }
                        break;
                    case 5:
                        inventory.DisplayTotalValue();
                        break;
                    case 6:
                        Console.Write("Sort by Name (1-Ascending, 0-Descending): ");
                        bool nameAscending = Convert.ToInt32(Console.ReadLine()) == 1;
                        inventory.SortByItemName(nameAscending);
                        Console.WriteLine("Inventory sorted by Name.");
                        break;
                    case 7:
                        Console.Write("Sort by Price (1-Ascending, 0-Descending): ");
                        bool priceAscending = Convert.ToInt32(Console.ReadLine()) == 1;
                        inventory.SortByPrice(priceAscending);
                        Console.WriteLine("Inventory sorted by Price.");
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        class Item
        {
            public string ItemName { get; set; }
            public int ItemId { get; set; }
            public int Quantity { get; set; }
            public double Price { get; set; }
            public Item Next;

            public Item(string itemName, int itemId, int quantity, double price)
            {
                ItemName = itemName;
                ItemId = itemId;
                Quantity = quantity;
                Price = price;
                Next = null;
            }
        }
        class Inventory
        {
            private Item head = null;
            //Add an item at the beginning
            public void AddItemAtBeginning(string itemName, int itemId, int quantity, double price)
            {
                Item newItem = new Item(itemName, itemId, quantity, price);
                newItem.Next = head;
                head = newItem;
                Console.WriteLine("Next Item Added At The Beginning");
            }
            //Add an item at the end
            public void AddItemAtEnd(string itemName, int itemId, int quantity, double price)
            {
                Item newItem = new Item(itemName, itemId, quantity, price);
                if (head == null)
                {
                    head = newItem;
                    return;
                }
                Item temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newItem;
            }

            //Add a new Item at a specific position
            public void AddAtASpecificPosition(string itemName, int itemId, int quantity, double price, int position)
            {
                Item newItem = new Item(itemName, itemId, quantity, price);
                if (position < 1)
                {
                    Console.WriteLine("Invalid Position entered");
                    return;
                }
                if (position == 1)
                {
                    AddItemAtBeginning(itemName, itemId, quantity, price);
                    return;
                }
                Item temp = head;
                for (int i = 1; i < position - 1 && temp != null; i++)
                {
                    temp = temp.Next;
                }
                if (temp == null)
                {
                    Console.WriteLine("Position Does Not Exist");
                    return;
                }
                newItem.Next = temp.Next;
                temp.Next = newItem;
                Console.WriteLine("Item Added at specific position");
            }
            //Remove an item based on Item ID
            public void RemoveBasedOnID(int itemId)
            {
                if (head == null)
                {
                    Console.WriteLine("Inventory is empty");
                    return;
                }
                if (head.ItemId == itemId)
                {
                    head = head.Next;
                    Console.WriteLine("Item removed");
                    return;
                }
                Item current = head;
                Item previous = null;
                while (current != null && current.ItemId != itemId)
                {
                    previous = current;
                    current = current.Next;
                }
                if (current == null)
                {
                    Console.WriteLine("Invalid Item Id Entered");
                    return;
                }
                previous.Next = current.Next;
                Console.WriteLine($"Item {itemId} Deleted From Inventory");
            }

            //Update the quantity of an item by Item ID
            public void UpdateQuantity(int itemId, int quantity)
            {
                Item temp = head;
                while (temp != null)
                {
                    if (temp.ItemId == itemId)
                    {
                        temp.Quantity = quantity;
                        Console.WriteLine("Item Quantity Updated");
                        return;
                    }
                    temp = temp.Next;
                }
                if (temp == null)
                {
                    Console.WriteLine("Invalid Item Id Added");
                    return;
                }
            }
            //Search for an item based on Item ID 
            public void SearchItemByID(int itemId)
            {
                if (head == null)
                {
                    Console.WriteLine("Inventory is empty");
                    return;
                }
                Item temp = head;
                while (temp != null)
                {
                    if (temp.ItemId == itemId)
                    {
                        Console.WriteLine($"Item Name : {temp.ItemName} \nItem Id : {temp.ItemId} \nQuantity : {temp.Quantity} \nPrice : {temp.Price}INR");
                        return;
                    }
                    temp = temp.Next;
                }
                if (temp == null)
                {
                    Console.WriteLine("Invalid Item Id Added");
                    return;
                }
            }
            //Search for an item based on Item Name
            public void SearchItemByName(string itemName)
            {
                if (head == null)
                {
                    Console.WriteLine("Inventory is empty");
                    return;
                }
                Item temp = head;
                while (temp != null)
                {
                    if (temp.ItemName == itemName)
                    {
                        Console.WriteLine($"Item Name : {temp.ItemName} \nItem Id : {temp.ItemId} \nQuantity : {temp.Quantity} \nPrice : {temp.Price}INR");
                        return;
                    }
                    temp = temp.Next;
                }
                if (temp == null)
                {
                    Console.WriteLine("Invalid Item Id Added");
                    return;
                }
            }
            //Calculate and display the total value of inventory
            public void DisplayTotalValue()
            {

                if (head == null)
                {
                    Console.WriteLine("Inventory is empty");
                    return;
                }
                Item temp = head;
                double total = 0;
                while (temp != null)
                {
                    total += (temp.Price * temp.Quantity);
                    temp= temp.Next;
                }
                Console.WriteLine($"Total Value of Inventory is {total}INR");
            }
            //Sort the inventory based on Item Name in ascending or descending order
            public void SortByItemName(bool ascending = true)
            {
                if (head == null) { return; }
                bool swapped;
                do
                {
                    swapped = false;
                    Item current = head;
                    while (current.Next != null)
                    {
                        if ((ascending && string.Compare(current.ItemName, current.Next.ItemName, StringComparison.OrdinalIgnoreCase) > 0) ||
                            (!ascending && string.Compare(current.ItemName, current.Next.ItemName, StringComparison.OrdinalIgnoreCase) < 0))
                        {
                            Swap(current, current.Next);
                            swapped = true;
                        }
                        current = current.Next;

                    }
                }
                while (swapped);
            }
            //Sort the inventory based on Price in ascending or descending order
            public void SortByPrice(bool ascending = true)
            {
                if (head == null) { return; }
                bool swapped;
                do
                {
                    swapped = false;
                    Item current = head;
                    while (current.Next != null)
                    {
                        if ((ascending && current.Price > current.Next.Price )||
                            (!ascending && current.Price < current.Next.Price))
                        {
                            Swap(current, current.Next);
                            swapped = true;
                        }
                        current = current.Next;

                    }
                }
                while (swapped);
            }

            public void Swap(Item a, Item b)
            {

                int tempId = a.ItemId;
                string tempName = a.ItemName;
                int tempQuantity = a.Quantity;
                double tempPrice = a.Price;

                a.ItemName = b.ItemName;
                a.Price = b.Price;
                a.Quantity = b.Quantity;
                a.ItemId = b.ItemId;

                b.ItemId = tempId;
                b.Quantity = tempQuantity;
                b.ItemName = tempName;
                b.Price = tempPrice;
            }

        }
    }
}
