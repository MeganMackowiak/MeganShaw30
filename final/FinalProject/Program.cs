
namespace EventPlanningProgram;

public class Program
{
    private List<Event> _events = new List<Event>();

    public static void Main(string[] args)
    {
        Program program = new Program();

        program.CreateEvents();
        program.RunProgram();
    }

    public void CreateEvents()
    {
        Lecture lecture = new Lecture(
            "Getting Started with Photography",
            "Learn the basics of taking better photos.",
            new DateTime(2026, 11, 5),
            "6:00 PM",
            "Community Center, Room 2",
            "Jordan Lee",
            40);

        Reception reception = new Reception(
            "Community Appreciation Reception",
            "An evening to thank local volunteers.",
            new DateTime(2026, 11, 12),
            "7:00 PM",
            "Riverside Hall",
            "events@example.com");

        OutdoorGathering gathering = new OutdoorGathering(
            "Fall Picnic",
            "Bring a blanket and enjoy food and games outside.",
            new DateTime(2026, 11, 15),
            "12:00 PM",
            "Pine Park, Picnic Area",
            "Cool and partly cloudy. Bring a jacket.");

        _events.Add(lecture);
        _events.Add(reception);
        _events.Add(gathering);
    }

    public void RunProgram()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Event Planning Program ===");
            Console.WriteLine("1. View all event summaries");
            Console.WriteLine("2. View full details for all events");
            Console.WriteLine("3. Quit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayEvents(false);
                    break;

                case "2":
                    DisplayEvents(true);
                    break;

                case "3":
                    running = false;
                    Console.WriteLine(
                        "Thanks for using the Event Planning Program!");
                    break;

                default:
                    Console.WriteLine(
                        "Please enter 1, 2, or 3.");
                    break;
            }
        }
    }

    public void DisplayEvents(bool showFullDetails)
    {
        Console.WriteLine();

        foreach (Event eventItem in _events)
        {
            if (showFullDetails)
            {
                Console.WriteLine(eventItem.GetFullDetails());
            }
            else
            {
                Console.WriteLine(eventItem.GetShortDescription());
            }

            Console.WriteLine("------------------------------");
        }
    }
}
