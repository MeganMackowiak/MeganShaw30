
namespace EventPlanningProgram;

public class OutdoorGathering : Event
{
    private string _weatherStatement;

    public OutdoorGathering(
        string title,
        string description,
        DateTime date,
        string time,
        string address,
        string weatherStatement)
        : base(title, description, date, time, address)
    {
        _weatherStatement = weatherStatement;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n" +
               $"Expected Weather: {_weatherStatement}";
    }

    public override string GetShortDescription()
    {
        return $"Outdoor Gathering: {base.GetShortDescription()}";
    }
}
