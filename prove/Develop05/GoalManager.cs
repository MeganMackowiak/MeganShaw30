
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public int GetScore()
    {
        return _score;
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public int RecordGoal(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            return 0;
        }

        int earned = _goals[index].RecordEvent();
        _score += earned;
        return earned;
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You haven't created any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"Score|{_score}");

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetSaveString());
            }
        }

        Console.WriteLine("Your goals have been saved!");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        List<Goal> loadedGoals = new List<Goal>();
        int loadedScore = 0;

        try
        {
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (parts[0] == "Score")
                {
                    loadedScore = int.Parse(parts[1]);
                }
                else if (parts[0] == "Simple" && parts.Length == 5)
                {
                    SimpleGoal goal = new SimpleGoal(
                        parts[1], parts[2], int.Parse(parts[3]));

                    goal.SetComplete(bool.Parse(parts[4]));
                    loadedGoals.Add(goal);
                }
                else if (parts[0] == "Eternal" && parts.Length == 4)
                {
                    loadedGoals.Add(new EternalGoal(
                        parts[1], parts[2], int.Parse(parts[3])));
                }
                else if (parts[0] == "Checklist" && parts.Length == 7)
                {
                    ChecklistGoal goal = new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]));

                    goal.SetAmountCompleted(int.Parse(parts[6]));
                    loadedGoals.Add(goal);
                }
                else
                {
                    throw new FormatException("Invalid save file format.");
                }
            }

            _goals = loadedGoals;
            _score = loadedScore;

            Console.WriteLine("Your goals have been loaded!");
        }
        catch (Exception)
        {
            Console.WriteLine(
                "Could not load the file. Check that it is a valid save file.");
        }
    }
}
