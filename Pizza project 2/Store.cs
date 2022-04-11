using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_project_2
{
    class Store
    {
        private MenuCatalog _menu = new MenuCatalog();

        private void CreateMenuItems()
        {
            _menu.CreateItem(1, "Chicken kebab", 63);
            _menu.CreateItem(2, "Hawaii", 57);
            _menu.CreateItem(3, "Pepperoni feast", 75);
        }

        public void Run()
        {
            CreateMenuItems();
            bool running = true;
            while (running)
            {
                const string OptionPrintMenu = "1";
                const string OptionSearchPizza = "2";
                const string OptionCreatePizza = "3";
                const string OptionDeletePizza = "4";                
                const string OptionUpdatePizza = "5";

                Console.WriteLine($"{OptionPrintMenu}: Print Menu");
                Console.WriteLine($"{OptionSearchPizza}: Search Pizza");
                Console.WriteLine($"{OptionCreatePizza}: Create Pizza");
                Console.WriteLine($"{OptionDeletePizza}: Delete Pizza");                
                Console.WriteLine($"{OptionUpdatePizza}: Update Pizza");
                Console.WriteLine();

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case OptionPrintMenu:
                        SelectedPrintMenu();
                        break;

                    case OptionSearchPizza:
                        SelectedSearchPizza();
                        break;

                    case OptionCreatePizza:
                        SelectedCreatePizza();
                        break;

                    case OptionDeletePizza:
                        SelectedDeletePizza();
                        break;                    

                    case OptionUpdatePizza:
                        SelectedUpdatePizza();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine($"Unknown option: '{choice}'");
                        Console.WriteLine();
                        break;
                }                
            }
        }

        private void SelectedPrintMenu()
        {
            Console.WriteLine();
            _menu.Print();
            Console.WriteLine();
        }

        private void SelectedCreatePizza()
        {
            int pizzaNumber;
            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter number for new pizza: ");
                string pizzaNumberStr = Console.ReadLine();
                if (int.TryParse(pizzaNumberStr, out pizzaNumber))
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
                {
                    if (pizzaPrice > 0)
                        break;

                    Console.WriteLine($"Price must be greater than 0 ({pizzaPrice})");
                    continue;
                }
                Console.WriteLine($"Entered price not valid ({pizzaPriceStr})");
            }

            _menu.CreateItem(pizzaNumber, pizzaName, pizzaPrice);
            Console.WriteLine();
            Console.WriteLine($"New pizza created: ({pizzaNumber}. {pizzaName} {pizzaPrice} kr)");
            Console.WriteLine();
        }

        private void SelectedDeletePizza()
        {
            if (_menu.IsListEmpty() == false)
            {
                while (true)
                {
                    Console.WriteLine();
                    int pizzaNumberSelected;
                    Console.Write("Search for pizza for deletion (insert number of pizza): ");
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
                            Console.WriteLine($"Deleting pizza: {existingPizza.Number}. {existingPizza.Name} {existingPizza.Price} kr");
                            _menu.Delete(pizzaNumberSelected);
                            Console.WriteLine();

                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("There are no pizzas left to delete");
                Console.WriteLine();
            }
        }

        private void SelectedSearchPizza()
        {
            if (_menu.IsListEmpty() == false)
            {
                Console.WriteLine();
                int pizzaNumberSearched;
                while (true)
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
                            Console.WriteLine($"Pizza found: {existingPizza.Number}. {existingPizza.Name} {existingPizza.Price} kr");
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
                            Console.WriteLine($"Pizza found: {existingPizza.Number}. {existingPizza.Name} {existingPizza.Price} kr");
                            Console.WriteLine();

                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("There are no pizzas left to search");
                Console.WriteLine();
            }
        }

        private void SelectedUpdatePizza()
        {
            if (_menu.IsListEmpty() == false)
            {
                Console.WriteLine();
                while (true)
                {
                    Console.Write("Choose a pizza to update(insert number of pizza): ");
                    int pizzaNumberSearched;
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
                            const string OptionUpdateNumber = "1";
                            const string OptionUpdateName = "2";
                            const string OptionUpdatePrice = "3";
                            Console.WriteLine();
                            Console.WriteLine($"Pizza found: {existingPizza.Number}. {existingPizza.Name} {existingPizza.Price} kr");
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("1. Update Number");
                            Console.WriteLine("2. Update Name");
                            Console.WriteLine("3. Update Price");
                            Console.WriteLine("--------------------------");

                            Console.Write("Choose what to opdate: ");
                            string updateChoice = Console.ReadLine();

                            var exitSwitch = false;
                            while (!exitSwitch)
                            {
                                switch (updateChoice)
                                {
                                    case OptionUpdateNumber:
                                        Console.Write("Enter new number for pizza: ");
                                        string newPizzaNumber = Console.ReadLine();
                                        int newPizzaNumberInt;                                        
                                        int oldPizzaNumber = existingPizza.Number;

                                        if (int.TryParse(newPizzaNumber, out newPizzaNumberInt))
                                        {                                            
                                            _menu.UpdatePizzaNumber(existingPizza.Number, newPizzaNumberInt);
                                            Console.WriteLine();
                                            Console.WriteLine($"{existingPizza.Name}'s number was changed from {oldPizzaNumber} to {newPizzaNumberInt}");
                                            Console.WriteLine();
                                            exitSwitch = true;
                                        }
                                        break;

                                    case OptionUpdateName:
                                        Console.Write("Enter new name for pizza: ");
                                        string newPizzaName = Console.ReadLine();
                                        string oldPizzaName = existingPizza.Name;
                                        if (!string.IsNullOrWhiteSpace(newPizzaName))
                                        {
                                            _menu.UpdatePizzaName(existingPizza.Number, newPizzaName);
                                            Console.WriteLine();
                                            Console.WriteLine($"{oldPizzaName}'s name was changed to {newPizzaName}");
                                            Console.WriteLine();
                                            exitSwitch = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Name can't contain only empty spaces");
                                        }
                                        break;

                                    case OptionUpdatePrice:
                                        Console.Write("Enter new price for pizza: ");
                                        decimal newPizzaPriceDec;
                                        string newPizzaPrice = Console.ReadLine();
                                        decimal oldPizzaPrice = existingPizza.Price; 
                                        if (decimal.TryParse(newPizzaPrice, out newPizzaPriceDec))
                                        {
                                            if (newPizzaPriceDec <= 0)
                                            {
                                                Console.WriteLine($"Price must be greater than 0 ({newPizzaPriceDec})");
                                            }
                                            else
                                            {                                                
                                                _menu.UpdatePizzaPrice(existingPizza.Number, newPizzaPriceDec);
                                                Console.WriteLine();
                                                Console.WriteLine($"{existingPizza.Name}'s price was changed from {oldPizzaPrice} kr to {newPizzaPriceDec} kr");
                                                Console.WriteLine();
                                                exitSwitch = true;
                                            }                                                                                       
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Entered price not valid ({newPizzaPrice})");                                            
                                        }                                        
                                        break;

                                    default:
                                        break;
                                }                                
                            }
                        }
                    }
                    break;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("There are no pizzas left to update");
                Console.WriteLine();                
            }
        }                              
    }
}