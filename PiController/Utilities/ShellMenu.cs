using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.Utilities
{
    class ShellMenu : Menu
    {
         // Menu Variables
        private int type = 7;
        /* Constructor */
        public ShellMenu() { }
        // Interface methods
         int Menu.getType()
        { return type; }
         void Menu.printMenu()  
        {
            Console.WriteLine("Which pi? (Just type the ID number. For example: pi-sign-02 would just be 02)");
        }
         void Menu.printSecondaryMenu(string option) { }
    }
}
