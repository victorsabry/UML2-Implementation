using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_project_2
{
    class MenuItem
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }

        public MenuItem(int number, string name, decimal price)
        {
            Name = name;
            Number = number;
            Price = price;
        }
    }
}
