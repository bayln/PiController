using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.Utilities
{
    class TransferMenu : Menu
    {
        // Menu Variables
        private int type = 4;
        private int alive;
        // Constructors
        public TransferMenu(int alive)
        {
            this.alive = alive;
        }
        // Interface methods
         int Menu.getType()
        { return type; }
         void Menu.printMenu()   
        {
            Console.WriteLine();
            Console.WriteLine("Transfer a File to One or More Pi's");
            Console.WriteLine("How many pi's would you like to transfer files to?");
            Console.WriteLine("1.\t One");
            Console.WriteLine("2.\t All (" + alive + " currently able to receive files)");
            Console.WriteLine("3.\t Specify a list");
            Console.WriteLine("9.\t Return to main menu");
        }
         void Menu.printSecondaryMenu(string option) { }
    }
}
