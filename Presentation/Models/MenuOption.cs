using System;
using System.Collections.Generic;
using System.Linq;

namespace Presentation.Models
{
    public class Menu
    {
        private static readonly (string text, Func<MenuItem, Menu> action)[] _mainMenu =
        {
            ("File", null),
            ("Database", null),
            ("Manual Input", null)
        };

        private readonly bool _isMainMenu;
        private readonly Dictionary<string, MenuItem> _items = new Dictionary<string, MenuItem>();

        public string Message { get; set; }
        public IEnumerable<MenuItem> Items => _items.Values.AsEnumerable();

        private Menu(bool isMainMenu = false)
        {
            _isMainMenu = isMainMenu;
        }

        public static Menu GetMainMenu(MenuItem item = null)
        {
            var menu = new Menu(true) {Message = "Please select the desired input for counting words in a text:"};

            foreach (var (text, action) in _mainMenu)
            {
                menu.AddMenuItem(text, action);
            }

            return menu;
        }

        public void AddMenuItem(string text, Func<MenuItem, Menu> action, string arg = null)
        {
            AddMenuItem(new MenuItem(text, GetItemKey(), action, arg));
        }

        private void AddMenuItem(MenuItem item)
        {
            _items.Add(item.Key, item);
        }

        private string GetItemKey()
        {
            return (_isMainMenu ? _items.Count + 1 : _items.Count).ToString();
        }
    }

    public class MenuItem
    {
        public string Text { get; }
        public string Key { get; }
        public Func<MenuItem, Menu> Action { get; }
        public string Arg { get; }

        public MenuItem(string text, string key, Func<MenuItem, Menu> action, string arg = null)
        {
            Text = text;
            Key = key;
            Action = action;
            Arg = arg;
        }

        public static MenuItem BackToMain(string key) =>
            new MenuItem("Go back to main menu", key, Menu.GetMainMenu);
    }

    public interface IAction
    {
        Menu Execute(MenuItem item = null);
    }
}