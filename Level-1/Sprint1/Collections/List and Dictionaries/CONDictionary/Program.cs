public class Program
{

    private static void Main(string[] args)
    {
        var artical = @"Dot NET is a free cross-platform and open source developer platform
for building many different types of applications
With Dot NET you can use multiple languages and libraries
to build for web and IoT";


        Dictionary<char, List<string>> pairs = new Dictionary<char, List<string>>();

        foreach (var word in artical.Split())
        {
            foreach (var ch in word)
            {
                if (!pairs.ContainsKey(ch))
                {
                    pairs.Add(ch, new List<string> { word });
                }
                else
                {
                    pairs[ch].Add(word);
                }
            }
        }


        // print 

        foreach (var entry in pairs)
        {

            System.Console.WriteLine($"Key : {entry.Key}");

            foreach (var value in entry.Value)
            {
                System.Console.WriteLine($"Key[{entry.Key}] -> {value.ToString()}");
            }
        }


        // s2 


        var emps = new List<Employee>
{
    new Employee {Id = 100, Name = "Reem S.", ReportTo = null},
    new Employee {Id = 101, Name = "Raed M.", ReportTo = 100 },
    new Employee {Id = 102, Name = "Ali B.", ReportTo = 100 },
    new Employee {Id = 103, Name = "Abeer S.", ReportTo = 102 },
    new Employee {Id = 104, Name = "Radwan N.", ReportTo = 102 },
    new Employee {Id = 105, Name = "Nancy R.", ReportTo = 101 },
    new Employee {Id = 106, Name = "Saleh A.", ReportTo = 104 }
};

System.Console.WriteLine("\n\n\n\n\n\n\n\n\n");
        //var managers = emps.GroupBy(x => x.ReportTo);
        var managers = emps.ToLookup(x => x.ReportTo).ToDictionary(x => x.Key ?? -1, x => x.ToList());

        foreach (var entry in managers)
        {
            System.Console.WriteLine($"[Man] - {entry.Key}");

            foreach(var value in entry.Value)
            {
                System.Console.WriteLine($"{value}");
            }
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ReportTo { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
    }
}