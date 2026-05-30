using System.Windows;
using System.Windows.Input;

namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        ChatBot bot = new ChatBot();

        SentimentDetector sentiment = new SentimentDetector();

        public MainWindow()
        {
            InitializeComponent();

            ChatDisplay.Text =
@"  _____       _               
 / ____|     | |              
| |    _   _ | |__    ___ _ __
| |   | | | || '_ \  / _ \ '__|
| |___| |_| || |_) ||  __/ |   
 \_____\__, ||_.__/  \___|_|   
        __/ |                  
       |___/                   

========================================
      CYBERSECURITY AWARENESS BOT
========================================

Hello and welcome!

I can help you learn about:
• Password Safety
• Phishing Attacks
• Online Privacy
• Cyber Scams

Type a question below to get started.

";
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }


        private void SendMessage()
        {
            string userMessage = UserInput.Text;

            ChatDisplay.Text += "You: " + userMessage + "\n";

            string mood = sentiment.CheckSentiment(userMessage);


            if (mood != "")
            {
                ChatDisplay.Text += "Bot: " + mood + "\n";
            }

            string botReply = bot.GetResponse(userMessage);

            ChatDisplay.Text += "Bot: " + botReply + "\n\n";

            UserInput.Clear();

        }
    }
}