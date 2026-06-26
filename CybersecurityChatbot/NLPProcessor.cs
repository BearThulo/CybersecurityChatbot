namespace CybersecurityChatbot
{
    public class NLPProcessor
    {
        public bool IsReminder(string message)
        {
            message = message.ToLower();

            return message.StartsWith("remind me to");
        }
         
        public string GetTaskTitle(string message)
        {
            message = message.ToLower();

            message = message.Replace("remind me to ", "");

            message = message.Replace(" tomorrow", "");

            return message.Trim();
        }

        public string GetReminderDate(string message)
        {
            message = message.ToLower();

            if (message.Contains("tomorrow"))
            {
                return "Tomorrow";
            }

            return "No reminder";
        }
    }
}