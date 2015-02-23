using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh;

namespace PiController.PiClasses
{
    class Transfer : Command
    {
        // All fields of Transfer
         private RaspberryPi pi;
        private string remote;
        private string local;
        private Scp transferScp;
        


        /* Constructors */
        public Transfer()
        { }
        public Transfer(RaspberryPi pi, string local, string remote)
        {
            this.pi = pi;
            this.local = local;
            this.remote = remote;
            this.transferScp = new Scp(pi.getHostname(), pi.getUser(), pi.getPassword());
        }


         void Command.issueCommand()
        {
            try
            {
                this.transferScp.Connect();
                this.transferScp.To(local, remote);
                this.transferScp.Close();
            }

            catch (Exception)
            { }
        }

        public void auxTransfer(RaspberryPi pi, string local, string remote)
        {
            
            Scp scp = new Scp(pi.getHostname(),pi.getUser(),pi.getPassword());
            try
            {
                scp.Connect();
                scp.From(remote, local);
                scp.Close();
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
