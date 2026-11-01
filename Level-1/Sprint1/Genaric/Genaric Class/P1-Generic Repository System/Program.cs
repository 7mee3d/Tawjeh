using Models;

public class Program
{

    private static void Main(string[] args)
    {
        var studentRepository = new GenericRepository<Student>();

        studentRepository.Add(new Student { Id = 1, Name = "Ahmad", Age = 22 });
        studentRepository.Add(new Student { Id = 2, Name = "Omar", Age = 21 });
        studentRepository.Add(new Student { Id = 3, Name = "Sara", Age = 23 });


        Console.WriteLine("Students:");
        foreach (var std in studentRepository.GetAll())
            Console.WriteLine($"{std.Id} | {std.Name} | {std.Age}");


        Console.WriteLine($"\nStudent 1 Exists: {studentRepository.Exists(1)}");
        Console.WriteLine($"Student 10 Exists: {studentRepository.Exists(10)}");

        var student = studentRepository.GetById(2);
        Console.WriteLine($"\nFound Student: {student?.Name ?? "Not Found"}");

        var updated = studentRepository.Update(2, new Student
        {
            Id = 2,
            Name = "Omar Updated",
            Age = 25
        });

        Console.WriteLine($"Update Result: {updated}");

        var deleted = studentRepository.Delete(3);
        Console.WriteLine($"Delete Result: {deleted}");

        Console.WriteLine("\nStudents After Update and Delete:");
        foreach (var item in studentRepository.GetAll())
            Console.WriteLine($"{item.Id} | {item.Name} | {item.Age}");

        Console.WriteLine("\nDuplicate ID Test:");
        try
        {
            studentRepository.Add(new Student { Id = 1, Name = "Duplicate", Age = 20 });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nUpdate Missing Student:");
        Console.WriteLine(studentRepository.Update(99, new Student
        {
            Id = 99,
            Name = "Missing",
            Age = 20
        }));

        Console.WriteLine("\nDelete Missing Student:");
        Console.WriteLine(studentRepository.Delete(99));

        Console.WriteLine("\nGet Missing Student:");
        Console.WriteLine(studentRepository.GetById(99)?.Name ?? "Not Found");

        Console.WriteLine($"\nStudents Count: {studentRepository.GetAll().Count()}");

    }

}