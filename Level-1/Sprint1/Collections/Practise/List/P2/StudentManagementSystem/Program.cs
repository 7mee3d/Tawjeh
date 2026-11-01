using Models;
using Services;
using Validations;
using Shared;


StudentService service = new();

while (true)
{

    Console.Clear();
    Console.WriteLine(
"================================\n" +
"       STUDENT MANAGEMENT\n" +
"================================\n" +
"1. Add Student\n" +
"2. Remove Student\n" +
"3. Search Student\n" +
"4. Update Student\n" +
"5. Display All Students\n" +
"6. Exit\n" +
"================================\n" +
"Choose an option: "
);
    byte choice = 0;
    while (!byte.TryParse(Console.ReadLine(), out choice))
        System.Console.WriteLine("Invalid data : ");

    switch ((StudentOperation.enStudentOperation)choice)
    {
        case StudentOperation.enStudentOperation._kADD_STUDENT:
            {
                System.Console.WriteLine("Enter the name : ");
                string name = Console.ReadLine()!;

                while (name.IsContainDigits())
                {
                    System.Console.WriteLine("Enter the name : ");
                    name = Console.ReadLine()!;
                }

                System.Console.WriteLine("Enter the grade : ");
                double grade = 0.0d;

                while (!double.TryParse(Console.ReadLine(), out grade))
                    System.Console.WriteLine("Invalid data , Enter the grade : ");

                service.Add(name, grade);
                break;
            }
        case StudentOperation.enStudentOperation._kREMOVE_STUDENT:
            {
                Console.Write("Enter Student ID: ");

                int id = 0;

                while (!int.TryParse(Console.ReadLine(), out id))
                    Console.Write("Invalid ID, try again: ");

                service.Remove(id);
                break;
            }
        case StudentOperation.enStudentOperation._kSEARCH:
            {
                Console.Write("Enter Student ID: ");

                int id = 0;

                while (!int.TryParse(Console.ReadLine(), out id))
                    Console.Write("Invalid ID, try again: ");

                service.Search(id);
                break;
            }
        case StudentOperation.enStudentOperation._kUPDATE_STUDENT :
            {
                Console.Write("Enter Student ID: ");

                int id = 0;

                while (!int.TryParse(Console.ReadLine(), out id))
                    Console.Write("Invalid ID, try again: ");

                Console.Write("Enter New Name: ");

                string newName = Console.ReadLine()!;

                while (newName.IsContainDigits())
                {
                    Console.Write("Invalid Name, enter again: ");
                    newName = Console.ReadLine()!;
                }

                Console.Write("Enter New Grade: ");

                double newGrade = 0;

                while (!double.TryParse(Console.ReadLine(), out newGrade))
                    Console.Write("Invalid Grade, try again: ");

                service.Update(id, newName, newGrade);
                break;
            }
        case StudentOperation.enStudentOperation._kDISPLAY:
            {
                service.Show();
                break;
            }
        case StudentOperation.enStudentOperation._kEXIT: 
            {
                Console.WriteLine("Thank you for using Student Management System!");
                return;
            }
    }

    System.Console.WriteLine("\nEnter any key");
    Console.ReadKey();

}