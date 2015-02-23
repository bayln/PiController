﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.Utilities
{
    class RebootMenu : Menu
    {
        // Menu Variables
        private int type = 2;
        private int alive;
        /* Constructor */
        public RebootMenu(int alive)
        {
            this.alive = alive;
        }
         // Interface methods
         int Menu.getType()
        { return 0; }
         void Menu.printMenu() 
        {
            Console.WriteLine();
            Console.WriteLine("Reboot One or More Pi's");
            Console.WriteLine("How many pi's would you like to reboot?");
            Console.WriteLine("1.\t One");
            Console.WriteLine("2.\t All (" + alive + " currently rebootable)");
            Console.WriteLine("3.\t Specify a list");
            Console.WriteLine("9.\t Return to main menu");
        }
         void Menu.printSecondaryMenu(string option) { }


    }
}
