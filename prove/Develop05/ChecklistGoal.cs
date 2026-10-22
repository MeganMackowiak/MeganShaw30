
public class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _amountCompleted;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;

        int earned = GetPoints();

        if (_amountCompleted == _target)
        {
            earned += _bonus;
        }

        return earned;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";

        return $"{status} {GetName()} ({GetDescription()}) " +
               $"Completed {_amountCompleted}/{_target} times. " +
               $"Bonus: {_bonus}";
    }

    public override string GetSaveString()
    {
        return $"Checklist|{GetName()}|{GetDescription()}|" +
               $"{GetPoints()}|{_target}|{_bonus}|{_amountCompleted}";
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = Math.Clamp(amount, 0, _target);
    }
}
