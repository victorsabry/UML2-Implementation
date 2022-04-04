using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_project_2
{
    class Store
    {
        private MenuCatalog _menu = new MenuCatalog();
        public void Run()
        {                        
            _menu.CreateItem(1, "firstPizza", 49);
            _menu.CreateItem(2, "secondPizza", 57);
            _menu.CreateItem(3, "thirdPizza", 75);
            
            var searchResult = _menu.SearchItem(4);
            bool running = true;
            while (running)
            {
                const string OptionPrintMenu = "1";
                const string OptionCreatePizza = "2";
                const string OptionDeletePizza = "3";
                const string OptionSearchPizza = "4";
                const string OptionUpdatePizza = "5";

                Console.WriteLine($"{OptionPrintMenu}: Print Menu");
                Console.WriteLine($"{OptionCreatePizza}: Create Pizza");
                Console.WriteLine($"{OptionDeletePizza}: Delete Pizza");
                Console.WriteLine($"{OptionSearchPizza}: Search Pizza");
                Console.WriteLine($"{OptionUpdatePizza}: Update Pizza");
                Console.WriteLine();
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                

                if (choice == OptionPrintMenu)
                {
                    Console.WriteLine();
                    _menu.Print();
                    Console.WriteLine();
                    continue;
                }
                
                if(choice == OptionCreatePizza)
                {
                    Console.WriteLine();
                    int pizzaNumber;
                    while (true)
                    {
                        Console.Write("Enter number for new pizza: ");
                        string pizzaNumberStr = Console.ReadLine();
                        if(int.TryParse(pizzaNumberStr, out pizzaNumber))
                        {
                            var existingPizza = _menu.SearchItem(pizzaNumber);
                            bool numberIsFree = existingPizza == null;
                            if (numberIsFree)
                            {
                                break;
                            }

                            Console.WriteLine($"Pizza number {pizzaNumber} already exists");
                        }
                    }

                    Console.Write("Enter name for new pizza: ");
                    string pizzaName = Console.ReadLine();

                    decimal pizzaPrice;
                    while (true)
                    {
                        Console.Write("Enter price for new pizza: ");
                        string pizzaPriceStr = Console.ReadLine();
                        if (decimal.TryParse(pizzaPriceStr, out pizzaPrice))
                            break;
                    }

                    _menu.CreateItem(pizzaNumber, pizzaName, pizzaPrice);

                    Console.WriteLine("New pizza created");
                    Console.WriteLine();
                    continue; 
                }

                if(choice == OptionDeletePizza)
                {
                    Console.WriteLine();
                    int pizzaNumberSelected;
                    while (true)
                    {
                        Console.Write("Search for pizza for deletion: ");
                        var pizzaSearched = Console.ReadLine();

                        if (int.TryParse(pizzaSearched, out pizzaNumberSelected))
                        {
                            var existingPizza = _menu.SearchItem(pizzaNumberSelected);
                            bool numberDoNotExist = existingPizza == null;
                            if (numberDoNotExist)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Pizza '{pizzaSearched}' does not exist");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Deleting pizza: {existingPizza.Name} {existingPizza.Price} kr");
                                _menu.Delete(pizzaNumberSelected);                                
                                Console.WriteLine();

                                break;
                            }
                        }                        
                    }
                }

                if (choice == OptionSearchPizza)
                {
                    Console.WriteLine();
                    int pizzaNumberSearched;
                    while(true)
                    {
                        Console.Write("Search for pizza: ");
                        var pizzaSearched = Console.ReadLine();

                        if (int.TryParse(pizzaSearched, out pizzaNumberSearched))
                        {
                            var existingPizza = _menu.SearchItem(pizzaNumberSearched);
                            bool numberDoNotExist = existingPizza == null;
                            if (numberDoNotExist)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Pizza '{pizzaSearched}' does not exist");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Pizza found: {existingPizza.Name} {existingPizza.Price} kr");
                                Console.WriteLine();

                                break;
                            }                                
                        }
                        else
                        {
                            var existingPizza = _menu.SearchItem(pizzaSearched);
                            bool pizzaNameNotFound = existingPizza == null;

                            if (pizzaNameNotFound)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Pizza '{pizzaSearched}' does not exist");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Pizza found: {existingPizza.Name} {existingPizza.Price} kr");
                                Console.WriteLine();

                                break;
                            }                           
                        }
                    }                    
                }
            }
        }
    }
}