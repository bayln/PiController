using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

namespace PiController.ThreadPool
{
    class TaskRegistry
    {
        ConcurrentQueue<Task> completedTasks;        // Queues up tasks that the ICP parses

        // Constructor
        public TaskRegistry()
        {
            completedTasks = new ConcurrentQueue<Task>();
        }


        public void addCompletedTask(Task task)
        {
            lock (completedTasks)
            {
                completedTasks.Enqueue(task);
            }
        }
        



        
    }
}
