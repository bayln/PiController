using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PiController.ThreadPool
{
    class WorkerThread
    {

        // Private vars
        private Thread thread;
        private ThreadPoolManager manager;
        public ThreadStart start;
        private bool getTask;


        public WorkerThread(ThreadPoolManager manager)
        {
            this.manager = manager;
            this.start = new ThreadStart(this.runThread);
            this.thread = new Thread(start);
        }


        public void runThread()
        {
            while (true)

            if(getTask)
            {
                Task task = null;


                if (manager.getThreadQueue().TryPeek(out task))
                    manager.getThreadQueue().TryDequeue(out task);

                if (task != null)
                    task.executeTask();
                

            }    
        }

        public void setGetTask(bool b)
        {
            this.getTask = b;
        }


    }
}
