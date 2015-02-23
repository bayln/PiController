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
        private ThreadStart start;
        private bool getTask;


        public WorkerThread(ThreadPoolManager manager)
        {
            this.manager = manager;
            this.start = new ThreadStart(this.runThread);
            this.thread = new Thread(start);
            this.getTask = false;
        }

        public void startThread()
        {
            this.thread.Start();
        }


        public void runThread()
        {
            while (true)    // Busy wait here
            {

                if (getTask)
                {
                    Task task = null;


                    if (manager.getThreadQueue().TryPeek(out task))
                        manager.getThreadQueue().TryDequeue(out task);

                    if (task != null)
                        task.executeTask();

                    this.getTask = false;
                    manager.addBackToQueue(this);


                }
            }
        }

        public void setGetTask(bool b)
        {
            this.getTask = b;
        }


    }
}
