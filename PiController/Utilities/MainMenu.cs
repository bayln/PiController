using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.Utilities
{
    class MainMenu : Menu
    {
        // Menu Variables
        private int type = 0;
        private int alive;

        /* Constructor */
        public MainMenu(int alive)
        {
            this.alive = alive;
        }
        // Interface methods
         int Menu.getType()
        { return this.type; }
         void Menu.printMenu() 
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************");
            Console.WriteLine("*                      The Pi Controller                   *");
            Console.WriteLine("************************************************************");
            Console.WriteLine("There are currently " + this.alive + " pi's online");
            Console.WriteLine("\n");
            Console.WriteLine("Please Choose an Option:");
            Console.WriteLine("1.\t Status");
            Console.WriteLine("2.\t Reboot");
            Console.WriteLine("3.\t Update");
            Console.WriteLine("4.\t Transfer Files");
            Console.WriteLine("5.\t Install");
            Console.WriteLine("6.\t Setup New Pi");
            Console.WriteLine("7.\t Open Shell");
            Console.WriteLine("8.\t About the Pi Controller");
            Console.WriteLine("9.\t Quit");
        }
         void Menu.printSecondaryMenu(string option) { }

    }
}
