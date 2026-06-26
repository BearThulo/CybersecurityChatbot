using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class QuizManager
    {
        private List<QuizQuestion> questions = new List<QuizQuestion>()
        {
            new QuizQuestion()
            {
                Question="1. What should a strong password include?",
                Answer="numbers and symbols"
            },

            new QuizQuestion()
            {
                Question="2. What type of attack uses fake emails?",
                Answer="phishing"
            },

            new QuizQuestion()
            {
                Question="3. Should you share your password?",
                Answer="no"
            },

            new QuizQuestion()
            {
                Question="4. What does 2FA stand for?",
                Answer="two-factor authentication"
            },

            new QuizQuestion()
            {
                Question="5. Should you click suspicious links?",
                Answer="no"
            },

            new QuizQuestion()
            {
                Question="6. What software protects your computer from viruses?",
                Answer="antivirus"
            },

            new QuizQuestion()
            {
                Question="7. What device connects you to the internet?",
                Answer="router"
            },

            new QuizQuestion()
            {
                Question="8. What does VPN stand for?",
                Answer="virtual private network"
            },

            new QuizQuestion()
            {
                Question="9. What is malware?",
                Answer="malicious software"
            },

            new QuizQuestion()
            {
                Question="10. What should you do before opening an unknown attachment?",
                Answer="scan it"
            }
        };

        private int currentQuestion = 0;
        private int score = 0;
        private bool quizRunning = false;

        public bool IsQuizRunning()
        {
            return quizRunning;
        }

        public string StartQuiz()
        {
            currentQuestion = 0;
            score = 0;
            quizRunning = true;

            return questions[currentQuestion].Question;
        }

        public string SubmitAnswer(string answer)
        {
            string reply = "";

            if (answer.ToLower() == questions[currentQuestion].Answer.ToLower())
            {
                score++;
                reply = "✅ Correct!\n";
            }
            else
            {
                reply = "❌ Incorrect.\nCorrect answer: "
                        + questions[currentQuestion].Answer + "\n";
            }

            currentQuestion++;

            if (currentQuestion >= questions.Count)
            {
                quizRunning = false;

                reply += "\n====================";
                reply += "\nQuiz Finished!";
                reply += "\nFinal Score: "
                      + score + "/" + questions.Count;

                if (score >= 8)
                {
                    reply += "\nExcellent work!";
                }
                else if (score >= 5)
                {
                    reply += "\nGood job!";
                }
                else
                {
                    reply += "\nKeep practising cybersecurity.";
                }

                return reply;
            }

            reply += "\n\n";
            reply += questions[currentQuestion].Question;

            return reply;
        }
    }
}