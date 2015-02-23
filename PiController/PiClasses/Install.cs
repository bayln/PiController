using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh;

namespace PiController.PiClasses
{
    class Install : Command
    {
        // All fields of Install
        private RaspberryPi pi;
        private string package;
        SshExec exec;

        /* Constructor */
        public Install(RaspberryPi pi, string package)
        {
            this.pi = pi;
            this.package = package;
            exec = new SshExec(pi.getHostname(), pi.getUser(), pi.getPassword());
        }


         void Command.issueCommand()
        {
            this.exec.RunCommand("sudo apt-get update");
            this.exec.RunCommand("sudo apt-get install " + this.package);
            return;
            
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
