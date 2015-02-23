using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using PiController.PiClasses;
using PiController.ThreadPool;
using PiController.Network;

namespace PiController.Utilities
{
    class InteractiveCommandParser
    {
        // Private variables of the Command Parser
        private Menu menu;   // The menu type to determine which commands are parsed
        private List<string> online;
        private List<RaspberryPi> rasPis;
        private ThreadPoolManager threadPool;
        private Overlay network;
       
        /* Constructor */
        public InteractiveCommandParser(ref Overlay network, ref ThreadPoolManager mgr)
        {

            this.network = network;
            this.online = network.getOnline(); 
            this.rasPis = network.getPis();
            this.threadPool = mgr;
        }

        public void ParseCommands(int alive)
        {
            foreach (RaspberryPi s in rasPis)
            {
                Console.WriteLine(s);
            }
            string command = "";
            do
            {
                menu = new MainMenu(alive);
                menu.printMenu();

                command = Console.ReadLine();
                Console.WriteLine();

                switch (command)
                {

                    case "1":
                        menu = new StatusMenu(alive);
                        menu.printMenu();
                        secondaryCommands(1);
                        break;
                    case "2":
                        menu = new RebootMenu(alive);
                        menu.printMenu();
                        secondaryCommands(2);
                        break;
                    case "3":
                        menu = new UpdateMenu(alive);
                        menu.printMenu();
                        secondaryCommands(3);
                        break;
                    case "4":
                        menu = new TransferMenu(alive);
                        menu.printMenu();
                        secondaryCommands(4);
                        break;
                    case "5":
                        menu = new InstallMenu(alive);
                        menu.printMenu();
                        secondaryCommands(5);
                        break;
                    case "6": //Special Case
                        Console.WriteLine("This is a special case -- to be implemented.");
                        menu = new SetupMenu();
                        menu.printMenu();
                        break;
                    case "7": // Special Case
                        menu = new ShellMenu();
                        menu.printMenu();
                        string id = Console.ReadLine();
                        List<RaspberryPi> tempList = new List<RaspberryPi>();
                        string hostname = "pi-sign-" + id;
                        RaspberryPi pi = this.network.findPi(hostname);
                        if (pi != null)
                        {
                            tempList.Add(this.network.findPi(hostname));
                            selectCommand(7, tempList);
                        }
                        else
                        {
                            Console.WriteLine("Invalid host. Please try again.");
                            Console.ReadKey();
                                break;
                        }
                        //secondaryCommands(7);
                        break;
                    case "8": //Special Case
                        menu = new InfoMenu();
                        menu.printMenu();
                        string option = "";
                        option = Console.ReadLine();
                        menu.printSecondaryMenu(option);
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Not a valid command. Please try again.");
                        break;
                }





            } while (command != "9");


            }


        public void secondaryCommands(int command)
        {
            
            List<RaspberryPi> pisToApply = new List<RaspberryPi>();
            RaspberryPi pi = null;
            string option = "";
            string hostname = "";
            do
            {
                
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Which Pi? (Just type the ID number. For example: pi-sign-02 would just be 02)");
                        string id = Console.ReadLine();
                        hostname = "pi-sign-" + id;
                        pi = network.findPi(hostname);
                        if (pi != null)
                        {
                            pisToApply.Add(network.findPi(hostname));
                            this.selectCommand(command, pisToApply);
                        }
                        else
                        {
                            Console.WriteLine("Invalid hostname.");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        if(command == 2 || command == 6 || command == 7)
                        {
                            Console.WriteLine("That's a not a good idea... Please choose a different option.");
                                return;
                        }
                        else
                            selectCommand(command, rasPis);
                        break;
                    case "3":
                        Console.WriteLine("Type the ID numbers of the pis you would like separated by spaces.");
                        string stringOfNames = Console.ReadLine();
                        string[] ids = stringOfNames.Split(null);
                        //string[] hosts = new string[ids.Length];
                        int i = 0;
                        foreach (string s in ids)
                        {
                            hostname = "pi-sign-" + s;
                            pi = network.findPi(hostname);
                            if (pi != null)
                            {
                                pisToApply.Add(pi);
                            }
                            else
                            {
                                Console.WriteLine("Invalid pi-name: " + hostname);
                                Console.WriteLine("Please try again.");
                                Console.ReadKey();
                                break;
                            }
                            i++;
                            
                        }

                        break;
                    case "9":
                        return;


                }
            } while (option != "9");

            

        }

        public void selectCommand(int command, List<RaspberryPi> pis)
        {
            Command c;
            switch (command)
            {
                case 1:
                    foreach(RaspberryPi pi in pis)
                    {
                        
                        c = new Status(pi);
                        Task task = new Task(c);
                        threadPool.addTask(task);
                        
                    }
                    break;
                case 2:
                    foreach (RaspberryPi pi in pis)
                    {
                        c = new Reboot(pi);
                        Task task = new Task(c);
                        threadPool.addTask(task);
                        
                    }
                    break;
                case 3:
                    foreach (RaspberryPi pi in pis)
                    {
                        c = new Update(pi);
                        // Send to tasks pool, then issueCommand
                        Task task = new Task(c);
                        threadPool.addTask(task);
                       
                    }
                    break;
                case 4:
                    foreach (RaspberryPi pi in pis)
                    {
                        Console.WriteLine();
                        Console.WriteLine(@"Note: paths in Windows use backslashes for example: S:\ENS\Labs\Raspberry Pi");
                        Console.WriteLine("       paths in Linux use forward slashes for example: /home/pi/scripts/start.py\n");
                        Console.WriteLine("Please type the full path to the file you would like to transfer.");
                        string local = Console.ReadLine();
                        Console.WriteLine("Please type the full path to where you would like the file transferred to.");
                        string remote = Console.ReadLine();
                        c = new Transfer(pi, local, remote);
                        Task task = new Task(c);
                        threadPool.addTask(task);

                    }
                    break;
                case 5:
                    foreach (RaspberryPi pi in pis)
                    {
                        Console.WriteLine("Which package would you like to install? Please make sure it is the correct linux package name");
                        string package = Console.ReadLine();
                        c = new Install(pi, package);
                        Task task = new Task(c);
                        threadPool.addTask(task);
                        
                    }
                    break;
                case 6:
                    foreach (RaspberryPi pi in pis)
                    {
                        c = new Setup(pi);
                        Task task = new Task(c);
                        threadPool.addTask(task);
                    }                    
                    break;
                case 7:
                    
                    foreach (RaspberryPi pi in pis)
                    {
                        c = new OpenShell(pi.getHostname());
                        Task task = new Task(c);
                        threadPool.addTask(task);
                    }
                    break;       

            }

           
        }



    }
}
