using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Net.NetworkInformation;
using PiController.PiClasses;

namespace PiController.Network
{
    // Overlay Class
    // Builds an Overlay with all of the active Pi's -- data structure of raspberryPi's
    // Populate this before spawning threadPool to do commands -- before handing over control to the user
    class Overlay
    {
        // All fields of Overlay
       private List<string> allSigns;
       private List<string> offline;
       private List<string> online;

       private List<RaspberryPi> raspberryPis;

       //le SDriveFile;    // File found in the S drive
        // Constructor

        /* Getters */
       public List<string> getOnline()
        {
            return this.online;
        }

        public List<RaspberryPi> getPis()
        {
            return this.raspberryPis;
        }
        public Overlay()
        {
            this.allSigns = new List<string>();
            this.offline = new List<string>();
            this.online = new List<string>();
            this.raspberryPis = new List<RaspberryPi>();

            // Populate and determine online pi's
            this.PopulateList();
            this.PingList();
            this.constructRaspberryPis();
        }


        public void PopulateList()
        {            
            // If a whole new pi station ever gets added, change the 34 to 35 to account for the additional sign
            for (int i = 2; i < 34; i++)
            {
                string host = "pi-sign-";
                if (i < 10)
                {
                    host += "0" + i;
                    //Console.WriteLine(host);
                }
                else
                {
                    host += i;
                }
                if (host != null)
                   this.allSigns.Add(host);
            }

            
        }

        public int PingList()
        {
            Console.WriteLine("Please wait while the controller populates the list of actives pi-signs...");

            int count = 1;
            foreach (string address in this.allSigns)
            {
                // EXCEPTIONS: REMOVE THIS STATEMENT ONCE SCOTT PI'S ARE PINGABLE BY HOSTNAME AND/OR WE ADD THEIR IP ADDRESSES
                // DNS issues have been resolved for 16,17,19 -- remaining is 18
                if (address != "pi-sign-18")
                {
                    Ping pingSender = new Ping();
                    //IPAddress address = IPAddress.Loopback;
                    try
                    {

                        PingReply reply = pingSender.Send(address);

                        if (reply.Status == IPStatus.Success)
                        {
                            this.online.Add(address);
                            count++;
                        }
                        else
                        {
                            this.offline.Add(address);
                            Console.WriteLine(address + " is offline.");
                            //Console.WriteLine(reply.Status);
                        }
                    }

                    catch (Exception)
                    {
                        this.offline.Add(address);
                        Console.WriteLine(address + " is offline.");

                    }
                }
            }

            return count;
        }

        public bool findPiBool(string hostname)
        {
            try
            {
                foreach (string search in online)
                {
                    if (search == hostname)
                        return true;

                }
            }
            catch (Exception) { }
            return false;
        }

        public RaspberryPi findPi(string hostname)
        {
            RaspberryPi pi = null;
            try
            {
                foreach (RaspberryPi search in raspberryPis)
                {
                    if (search.getHostname() == hostname)
                        return search;

                }
            }
            catch (Exception) { }

            return pi;
        }


        public void constructRaspberryPis()
        {
            foreach (string hostname in this.online)
            {
                try
                {
                    RaspberryPi pi = new RaspberryPi(hostname);
                    raspberryPis.Add(pi);
                }
                catch (Exception) { }
            }
        }

       public bool checkList(string str)
        {
            if (!this.online.Contains(str))
            {
                return false;
            }
            else
                return true;

        }



    }
}
