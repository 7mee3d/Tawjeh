public class Program
{
    private class PrinterJob
    {
        private readonly string _Task;
        private readonly int _copies;

        public PrinterJob(string task, int copies)
        {
            _Task = task;
            _copies = copies;
        }

        public override string ToString()
        {
            return $"[{_Task}] - #copies[{_copies}]";
        }

    }

    private static void Main(string[] args)
    {
        Queue<PrinterJob> printerJobs = new();

        printerJobs.Enqueue(new PrinterJob("Test.pdf", 5));
        printerJobs.Enqueue(new PrinterJob("MarksStudents.pdf", 2));
        printerJobs.Enqueue(new PrinterJob("Customers.pdf", 1));
        printerJobs.Enqueue(new PrinterJob("Employees.pdf", 10));

        Random rn = new Random();

        while (printerJobs.Count > 0)
        {
            var job = printerJobs.Dequeue();
            System.Console.WriteLine($"Printing ... [{job}]");
            System.Threading.Thread.Sleep(rn.Next(1, 5) * 1000); // convert to s 
        }
    }
}