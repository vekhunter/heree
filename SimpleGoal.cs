public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_name}:{_description}:{_points}:{_isComplete}";
    }

    public static SimpleGoal FromString(string data)
    {
        string[] parts = data.Split(':');
        SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]))
        {
        };
        return bool.TryParse(parts[4], out bool complete) && complete
            ? goal.WithCompletedState(true)
            : goal;
    }

    private SimpleGoal WithCompletedState(bool complete)
    {
        _isComplete = complete;
        return this;
    }
}
