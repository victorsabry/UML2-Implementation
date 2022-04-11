using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_project_2
{
    class MenuCatalog
    {
        private List<MenuItem> _menuItems = new List<MenuItem>();
        
        public void Print()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("-----------------------------");
            if(_menuItems.Count != 0)
            {
                foreach (var menuItem in _menuItems)
                {
                    Console.WriteLine($"    {menuItem.Number}. {menuItem.Name} {menuItem.Price} kr");
                }
            }
            else
            {
                Console.WriteLine("No pizzas found");
            }            
            Console.WriteLine("-----------------------------");
        }

        public void CreateItem(int number, string name, decimal price)
        {
            var newItem = new MenuItem(number, name, price);
            _menuItems.Add(newItem);
        }

        public MenuItem SearchItem(int number)
        {
            foreach (var menuItem in _menuItems)
            {
                if(number == menuItem.Number)
                {
                    return menuItem;
                }
            }
            return null;
        }

        public MenuItem SearchItem(string partOfName)
        {
            foreach (var menuItem in _menuItems)
            {
                if (menuItem.Name.Contains(partOfName, StringComparison.OrdinalIgnoreCase))
                {
                    return menuItem;
                }
            }
            return null;
        }

        public void Delete(int number)
        {
            int index = GetIndex(number);            
            if (index > -1)
            {
                _menuItems.RemoveAt(index);
            }          
        }

        public int GetIndex(int number)
        {
            int index = -1;
            foreach (var menuItem in _menuItems)
            {
                if (number == menuItem.Number)
                {
                    index = _menuItems.IndexOf(menuItem);
                }
            }
            return index;
        }

        public void UpdatePizzaNumber(int number, int newNumber)
        {
            int index = GetIndex(number);
            _menuItems[index].Number = newNumber;
        }

        public void UpdatePizzaName(int number, string newName)
        {
            int index = GetIndex(number);
            _menuItems[index].Name = newName;
        }

        public void UpdatePizzaPrice(int number, decimal newPrice)
        {
            int index = GetIndex(number);
            _menuItems[index].Price = newPrice;
        }

        public bool IsListEmpty()
        {
            return _menuItems.Count == 0;
        }        
    }
}
