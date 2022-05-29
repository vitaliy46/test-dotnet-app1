using System;

namespace Kis.Console
{
    internal class MenuItem
    {
        public string MenuTitle { get; set; }
        public Action MenuAction { get; set; }

        public MenuItem(string menuTitle, Action menuAction)
        {
            MenuTitle = menuTitle;
            MenuAction = menuAction;
        }
    }
}
