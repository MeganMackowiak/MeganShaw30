
namespace EventPlanningProgram;

public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(
        string title,
        string description,
        DateTime date,
        string time,
        string address,
        string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n" +
               $"RSVP Email: {_rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Reception: {base.GetShortDescription()}";
    }
}
