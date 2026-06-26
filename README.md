# Cybersecurity Awareness Chatbot
## About the Project
This project is a Cybersecurity Awareness Chatbot that was developed using C# and WPF in Visual Studio.

## Features
The chatbot can:
- Respond to cybersecurity-related questions
- Recognise keywords such as password, phishing, privacy, and scam
- Provide random responses for a more natural conversation
- Detect basic user emotions through sentiment detection
- Remember previous topics discussed
- Continue conversations when the user asks for more information
- Check if a password appears strong
- Handle invalid or unknown input

## Technologies Used
- C#
- WPF (Windows Presentation Foundation)
- .NET 8
- Visual Studio 2022
- GitHub

## Project Files

### MainWindow.xaml
This file contains the design of the chatbot interface, including the chat area, text box, and send button.

### MainWindow.xaml.cs
This file handles user interactions and connects the interface to the chatbot logic.

### ChatBot.cs
This is the main chatbot class. It contains the responses, keyword recognition, random response generation, and conversation flow logic.

### SentimentDetector.cs
This class checks user messages for words that may indicate emotions and provides appropriate responses.

### MemoryStore.cs
This class stores information about previous topics so the chatbot can remember parts of the conversation.

## Example Questions
Some examples of questions or inputs the chatbot can respond to are:
- What is phishing?
- Tell me about passwords.
- How can I protect my privacy online?
- What is a scam?
- Tell me more.
- Hello

## How to Run the Program
1. Open the project in Visual Studio 2022.
2. Build the solution.
3. Run the application.
4. Enter a message in the text box.
5. Click the Send button or press Enter.

## GitHub
GitHub was used for version control throughout the development of the project. Multiple commits were created to track progress and improvements made to the chatbot.


## Author
Morena
