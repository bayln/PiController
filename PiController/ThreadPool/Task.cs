using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PiController.PiClasses;

namespace PiController.ThreadPool
{
    class Task
    {
        // Private Variables that make up a task
        private Command command;

        /* Constructor */
        public Task(Command comm)
        {
            this.command = comm;
        }

        public void executeTask()
        {
            this.command.issueCommand();
            return;
        }
    }
}
