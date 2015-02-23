using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PiController.Network;
using PiController.Utilities;
using PiController.ThreadPool;
using System.Collections;
using PiController.PiClasses;

namespace PiController
{
    class Program
    {
        /// <summary>
        /// 1) Sets up overlay
        /// 2) Creates threadpool
        /// 3) Creates InteractiveCommandParser
        /// 4) ?????
        /// 5) Profit
        /// </summary>
        /// <param name="args"> No command line arguments for PiController </param>
        static void Main(string[] args)
        {
            // Step 1: Create Overlay
            Overlay overlay = new Overlay();
            
            List<string> online = overlay.getOnline();
            List<RaspberryPi> pis = overlay.getPis();
            int alive = online.Count;
            // Step 2: Create threadpool
            ThreadPoolManager threadPool = new ThreadPoolManager();
            threadPool.startThreadPool();                        
            Console.WriteLine("\n"); 
            // Step 3: Create Interactive command parser
            InteractiveCommandParser parser = new InteractiveCommandParser(ref overlay, ref threadPool);
            parser.ParseCommands(alive);
            try
            {
                System.Environment.Exit(0);
            }
            catch (Exception)
            {
                System.Environment.Exit(0);
            }
           
        }
    }
}

/* Stylistic Notes *\
 * Keep main short -> large static methods = :'(
 * Give the /// comments before particularly large methods
 * or methods that are ambiguous (not getters or setters for example)

/* Next time working on this notes:
* Get commands sent to all of the command classes
* get status working
*/