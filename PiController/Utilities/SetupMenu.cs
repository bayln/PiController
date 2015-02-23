using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.Utilities
{
    class SetupMenu : Menu
    {
         // Menu Variables
        private int type = 6;
         // Interface methods
        int Menu.getType()
        { return type; }
         void Menu.printMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Which pi would you like to run a fresh setup on?");
        }
         void Menu.printSecondaryMenu(string option) { }
    }
}
