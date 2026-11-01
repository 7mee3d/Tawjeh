public class HelpDeskSystemOperations
{
    private Queue<Ticket> tickets = new();
    private Dictionary<int, Ticket> PairsTickets = new();
    private Stack<string> process = new();
    private List<Ticket> finshedTickets = new();
    
    private int _nextId = 1;

    public void AddNewTicket(string name, string issue)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(issue))
        {
            System.Console.WriteLine("invalid data");
            return;
        }

        var newTicket = new Ticket(_nextId, name, issue, false);

        tickets.Enqueue(newTicket);
        PairsTickets.Add(_nextId, newTicket);
        process.Push($"Add new ticket id = {_nextId}");

        _nextId++;
    }

    public void ProcessNextTicket()
    {
        if (tickets.TryDequeue(out var ticket))
        {
            ticket.IsResolved = true;

            finshedTickets.Add(ticket);
            process.Push($"Ticket id = {ticket.Id} is finished processing ");
        }
        else
            System.Console.WriteLine("Not found any tickets");
    }

    public void FindTicket(int id)
    {
        if (id <= 0)
        {
            System.Console.WriteLine("Invalid data ");
            return;
        }

        if (PairsTickets.TryGetValue(id, out var ticket))
        {
            System.Console.WriteLine("The TIcket informations is : \n");
            System.Console.WriteLine($"Id = {ticket.Id}");
            System.Console.WriteLine($"Customer Name : {ticket.CustomerName}");
            System.Console.WriteLine($"Issue : {ticket.Issue}");
            System.Console.WriteLine($"Is Solve : {(ticket.IsResolved ? "True" : "False")}");
        }
        else
        {
            System.Console.WriteLine("TIcket not founded");
        }
    }

    public void UndoLastAction()
    {
        if (process.TryPop(out var action))
            System.Console.WriteLine(action);
        else System.Console.WriteLine("Not any process");
    }

    public void PrintResolvedReport()
    {
        Console.WriteLine("\n=== Resolved Tickets Report ===");
        if (finshedTickets.Count == 0)
        {
            Console.WriteLine("No tickets have been resolved yet.");
        }
        else
        {
            foreach (var ticket in finshedTickets)
            {
                Console.WriteLine($"Ticket ID: {ticket.Id} | Customer: {ticket.CustomerName} | Issue: {ticket.Issue}");
            }
        }
        Console.WriteLine("===============================\n");
    }
}