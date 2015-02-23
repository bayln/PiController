using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace PiController.ThreadPool
{
    class ThreadPoolManager
    {

        // All fields of ThreadPool 
        /* Threading Variables */
            // Primitives
        private static int maxThreads = 15;
        private bool started;

            // Objects
        private ConcurrentQueue<WorkerThread> threadPool;
        private ConcurrentQueue<Task> threadQueue;
        private TaskRegistry registry;

        /* Constructors */
        public ThreadPoolManager()
        {
            this.threadPool = new ConcurrentQueue<WorkerThread>();
            this.threadQueue = new ConcurrentQueue<Task>();
            this.registry = new TaskRegistry();
            this.started = false;
            populateThreadPool();            
        }


        public ConcurrentQueue<Task> getThreadQueue()
        {
            return this.threadQueue;
        } 

        public void idleThreadStart()
        {
            while (true)
            {
                bool startThread = false;
                Task taskToDo;
                this.threadQueue.TryPeek(out taskToDo);
                if (taskToDo != null)
                {
                    while (!startThread)
                    {
                        WorkerThread current;
                        this.threadPool.TryDequeue(out current);
                        if (current != null)
                        {
                            startThread = true;
                            current.setGetTask(true);
                        }
                    }
                }  
            }
        }

        public void addBackToQueue(WorkerThread thread)
        {
            lock (threadPool)
            {
                this.threadPool.Enqueue(thread);
            }
        }



        public void populateThreadPool()
        {
            for (int i = 0; i < 15; i++)
            {
                WorkerThread thread = new WorkerThread(this);
                this.threadPool.Enqueue(thread);
            }
        }

        public void startThreadPool()
        {
            foreach (WorkerThread thread in this.threadPool)
            {
                thread.startThread();
            }
            this.started = true;
        }


        public bool threadsActive()
        {
            return this.started;
        }


        public void addTask(Task task)
        {
             this.threadQueue.Enqueue(task);
             return;
        }


    }
}
