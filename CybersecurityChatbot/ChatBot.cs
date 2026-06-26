using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
 
namespace CybersecurityChatbot
{
    public class ChatBot
    {
        Random random = new Random();

        string lastTopic = "";

        Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>()
        {
            {
                "password",
                new List<string>()
                {
                    "Use strong passwords with numbers and symbols.",
                    "Do not use personal information in passwords.",
                    "Change your passwords regularly."
                }
            },

            {
                "phishing",
                new List<string>()
                {
                    "Avoid clicking suspicious email links.",
                    "Scammers often pretend to be trusted companies.",
                    "Always check emails carefully before responding."
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
            },

            {
                "scam",
                new List<string>()
                {
                    "Be careful of fake online giveaways.",
                    "Do not share banking details with strangers online.",
                    "Scammers often try to create panic."
                }
            }
        };

        public string GetResponse(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return "Please type something.";
            }

            message = message.ToLower();

            // Greeting
            if (message.Contains("hello") || message.Contains("hi"))
            {
                return "Hello! How can I help you today?";
            }

            // Simple password check
            if (message.Length >= 8 &&
                message.Any(char.IsDigit))
            {
                return "That looks like a strong password.";
            }

            // Continue previous topic
            if (message.Contains("tell me more"))
            {
                if (lastTopic != "")
                {
                    return "Here is more information about " + lastTopic + ". Staying informed helps you stay safe online.";
                }
            }

            // Keyword responses
            foreach (string keyword in responses.Keys)
            {
                if (message.Contains(keyword))
                {
                    lastTopic = keyword;

                    List<string> replyList = responses[keyword];

                    int number = random.Next(replyList.Count);

                    return replyList[number];
                }
            }

            return "I am not sure I understand. Try asking about passwords, phishing, scams, or privacy.";
        }
    }
}