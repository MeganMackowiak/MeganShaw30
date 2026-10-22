
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return GetPoints();
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";

        return $"{status} {GetName()} ({GetDescription()})";
    }

    public override string GetSaveString()
    {
        return $"Simple|{GetName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }

    public void SetComplete(bool complete)
    {
        _isComplete = complete;
    }
}
