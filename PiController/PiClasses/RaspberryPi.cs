using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;

namespace PiController.PiClasses
{
    // Creates and maintains raspberry pi objects
    
    class RaspberryPi
    {
     // All fields of RaspberryPi: may be populated over time

        //**** Readonly -- DO NOT CHANGE THESE ****//
        private readonly string pwd = "remote4pi";
        private readonly string usr = "pi";

        /* Networking variables */ 
            // Primitives //
        private int status;                     // When pi controller comes up -- pulls list of Pi's. status = ID# if alive, status = -1 if not alive
        private string hostname;
        private int id;
        private bool inFile;                    // True if in S drive textFile -- False if needs text file
            // Objects //
        private IPAddress ip;
        private PhysicalAddress mac;
        private SshExec shell;
       // private File deviceFile;
      

        /* Constructors */

        /// <summary>
        /// Constructor for new pi -- not in text file: 
        /// </summary>
        /// <param name="hostname">Hostname in form of "pi-sign-xx"</param>
        public RaspberryPi(string hostname)
        {
            this.hostname = hostname;
            this.id = parseHostname();

        }
        /// <summary>
        /// Constructor for pi that is in text file
        /// </summary>
        /// <param name="hostname">Hostname in form of "pi-sign-xx"</param>
        /// <param name="ip">IP address pulled from device text file</param>
        /// <param name="mac">Mac address pulled from device text file</param>
        public RaspberryPi(string hostname, IPAddress ip, PhysicalAddress mac)
        {
            this.hostname = hostname;
            this.id = parseHostname();
            this.ip = ip;
            this.mac = mac;

        }


        /* Getters */
        public string getHostname()
        {    return this.hostname;  }
        public string getUser()
        {    return this.usr;   }
        public string getPassword()
        {    return this.pwd;   }

        public void setStatus(int status)
        {
            this.status = status;
        }

        public bool isAlive()
        {
            if (this.status != -1)
                return true;
            else
                return false;
        }

        public int parseHostname()
        {
            string[] separate = this.hostname.Split('-');
            return Convert.ToInt32(separate[2]);
        }

        public string ToString()
        {
            return this.hostname;
        }


        
       
    }


    /* Notes on Implementation:
     * device folder on pi will have a networkConfigs textFile
     * created by parsing results of ifconfig into ipAddr macAddr
     * similarly: there will be a text file in piController folder
     * network.txt: will contain all network info printed as hostname  ip   mac  status
     * one pi per line
     */
}
