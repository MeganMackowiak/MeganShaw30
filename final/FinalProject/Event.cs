
namespace EventPlanningProgram;

public class Event
{
    private string _title;
    private string _description;
    private DateTime _date;
    private string _time;
    private string _address;

    public Event(string title, string description, DateTime date, string time, string address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {_title}\n" +
               $"Description: {_description}\n" +
               $"Date: {_date:MMMM d, yyyy}\n" +
               $"Time: {_time}\n" +
               $"Address: {_address}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Event: {_title} | Date: {_date:MMMM d, yyyy}";
    }
}
