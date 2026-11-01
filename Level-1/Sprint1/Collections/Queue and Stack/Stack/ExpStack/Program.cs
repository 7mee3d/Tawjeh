

public class Program
{

    private static void Main(string[] args)
    {
        //Syntax Stack  (LIFO) -> (Last in First Out)
        // the stack stored the memory inside 4 size after the 4 -> new size is the 8 -> grather than 8 -> new size the 16 

        Stack<string> plates = new();


        // Methods 

        // 1- Push -> Push (T item)
        // plates.Push ("plate2");
        //plates.Push ("plate1");

        //In stack 
        //  [plate2]
        //  [plate1]


        plates.Push("plate1");
        plates.Push("plate2");



        Print(plates, "");

        System.Console.WriteLine("\n\n");

        // 2- Pop () -> remove the last item in the stack 

        var popItem = plates.Pop();

        Print(plates, "Pop");

        // 3- Peek -> show the last item in the stack 

        var peek = plates.Peek();
        System.Console.WriteLine("Stack items using peek method : ");
        System.Console.WriteLine($"[{peek}]");

        // 4- Try Pop -> remove last item safty 

        System.Console.WriteLine("\nStack after using try pop : ");

        if (plates.TryPop(out string result))
            System.Console.WriteLine($"[{result}]");
        else System.Console.WriteLine("\nStack empty");

        System.Console.WriteLine("\nStack after using try pop : ");

        if (plates.TryPop(out string result2))
            System.Console.WriteLine($"[{result2}]");
        else System.Console.WriteLine("\nStack empty");


        // 5- TryPeek -> show the last item safty 
        System.Console.WriteLine("\nStack after using try peek : ");
        if (plates.TryPeek(out string resultPeek))
            System.Console.WriteLine($"[{resultPeek}]");
        else System.Console.WriteLine("\nStack empty");

        // 6- Contain (T item )
        // Search the item in the stack O(N) 
        var itemToBeSearch = "plate1";
        System.Console.WriteLine("\nStack After using the Contains method : ");
        if (plates.Contains(itemToBeSearch))
            System.Console.WriteLine($"The {itemToBeSearch} is founded");
        else System.Console.WriteLine($"The {itemToBeSearch} not founded");


        //9- TrimEx 
        // the stack stored the memory inside 4 size after the 4 -> new size is the 8 -> grather than 8 -> new size the 16 
        // /TrimExcess decrese the size inside array in the stack [the stac ksize 16] but the stack inside the 8 item 
        //TrimExcess decrese the stack to 8 size 
        plates.TrimExcess();

        // 8- ToArray -> COnvert the stack to array - tip : 
        //In stack 
        //  [plate2]
        //  [plate1]
        //THe Array is : plate1 -> plate2 

        System.Console.WriteLine("The Stack after the convert to array : ");
        System.Console.WriteLine($"{plates.ToArray()[0]}"); //ex because the stack is empty 

      // 9- Count -> SHow the number in the stack 

      System.Console.WriteLine($"Count : {plates.Count}");
      

    }

    private static void Print(Stack<string> st, string op)
    {
        System.Console.WriteLine($"\n\nStack Items After {op}: \n");
        foreach (var item in st)
            System.Console.WriteLine($"[{item}]");

        System.Console.WriteLine("\n");
    }
}