using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbot
{
    public class TaskManager
    {
        private TaskStorageHelper storage = new TaskStorageHelper();

        public List<CyberTask> GetTasks()
        {
            return storage.LoadTasks();
        }

        public void AddTask(string title, string description, string reminder)
        {
            List<CyberTask> tasks = storage.LoadTasks();

            CyberTask task = new CyberTask();

            if (tasks.Count == 0)
            {
                task.Id = 1;
            }
            else
            {
                task.Id = tasks.Max(t => t.Id) + 1;
            }

            task.Title = title;
            task.Description = description;
            task.Reminder = reminder;
            task.IsComplete = false;

            tasks.Add(task);

            storage.SaveTasks(tasks);
        }

        public void MarkComplete(int id)
        {
            List<CyberTask> tasks = storage.LoadTasks();

            CyberTask task = tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                task.IsComplete = true;

                storage.SaveTasks(tasks);
            }
        }

        public void DeleteTask(int id)
        {
            List<CyberTask> tasks = storage.LoadTasks();

            CyberTask task = tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                tasks.Remove(task);

                storage.SaveTasks(tasks);
            }
        }

        public CyberTask SearchTask(int id)
        {
            List<CyberTask> tasks = storage.LoadTasks();

            return tasks.FirstOrDefault(t => t.Id == id);
        }

        public string DisplayTasks()
        {
            List<CyberTask> tasks = storage.LoadTasks();

            if (tasks.Count == 0)
            {
                return "No tasks available.";
            }

            string output = "";

            foreach (CyberTask task in tasks)
            {
                string status;

                if (task.IsComplete)
                {
                    status = "Completed";
                }
                else
                {
                    status = "Pending";
                }

                output +=
                    "Task ID: " + task.Id +
                    "\nTitle: " + task.Title +
                    "\nDescription: " + task.Description +
                    "\nReminder: " + task.Reminder +
                    "\nStatus: " + status +
                    "\n-------------------------\n";
            }

            return output;
        }
    }
}