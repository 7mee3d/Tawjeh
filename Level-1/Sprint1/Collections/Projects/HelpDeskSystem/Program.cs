public class Program
{


    private static void Main(string[] args)
    {
        HelpDeskSystemOperations system = new HelpDeskSystemOperations();

        Console.WriteLine("--- System Started ---");

        // 1. Customers entering the system (Queue & Dictionary)
        system.AddNewTicket("Ahmed El-Mobayed", "Login issue");
        system.AddNewTicket("Sara Kamal", "Payment not working");
        system.AddNewTicket("Mahmoud Sedky", "Checkout button missing");

        // 2. Search for a specific ticket (Dictionary)
        system.FindTicket(2); // Sara

        // 3. Process tickets (Queue to List)
        Console.WriteLine("\n--- Processing Tickets ---");
        system.ProcessNextTicket(); // Will process Ahmed
        system.ProcessNextTicket(); // Will process Sara

        // 4. Undo an action (Stack)
        system.UndoLastAction(); // Will pop "Ticket #2 has been resolved"

        // 5. Print the report (List)
        system.PrintResolvedReport();

        // 6. Search again to see the updated status
        system.FindTicket(1); // Status will be "Resolved"

    }


}