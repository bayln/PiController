using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh;

namespace PiController.PiClasses
{
    class Reboot : Command
    {
        private RaspberryPi pi;
        SshExec exec;

        /* Constructor */
        public Reboot(RaspberryPi pi)
        {
            try
            {
                this.pi = pi;
                this.exec = new SshExec(pi.getHostname(), pi.getUser());
                this.exec.Password = pi.getPassword();
            }
            catch (Exception) { }
        }

        void Command.issueCommand()
        {                   
            exec.Connect();
            exec.RunCommand("sudo reboot");
            exec.Close();
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
