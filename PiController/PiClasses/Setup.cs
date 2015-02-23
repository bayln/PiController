using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh;

namespace PiController.PiClasses
{
    class Setup : Command
    {
        // All fields of Setup
        private string NASfileLocation = @"S:\ENS\Labs\Raspberry Pi\ControlScripts\";
        private string RemoteFileLocation = "/home/pi/"; 
        
        public RaspberryPi pi;
        public SshExec exec;


        public Setup(RaspberryPi pi)
        {
            this.pi = pi;
            exec = new SshExec(pi.getHostname(), pi.getUser());
            exec.Password = pi.getPassword();

        }

         void Command.issueCommand()
        {

            exec.Connect();

            Console.WriteLine("Creating directories...");
            CreateDirectories();

            Console.WriteLine("Transferring scripts...");
            TransferScripts();

            Console.WriteLine("Running install script...");
            RunScripts(); 
        }


        
        private void CreateDirectories()
        {

            this.exec.RunCommand("mkdir device");
            this.exec.RunCommand("mkdir scripts");

        }
        

        private void TransferScripts()
        {                   

            // Modify the below code to add any additional files you might want. 
            Transfer transfer = new Transfer(); // Create type of Transfer if calling auxTransfer, else create type Command
            transfer.auxTransfer(this.pi, NASfileLocation + "install.sh", RemoteFileLocation + "scripts/install.sh");
            transfer.auxTransfer(this.pi, NASfileLocation + "start.py", RemoteFileLocation + "scripts/start.py");
            transfer.auxTransfer(this.pi, NASfileLocation + "lightdm.conf", "/etc/lightdm/lightdm.conf");
            transfer.auxTransfer(this.pi, NASfileLocation + "autostart", "/etc/xdg/lxsession/LXDE/autostart");
            transfer.auxTransfer(this.pi, NASfileLocation + @"lab-id\" + this.pi.getHostname(), RemoteFileLocation + "device/lab-id");                  
            

        }
        
        private void RunScripts()
        {

            this.exec.RunCommand("sh /home/pi/scripts/install.sh");
            
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
