using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class ChatBot
    {
        Random random = new Random();

        Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>()
        {
            {
                "password",
                new List<string>()
                {
                    "Use strong passwords with numbers and symbols.",
                    "Avoid using personal information in passwords.",
                    "Change your passwords regularly."
                }
            },

            {
                "phishing",
                new List<string>()
                {
                    "Avoid clicking suspicious email links.",
                    "Scammers often pretend to be trusted companies.",
                    "Always verify emails before responding."
                }
            },

            {
                "privacy",
                new List<string>()
                {
                    "Keep your personal information private online.",
                    "Review your privacy settings regularly.",
                    "Use two-factor authentication."
                }
            }
        };

        public string GetResponse(string message)
        {
            message = message.ToLower();

            foreach (string keyword in responses.Keys)
            {
                if (message.Contains(keyword))
                {
                    List<string> replyList = responses[keyword];

                    int number = random.Next(replyList.Count);

                    return replyList[number];
                }
            }

            return "I am not sure I understand. Try asking about passwords, phishing, or privacy.";
        }
    }
}