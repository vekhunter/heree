public class QuestManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public int GetScore()
    {
        return _score;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void ListGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name}");
        }

        Console.Write("Which goal did you accomplish? ");
        if (!int.TryParse(Console.ReadLine(), out int selection) ||
            selection < 1 || selection > _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        int points = _goals[selection - 1].RecordEvent();
        _score += points;
        Console.WriteLine($"Congratulations! You have earned {points} points!");
        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals(string filename)
    {
        using StreamWriter output = new StreamWriter(filename);
        output.WriteLine(_score);
        foreach (Goal goal in _goals)
        {
            output.WriteLine(goal.GetStringRepresentation());
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals = new List<Goal>();

        if (lines.Length == 0)
        {
            _score = 0;
            return;
        }

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (line.StartsWith("SimpleGoal:"))
            {
                _goals.Add(SimpleGoal.FromString(line));
            }
            else if (line.StartsWith("EternalGoal:"))
            {
                _goals.Add(EternalGoal.FromString(line));
            }
            else if (line.StartsWith("ChecklistGoal:"))
            {
                _goals.Add(ChecklistGoal.FromString(line));
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}
