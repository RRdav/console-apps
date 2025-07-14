using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capplearning1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //helloUser();
            //numberGuess();
            toDoList();
        }



        static void helloUser()
        {
            Console.WriteLine("Welcome to my first actual learning session.");
            Console.WriteLine("======================================");
            Console.WriteLine("What's your name?");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello " + userName + " :)");
        }

        static void numberGuess()
        {
            Random random = new Random();
            int randomNum = random.Next(1, 100);
            Console.WriteLine("Guess the number between 1 and 100!");
            int numberGuessed = 0;
            while (numberGuessed != randomNum)
            {
                numberGuessed = Int32.Parse(Console.ReadLine());

                if (numberGuessed > randomNum)
                {
                    Console.WriteLine("The number you've inputted is GREATER than the target number. Please input another");
                }
                else if (numberGuessed < randomNum)
                {
                    Console.WriteLine("The number you've inputted is LESS than the target number. Please input another");
                }
            }
            Console.WriteLine("You've guessed the number!");
        }

        static void toDoList()
        {
            Console.WriteLine("Welcome to your TO-DO List!");
            Console.WriteLine("============================");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. View list");
            Console.WriteLine("2. Add to list");
            Console.WriteLine("3. Delete from list");
            Console.WriteLine("4. Update item from list");

            string path = @"C:\Users\Bisita\Desktop\.NET Learning\todolist.txt";

            //File creation
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("Welcome to your todolist!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            int userChoice = Int32.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("TODO List:");
                    //View  all
                    Console.WriteLine("===========================");
                    using(StreamReader sr = File.OpenText(path))
                    {
                        string s;
                        while(( s= sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                    break;

                case 2:
                    Console.WriteLine("Add to List:");
                    Console.WriteLine("===========================");
                    string itemToAdd = Console.ReadLine();

                    var existingItems = new List<string>();

                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s;
                        while((s = sr.ReadLine()) != null)
                        {
                            existingItems.Add(s);
                        }
                    }

                    using (StreamWriter sw = File.CreateText(path))
                    {
                        foreach(string item in existingItems)
                        {
                            sw.WriteLine(item);
                        }
                        sw.WriteLine(itemToAdd);
                    }
                    break;

                case 3:
                    Console.WriteLine("Delete from List:");
                    Console.WriteLine("===========================");
                    Console.WriteLine("Which item would you like to delete? ex. 1, 2, 3");


                    var items = new List<string>();
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            items.Add(s);
                        }
                    }

                    int index = 1;
                    foreach (string item in items)
                    {
                        Console.WriteLine($"{index}. {item}");
                        index++;
                    }

                    int itemToDelete = Int32.Parse(Console.ReadLine());

                    int indexToDelete = itemToDelete - 1;
                    if (indexToDelete >= 0 && indexToDelete < items.Count)
                    {
                        items.RemoveAt(indexToDelete);
                        Console.WriteLine("Item deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid item number.");
                    }

                    using (StreamWriter sw = File.CreateText(path))
                    {
                        foreach (string item in items)
                        {
                            sw.WriteLine(item);
                        }
                    }
                    break;

                case 4:
                    Console.WriteLine("Complete item from list");
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice number");
                    break;
            }
            Console.WriteLine("Press Any Key to exit");
            Console.ReadKey();
        }
    }
}
