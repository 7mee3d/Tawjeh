

//Def List 

List<string> students = new();

// Add Students using add method O(1)

students.Add("Ahmed");
students.Add("Ali");
students.Add("Mohammed");
students.Add("Tariq");
students.Add("Waleed");

//Print students using foreach 

System.Console.WriteLine("\n\nStudents : ");
foreach(var e in students)
System.Console.WriteLine(e);

//Print total students using the count property 
System.Console.WriteLine($"\nTotal Students : {students.Count}");
