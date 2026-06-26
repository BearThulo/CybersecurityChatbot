using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace CybersecurityChatbot
{
    public partial class MainWindow : Window
    {
        ChatBot bot = new ChatBot();
        SentimentDetector sentiment = new SentimentDetector();
        TaskManager taskManager = new TaskManager();
        ActivityLogger logger = new ActivityLogger();
        NLPProcessor nlp = new NLPProcessor();
        QuizManager quiz = new QuizManager();

        public MainWindow()
        {
            InitializeComponent();

            LoadTasks();

            ChatDisplay.Text =
@"========================================
      CYBERSECURITY AWARENESS BOT
========================================

Welcome!

Commands

• add task Update Password
• remind me to update password tomorrow
• show tasks
• complete task 1
• delete task 1
• start quiz
• what have you done for me

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

        private void RefreshTasksButton_Click(object sender, RoutedEventArgs e)
        {
            LoadTasks();
        }

        private void CompleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem == null)
            {
                MessageBox.Show("Select a task first.");
                return;
            }

            CyberTask task = (CyberTask)TaskList.SelectedItem;

            taskManager.MarkComplete(task.Id);

            logger.LogAction("Completed task: " + task.Title);

            LoadTasks();
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem == null)
            {
                MessageBox.Show("Select a task first.");
                return;
            }

            CyberTask task = (CyberTask)TaskList.SelectedItem;

            taskManager.DeleteTask(task.Id);

            logger.LogAction("Deleted task: " + task.Title);

            LoadTasks();
        }

        private void QuizButton_Click(object sender, RoutedEventArgs e)
        {
            ChatDisplay.Text +=
                "\nBot: Starting Cybersecurity Quiz...\n";

            ChatDisplay.Text +=
                quiz.StartQuiz() + "\n\n";

            logger.LogAction("Started Quiz");
        }

        private void ActivityButton_Click(object sender, RoutedEventArgs e)
        {
            ChatDisplay.Text +=
                "\n====== Activity Log ======\n";

            ChatDisplay.Text +=
                logger.GetActivityLog() + "\n\n";
        }

        private void LoadTasks()
        {
            TaskList.ItemsSource = null;

            List<CyberTask> tasks =
                taskManager.GetTasks();

            TaskList.ItemsSource = tasks;
        }
        private void SendMessage()
        {
            string originalMessage = UserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(originalMessage))
                return;

            string userMessage = originalMessage.ToLower();

            // Quiz Answers
            if (quiz.IsQuizRunning())
            {
                ChatDisplay.Text += "You: " + originalMessage + "\n";

                string reply = quiz.SubmitAnswer(originalMessage);

                ChatDisplay.Text += "Bot: " + reply + "\n\n";

                if (!quiz.IsQuizRunning())
                {
                    logger.LogAction("Completed Cybersecurity Quiz");
                }

                UserInput.Clear();
                return;
            }

            // Add Task
            if (userMessage.StartsWith("add task "))
            {
                string title = originalMessage.Substring(9);

                taskManager.AddTask(
                    title,
                    "No description provided.",
                    "No reminder set.");

                logger.LogAction("Added Task: " + title);

                ChatDisplay.Text +=
                    "You: " + originalMessage + "\n";

                ChatDisplay.Text +=
                    "Bot: Task added successfully.\n\n";

                LoadTasks();

                UserInput.Clear();
                return;
            }

            // Reminder
            if (nlp.IsReminder(userMessage))
            {
                string title = nlp.GetTaskTitle(originalMessage);

                string reminder =
                    nlp.GetReminderDate(originalMessage);

                taskManager.AddTask(
                    title,
                    "Reminder created.",
                    reminder);

                logger.LogAction(
                    "Reminder created for " + title);

                ChatDisplay.Text +=
                    "You: " + originalMessage + "\n";

                ChatDisplay.Text +=
                    "Bot: Reminder set for '" +
                    title +
                    "' on " +
                    reminder +
                    ".\n\n";

                LoadTasks();

                UserInput.Clear();
                return;
            }

            // Show Tasks
            if (userMessage == "show tasks")
            {
                ChatDisplay.Text +=
                    "Bot:\n";

                ChatDisplay.Text +=
                    taskManager.DisplayTasks();

                ChatDisplay.Text += "\n\n";

                UserInput.Clear();
                return;
            }

            // Complete Task
            if (userMessage.StartsWith("complete task "))
            {
                int id = int.Parse(
                    userMessage.Replace("complete task ", ""));

                taskManager.MarkComplete(id);

                logger.LogAction(
                    "Completed Task " + id);

                LoadTasks();

                ChatDisplay.Text +=
                    "Bot: Task completed.\n\n";

                UserInput.Clear();
                return;
            }

            // Delete Task
            if (userMessage.StartsWith("delete task "))
            {
                int id = int.Parse(
                    userMessage.Replace("delete task ", ""));

                taskManager.DeleteTask(id);

                logger.LogAction(
                    "Deleted Task " + id);

                LoadTasks();

                ChatDisplay.Text +=
                    "Bot: Task deleted.\n\n";

                UserInput.Clear();
                return;
            }

            // Activity Log
            if (userMessage == "what have you done for me")
            {
                ChatDisplay.Text +=
                    logger.GetActivityLog();

                ChatDisplay.Text += "\n\n";

                UserInput.Clear();
                return;
            }

            // Start Quiz
            if (userMessage == "start quiz")
            {
                ChatDisplay.Text +=
                    "Bot: Starting Quiz...\n";

                ChatDisplay.Text +=
                    quiz.StartQuiz();

                ChatDisplay.Text += "\n\n";

                logger.LogAction("Started Quiz");

                UserInput.Clear();
                return;
            }

            // Normal Chat
            ChatDisplay.Text +=
                "You: " + originalMessage + "\n";

            string mood =
                sentiment.CheckSentiment(originalMessage);

            if (mood != "")
            {
                ChatDisplay.Text +=
                    "Bot: " + mood + "\n";
            }

            ChatDisplay.Text +=
                "Bot: " +
                bot.GetResponse(originalMessage) +
                "\n\n";

            UserInput.Clear();
        }
    }
}