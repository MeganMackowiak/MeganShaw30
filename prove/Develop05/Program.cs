
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== ETERNAL QUEST =====");

            int score = manager.GetScore();
            int level = score / 500 + 1;

            Console.WriteLine($"Total Score: {score}");
            Console.WriteLine($"Current Level: {level}");
            Console.WriteLine($"Points to Next Level: {500 - score % 500}");

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;

                case "3":
                    RecordGoal(manager);
                    break;

                case "4":
                    Console.Write("Enter filename: ");
                    string saveFile = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(saveFile))
                    {
                        manager.SaveGoals(saveFile);
                    }
                    break;

                case "5":
                    Console.Write("Enter filename: ");
                    string loadFile = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(loadFile))
                    {
                        manager.LoadGoals(loadFile);
                    }
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Good luck on your Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("Please choose a number from 1 to 6.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nWhat kind of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose a type: ");

        string type = Console.ReadLine() ?? "";

        if (type != "1" && type != "2" && type != "3")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(description) ||
            name.Contains('|') || description.Contains('|'))
        {
            Console.WriteLine(
                "Please enter a name and description without the | character.");
            return;
        }

        int points = ReadPositiveInt("How many points is this goal worth?");

        if (type == "1")
        {
            manager.AddGoal(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            manager.AddGoal(new EternalGoal(name, description, points));
        }
        else
        {
            int target = ReadPositiveInt(
                "How many times must you complete it?");

            int bonus = ReadPositiveInt(
                "How many bonus points will you earn at the end?");

            manager.AddGoal(
                new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created successfully!");
    }

    static void RecordGoal(GoalManager manager)
    {
        if (manager.GetGoals().Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        Console.WriteLine("\nChoose a goal to record:");
        manager.DisplayGoals();

        int selection = ReadPositiveInt("Enter the goal number: ");

        if (selection > manager.GetGoals().Count)
        {
            Console.WriteLine("That goal number does not exist.");
            return;
        }

        int earned = manager.RecordGoal(selection - 1);

        if (earned > 0)
        {
            Console.WriteLine($"Congratulations! You earned {earned} points!");
        }
        else
        {
            Console.WriteLine(
                "No points earned. This goal may already be complete.");
        }
    }

    static int ReadPositiveInt(string prompt)
    {
        int number;

        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out number) && number > 0)
            {
                return number;
            }

            Console.WriteLine("Please enter a positive whole number.");
        }
    }
}
