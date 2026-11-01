
public class Ticket
{
    public Ticket(int id, string name, string issue, bool IsResolved)
    {
        this.Id = id;
        this.CustomerName = name;
        this.Issue = issue;
        this.IsResolved = IsResolved;
    }


    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Issue { get; set; } = string.Empty;
    public bool IsResolved { get; set; } = false;


}

