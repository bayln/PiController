using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.PiClasses
{
    class OpenShell : Command
    {
        private string pi;
        

        /* Constructor */
        public OpenShell(string pi)
        {
            this.pi = pi;
        }

         void Command.issueCommand()
        {
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            cmd.StartInfo.FileName = @"C:\windows\system32\cmd.exe";
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;

            cmd.Start();
            try
            {
                cmd.StandardInput.WriteLine("putty.exe -ssh pi@" + pi + " -pw remote4pi 22");
            }
            catch (Exception)
            { }
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
