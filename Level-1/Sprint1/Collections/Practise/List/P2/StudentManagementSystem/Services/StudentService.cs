using Models;

namespace Services;


public class StudentService
{

    private List<Student> _students = new();//Target typed new 

    public void Add(string name, double grade)
    {
        int lastId = 0;
        if (_students.Count > 0)
        {
            lastId = _students[^1].Id;// Index from end operator -> stand of students[students.Count - 1]

            // using linq 
            //lastId = _students.LastOrDefault().Id;
            //lastId = _students.Count > 0 ? _students.Max(x=> x.Id ) : 0 ; 
        }

        Student student = new Student(lastId + 1, name, grade);

        _students.Add(student);
        System.Console.WriteLine("\nThe student is added successfully");

    }

    public void Show()
    {
        if (_students.Count == 0)
        {
            System.Console.WriteLine("no data students");
            return;
        }

        foreach (var e in _students)
        {
            System.Console.WriteLine($"Student id : {e.Id}");
            System.Console.WriteLine($"Student name : {e.Name}");
            System.Console.WriteLine($"Student Grade : {e.Grade}\n");
        }

    }

    public void Remove(int id)
    {
        if (id <= 0)
        {
            System.Console.WriteLine("Invalid data id ");
            return;
        }

        if (_students.Count == 0)
        {
            System.Console.WriteLine("no student data");
            return;
        }


        int index = -1;

        for (int counter = 0; counter < _students.Count; counter++)
        {

            if (_students[counter].Id == id)
            {

                index = counter;
                break;
            }


        }

        if (index < 0)
        {
            System.Console.WriteLine("Student does not exists");
            return;
        }

        _students.RemoveAt(index);
        System.Console.WriteLine("The Student is removed");
    }

    public void Update(int id, string newName, double newGrade)
    {
        if (id <= 0)
        {
            System.Console.WriteLine("Invalid data id ");
            return;
        }

        if (string.IsNullOrWhiteSpace(newName) || newGrade < 0)
        {
            System.Console.WriteLine("Invalid new data student");
            return;
        }

        bool isFound = false;

        foreach (var e in _students)
        {
            if (e.Id == id)
            {
                isFound = true;
                e.Name = newName;
                e.Grade = newGrade;
                break;
            }
        }

        if (!isFound)
        {
            System.Console.WriteLine("The Student does not found ");
            return;
        }

        System.Console.WriteLine("The student is updated successfully");


    }
    public void Search(int id)
    {
        if (id <= 0)
        {
            Console.WriteLine("Invalid data ID");
            return;
        }

        if (_students.Count == 0)
        {
            Console.WriteLine("No student data");
            return;
        }

        for (var counter = 0; counter < _students.Count; counter++)
        {
            if (_students[counter].Id == id)
            {
                Console.WriteLine("Student Found!");
                Console.WriteLine($"Student ID: {_students[counter].Id}");
                Console.WriteLine($"Student Name: {_students[counter].Name}");
                Console.WriteLine($"Student Grade: {_students[counter].Grade}");
                return;
            }
        }

        Console.WriteLine("Student does not exist");
    }
}