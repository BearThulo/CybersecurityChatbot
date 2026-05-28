namespace CybersecurityChatbot
{
    public class SentimentDetector
    {
        public string CheckSentiment(string message)
        {
            message = message.ToLower();

            if (message.Contains("worried"))
            {
                return "It is understandable to feel worried about cybersecurity threats.";
            }

            if (message.Contains("frustrated"))
            {
                return "Cybersecurity can sometimes feel confusing.";
            }

            if (message.Contains("curious"))
            {
                return "Learning about cybersecurity is always a good idea.";
            }

            return "";
        }
    }
}