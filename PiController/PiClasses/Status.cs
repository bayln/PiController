using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.PiClasses
{
    class Status : Command
    {
        private RaspberryPi pi;
        public Status(RaspberryPi pi)
        {
            this.pi = pi;
        }


         void Command.issueCommand()
        {
            Console.WriteLine("Successfully got to status command");
            Console.WriteLine("Getting status on " + this.pi);
        }
         string Command.getRaspberryPi()
         {
             return null;
         }
         Command Command.getType()
         {
             return null;
         }



    }
}
