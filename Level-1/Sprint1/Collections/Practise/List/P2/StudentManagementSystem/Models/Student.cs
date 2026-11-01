namespace Models ;
public class Student
{
    public int Id { get; set; }
    public string  Name { get; set; }
    public double Grade { get; set; }
    public Student (
    int id , 
    string name , 
    double grade
)
    {
        this.Id = id ; 
        this.Name = name ;
        this.Grade = grade;
    }
}