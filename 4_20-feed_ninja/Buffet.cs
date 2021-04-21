using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    class Buffet
    {
        public List<IConsumable> Menu;
        public Buffet()
        {
            Menu = new List<IConsumable>() {
                new Food("Cake", 200, false, true),
                new Food("Burger", 300, false, false),
                new Food("Wings", 250, true, false),
                new Food("Salad", 10, false, false),
                new Food("Creame", 50, false, true),
                new Food("Honey pepper", 80, true, true),
                new Drink("Water", 1, false, false),
                new Drink("Pepsi", 20, false, true),
            };
        }

        public IConsumable Serve()
        {
            Random r = new Random();
            int rand = r.Next(0, Menu.Count);
            return Menu[rand];
        }
    }
}