using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class ActivityLogger
    {
        private List<string> activities = new List<string>();

        public void LogAction(string action)
        {
            string log =
                "[" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "] "
                + action;

            activities.Insert(0, log);
        }

        public string GetActivityLog()
        {
            if (activities.Count == 0)
            {
                return "No activities recorded yet.";
            }

            string log = "";

            foreach (string activity in activities)
            {
                log += activity + "\n";
            }

            return log;
        }
    }
}