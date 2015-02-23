using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiController.Utilities
{
    class InfoMenu : Menu
    {
         // Menu Variables
        private int type = 8;
        private int alive;

        /* Constructor */
        public InfoMenu()
        {
           
        }

        // Interface methods
         int Menu.getType()
        { return type; }
         void Menu.printMenu()   
        {
            Console.WriteLine();
            Console.WriteLine("Please Choose an Option You'd Like to Know More About:");
            Console.WriteLine("1.\t Status");
            Console.WriteLine("2.\t Reboot");
            Console.WriteLine("3.\t Update");
            Console.WriteLine("4.\t Transfer Files");
            Console.WriteLine("5.\t Install");
            Console.WriteLine("6.\t Setup New Sign");
            Console.WriteLine("7.\t Open Shell");
        }

        void Menu.printSecondaryMenu(string option)
         {
             switch (option)
             {
                 // Status
                 case "1":
                     Console.WriteLine("Get the status on one or more pi-signs:");
                     Console.ReadKey();

                     break;
                 // Reboot
                 case "2":
                     Console.WriteLine("Reboot one or more pi-signs:");
                     Console.ReadKey();
                     break;
                 // Update
                 case "3":
                     Console.WriteLine("Update one or more pi-signs:");
                     Console.WriteLine("Will do software updates via apt-get update and the \nupdater scripts provided in the pi folder.");
                     Console.ReadKey();
                     break;
                 // File Transfer
                 case "4":
                     Console.WriteLine("Transfer files to one or more pi-signs:");
                     Console.WriteLine("Provide a source and destination path, and the controller will transfer the \ngiven files from local drive or NAS to the pi-sign(s).");
                     Console.ReadKey();
                     break;
                 // Install
                 case "5":
                     Console.WriteLine("Install a particular software package on one or more pi-signs:");
                     Console.WriteLine("Give the name of a package as linux recognizes it. Ex: if you want to install remote desktop, type xrdp");
                     Console.ReadKey();
                     break;
                 // Setup 
                 case "6":
                     Console.WriteLine("Setup a newly imaged pi:");
                     Console.WriteLine("Give the hostname or ip address of the pi you want to setup.. will run all of the setup scripts. \nCheck the pi folder for documentation on exactly what happpens.");
                     Console.ReadKey();
                     break;
                 case "7":
                     Console.WriteLine("Open a shell on a particular pi:");
                     Console.WriteLine("Opens a putty shell for a pi, where customized commands can be given. There's \nno current option to do this for all pis because I don't think you would like 33 putty windows to suddenly spawn on your desktop.");
                     Console.ReadKey();
                     break;
                 case "9":
                     return;
             }

         }
    }
}
