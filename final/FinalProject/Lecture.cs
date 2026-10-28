
namespace EventPlanningProgram;

public class Lecture : Event
{
    private string _speakerName;
    private int _capacity;

    public Lecture(
        string title,
        string description,
        DateTime date,
        string time,
        string address,
        string speakerName,
        int capacity)
        : base(title, description, date, time, address)
    {
        _speakerName = speakerName;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n" +
               $"Speaker: {_speakerName}\n" +
               $"Capacity: {_capacity} people";
    }

    public override string GetShortDescription()
    {
        return $"Lecture: {base.GetShortDescription()}";
    }
}
