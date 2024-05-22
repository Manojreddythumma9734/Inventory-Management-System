using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{   public class Item
    {   //Make all the varaibles private so that no one access them from out of the class
        private int ID;
        private string Name;
        private double Price;
        private int Quantity;

        public int id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public double price
        {
            get
            {
                return Price;
            }
            set
            {
                if (value >= 0)
                {
                    Price = value;
                }
                else
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
            }
        }
        public int quantity
        {
            get
            {
                return Quantity;
            }
            set
            {
                if (value >= 0) 
                {
                    Quantity = value;
                }
                else
                {
                    throw new ArgumentException("Quantity cannot be negative.");
                }
            }
        }

        public Item(int ID, string Name, double Price, int Quantity)
        {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
            this.Quantity = Quantity;
        }
        //Providing a string representation of the object by overriding the ToString method.
        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Price: {price}, Quantity: {quantity}";
        }
    }

    public class Inventory
    {
        //Make the items list private no one outside the 
        private List<Item> items;
 
        public Inventory()
        {
            items = new List<Item>();
        }
        //Method to add item
        public void AddItem()
        {   
            //Using try catch in order to handle the input data 
            try
            {
                int count = 0;
                Console.WriteLine("Enter the ID of the item");
                int id = int.Parse(Console.ReadLine());
                foreach (var ITEM in items)
                {
                    if (ITEM.id == id)
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine($"Already there is an item with the ID:{id}. Please try again");
                }
                else
                {
                    Console.WriteLine("Enter the Name of the item");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the Price of the item");
                    double price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Quantity of the item");
                    int quantity = int.Parse(Console.ReadLine());
                    Item item = new Item(id, name, price, quantity);
                    items.Add(item);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You have entered a Invalid Input. Please try again");
            }
        }
        //Method to Display all the items
        public void DisplayAllItems()
        {
            if (items.Count() == 0)
            {
                Console.WriteLine("There are no items to display");
            }
            else
            {
                Console.WriteLine("Details of all the items are:");
                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
        }
        //Method to find an item based on ID
        public void FindItem()
        {
            if (items.Count() == 0)
            {
                Console.WriteLine("There are no items to find");
            }
            else
            {

                Console.WriteLine("Enter the ID of the item to find:");
                //Using try catch in order to handle the input data 
                try
                {
                    int ID = int.Parse(Console.ReadLine());
                    int count = 0;
                    foreach (var item in items)
                    {
                        if (item.id == ID)
                        {
                            Console.WriteLine($"Item ID:{item.id} Name:{item.name} Price:{item.price} Quantity:{item.quantity}");
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("There is no item with the give ID to find");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You have entered a Invalid Input. Please try again");
                }
            }
        }
        //Method to update an item based on ID
        public void UpdateItem()
        {
            if (items.Count() == 0)
            {
                Console.WriteLine("There are no items to update");
            }
            else
            {

                Console.WriteLine("Enter the ID of the item to update:");
                //Using try catch in order to handle the input data 

                try
                {
                    int ID = int.Parse(Console.ReadLine());
                    int count = 0;
                    foreach (var item in items)
                    {
                        if (item.id == ID)
                        {
                            Console.WriteLine("Do you want to update Id then enter \"Yes\" otherwise enter \"No\":");
                            string choice =Console.ReadLine();
                            if (choice.ToUpper() == "YES")
                            {
                                Console.WriteLine("Enter the new ID of the item:");
                                item.id = int.Parse(Console.ReadLine());
                            }
                            else
                            {
                                if (choice.ToUpper() != "NO")
                                {
                                    Console.WriteLine("You have entered a Invalid Input. Please try again");
                                    break;
                                }
                            }
                            Console.WriteLine("Do you want to update Name then enter \"Yes\" otherwise enter \"No\":");
                            choice = Console.ReadLine();
                            if (choice.ToUpper() == "YES")
                            {
                                Console.WriteLine("Enter the new Name of the item:");
                                item.name = Console.ReadLine();
                            }
                            else
                            {
                                if (choice.ToUpper() != "NO")
                                {
                                    Console.WriteLine("You have entered a Invalid Input. Please try again");
                                    break;
                                }
                            }
                            Console.WriteLine("Do you want to update Price then enter \"Yes\" otherwise enter \"No\":");
                            choice = Console.ReadLine();
                            if (choice.ToUpper() == "YES")
                            {
                                Console.WriteLine("Enter the new Price of the item:");
                                item.price = double.Parse(Console.ReadLine());
                            }
                            else
                            {
                                if (choice.ToUpper() != "NO")
                                {
                                    Console.WriteLine("You have entered a Invalid Input. Please try again");
                                    break;
                                }
                            }
                            Console.WriteLine("Do you want to update Quantity then enter \"Yes\" otherwise enter \"No\":");
                            choice = Console.ReadLine();
                            if (choice.ToUpper() == "YES")
                            {
                                Console.WriteLine("Enter the new Quantity of the item:");
                                item.quantity = int.Parse(Console.ReadLine());
                            }
                            else
                            {
                                if (choice.ToUpper() != "NO")
                                {
                                    Console.WriteLine("You have entered a Invalid Input. Please try again");
                                    break;
                                }
                            }
                            count++;
                        }

                    }
                    if (count == 0)
                    {
                        Console.WriteLine("There is no item with the give ID to update");
                    }
                    else
                    {
                         Console.WriteLine("Updated successfully");

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You have entered a Invalid Input. Please try again");
                }
            }
        }
        //Method to delete an item
        public void DeleteItem()
        {
            if (items.Count() == 0)
            {
                Console.WriteLine("There are no items to Delete");
            }
            else
            {   int count = 0;
                Console.WriteLine("Enter the ID of the item to Delete:");
                //Using try catch in order to handle the input data 
                try
                {
                    int ID = int.Parse(Console.ReadLine());
                    Item item_to_delete=null;
                    foreach (var item in items)
                    {
                        if (item.id == ID)
                        {
                            item_to_delete = item;
                             count++;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("There is no item with the given ID to delete");
                    }
                    else
                    {
                        items.Remove(item_to_delete);
                        Console.WriteLine("Item is deleted successfully");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You have entered a Invalid Input. Please try again");
                }

                
            }
        }
    }
    internal class Program
    {    
        public void run()
        {
            Inventory inventory = new Inventory();
            int input_choice = 0;
            while (input_choice!=6)
            {   
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1.Add a new item");
                Console.WriteLine("2.Display all items");
                Console.WriteLine("3.Find an item");
                Console.WriteLine("4.Update an item");
                Console.WriteLine("5.Delete an item");
                Console.WriteLine("6.Exit");
                Console.WriteLine("Please select an option:");
                try
                {
                    input_choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please Enter a Valid Input");
                    continue;
                }
                Console.WriteLine("\n");
                switch (input_choice)
                {
                    case 1:
                        inventory.AddItem();
                        break;
                    case 2:
                        inventory.DisplayAllItems();
                        break;
                    case 3:
                        inventory.FindItem();
                        break;
                    case 4:
                        inventory.UpdateItem();
                        break;
                    case 5:
                        inventory.DeleteItem();
                        break;
                    case 6:
                        input_choice = 6;
                        Console.WriteLine("Successfully Exited");
                        break;
                    default:
                        Console.WriteLine("Please Enter a Number with in the range");
                        break;

                }
                Console.WriteLine("\n");
            }

        }
        static void Main(string[] args)
        {
            Program Application = new Program();
            Application.run();
        }
    }
}
