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

            ChatDisplay.Text = "Cybersecurity Bot: Hello! Ask me about cybersecurity.\n\n";
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