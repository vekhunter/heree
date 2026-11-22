public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_name}:{_description}:{_points}";
    }

    public static EternalGoal FromString(string data)
    {
        string[] parts = data.Split(':');
        return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
    }
}
