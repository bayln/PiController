using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.Utilities
{
    class StatusMenu : Menu
    {
         // Menu Variables
        private int type = 1;
        private int alive;
        /* Constructor */
        public StatusMenu(int alive)
        {
            this.alive = alive;
        }
        // Interface methods
         int Menu.getType()
        { return type; }
         void Menu.printMenu() 
        {
            Console.WriteLine();
            Console.WriteLine("Get the Status of One or More Pi's");
            Console.WriteLine("How many pi's would you like to get a status on?");
            Console.WriteLine("1.\t One");
            Console.WriteLine("2.\t All (" + alive + " currently modifiable)");
            Console.WriteLine("3.\t Specify a list");
            Console.WriteLine("9.\t Return to main menu");
        }
         void Menu.printSecondaryMenu(string option) { }
    }
}
