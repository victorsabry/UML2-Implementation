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
                Console.WriteLine("1: Print Menu");
                Console.WriteLine("2: Create Pizza");
                Console.WriteLine("3: Delete Pizza");
                Console.WriteLine("4: Search Pizza");
                Console.WriteLine();
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                const string OptionPrintMenu = "1";
                const string OptionCreatePizza = "2";
                const string Option = "3";
                const string Option2 = "4";

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
                            break;                                           
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
            }
        }
    }
}
