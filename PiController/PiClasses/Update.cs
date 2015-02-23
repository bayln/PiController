using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.PiClasses
{
    class Update : Command
    {
        // All fields of Update

        public Update(RaspberryPi pi)
        {
        }

        void Command.issueCommand()
        { }

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
