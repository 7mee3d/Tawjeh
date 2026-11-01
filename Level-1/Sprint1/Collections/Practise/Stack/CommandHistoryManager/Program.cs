
public class Program
{
    public class Command
    {
        private readonly string _Url;
        private readonly DateTime _CreatedAt;

        public Command(string url)
        {
            this._Url = url;
            this._CreatedAt = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"[{_CreatedAt.ToString("yyyy/MM/dd hh:mm")}] {_Url}";
        }
    }

    private static void Main(string[] args)
    {
        Stack<Command> undo = new();
        Stack<Command> redo = new();

        while (true)
        {
            string line = string.Empty;
            System.Console.WriteLine("Enter url ('exit or quit')");
            line = Console.ReadLine().ToLower();

            if (line == "exit")
                break;

            switch (line)
            {
                case "back":
                    {
                        if (undo.TryPop(out var item))
                        {
                            redo.Push(item);
                        }
                        else continue;

                        break;
                    }
                case "forward":
                    {
                        if (redo.TryPop(out var item))
                        {
                            undo.Push(item);
                        }
                        else continue;

                        break;
                    }
                default:
                    {
                        undo.Push(new Command(line));
                        break;
                    }
            }
            Console.Clear();
            Print("Forward" , redo);
            Print("Back" , undo);
        }
    }

    private static void Print(string nameCommand , Stack<Command> commands)
    {
        System.Console.WriteLine($"Command name {nameCommand}\n");
        foreach(var item in commands)
            System.Console.WriteLine($"\t{item}");
    }
}


