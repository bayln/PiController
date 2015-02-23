using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.Utilities
{
    interface Menu
    {
        // Menu methods
         int getType();
         void printMenu();
         void printSecondaryMenu(string option);

    }
}
