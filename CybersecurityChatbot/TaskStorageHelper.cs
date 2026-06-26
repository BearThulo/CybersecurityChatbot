using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CybersecurityChatbot
{
    public class TaskStorageHelper
    {
        private string fileName = "tasks.json";

        public List<CyberTask> LoadTasks()
        {
            if (!File.Exists(fileName))
            {
                return new List<CyberTask>();
            }

            string json = File.ReadAllText(fileName);

            List<CyberTask>? tasks =
                JsonConvert.DeserializeObject<List<CyberTask>>(json);

            return tasks ?? new List<CyberTask>();
        }

        public void SaveTasks(List<CyberTask> tasks)
        {
            string json =
                JsonConvert.SerializeObject(tasks, Formatting.Indented);

            File.WriteAllText(fileName, json);
        }
    }
}