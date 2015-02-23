using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.Utilities
{
    class UpdateMenu : Menu
    {
         // Menu Variables
        private int type = 3;
        private int alive;
        /* Constructor */
        public UpdateMenu(int alive)
        {
            this.alive = alive;
        }
         // Interface methods
         int Menu.getType()
        { return type; }
         void Menu.printMenu()
        {

        }
         void Menu.printSecondaryMenu(string option) { }
    }
}
