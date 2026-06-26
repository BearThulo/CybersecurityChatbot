namespace CybersecurityChatbot
{
    public class CyberTask
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Reminder { get; set; }

        public bool IsComplete { get; set; }

        public override string ToString()
        {
            if (IsComplete)
            {
                return "✔ " + Title;
            }

            return "✖ " + Title;
        }
    }
}