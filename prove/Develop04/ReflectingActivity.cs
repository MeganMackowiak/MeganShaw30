
using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random = new Random();

    public ReflectingActivity()
        : base("Reflecting Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different from other times?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        List<string> prompts = new List<string>(_prompts);
        List<string> questions = new List<string>(_questions);

        Shuffle(prompts);
        Shuffle(questions);

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        Console.WriteLine(prompts[0]);
        Console.WriteLine();
        Console.Write("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        int questionIndex = 0;

        while (DateTime.Now < endTime)
        {
            if (questionIndex >= questions.Count)
            {
                Shuffle(questions);
                questionIndex = 0;
            }

            Console.WriteLine();
            Console.WriteLine(questions[questionIndex]);
            Console.WriteLine();

            ShowSpinner(5);
            questionIndex++;
        }

        DisplayEndingMessage();
    }

    private void Shuffle(List<string> items)
    {
        for (int i = items.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);

            string temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}
