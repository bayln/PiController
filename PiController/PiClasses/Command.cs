using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.PiClasses
{   
    /* Commands that are in Command interface:
     * Install
     * OpenShell
     * Reboot
     * Setup
     * Transfer
     * Update
     */

    interface Command
    {
      void issueCommand();
      string getRaspberryPi();
      Command getType();
       
    }
}
