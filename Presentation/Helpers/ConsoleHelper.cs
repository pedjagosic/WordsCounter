using System;
using Presentation.Models;

namespace Presentation.Helpers
{
    public class ConsoleHelper
    {
        private static Menu _activeMenu;

        public static void DisplayMenu(Menu menu)
        {
            _activeMenu = menu;
            
            Console.WriteLine(menu.Message);

            foreach (var item in menu.Items)
            {
                Console.WriteLine($"{item.Key}) {item.Text}");
            }
        }

        public static void DisplayMainMenu()
        {
            DisplayMenu(Menu.GetMainMenu());
        }
    }
}