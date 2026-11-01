using System;
using System.Collections.Generic;

public class Program
{
    private static void Main(string[] args)
    {
        // Syntax Queue (FIFO) -> (First In First Out)
        // The queue uses a Circular Array under the hood. 
        // Starts with size 4 -> full? new size is 8 -> full? new size is 16

        Queue<string> line = new();

        // Methods 

        // 1- Enqueue -> Enqueue (T item) (Adds to the end/tail of the queue)
        // line.Enqueue ("customer1");
        // line.Enqueue ("customer2");

        // In Queue (FIFO)
        // [Head: customer1] -> [Tail: customer2]

        line.Enqueue("customer1");
        line.Enqueue("customer2");

        Print(line, "Enqueue");

        System.Console.WriteLine("\n\n");

        // 2- Dequeue () -> removes and returns the first item in the queue (from the Head)

        var dequeuedItem = line.Dequeue(); // Will remove customer1

        Print(line, "Dequeue");

        // 3- Peek -> show the first item in the queue without removing it (The Head)

        var peek = line.Peek();
        System.Console.WriteLine("Queue items using peek method : ");
        System.Console.WriteLine($"[{peek}]");

        // 4- TryDequeue -> remove first item safely 

        System.Console.WriteLine("\nQueue after using try dequeue : ");

        if (line.TryDequeue(out string result))
            System.Console.WriteLine($"[{result}]"); // Will remove customer2
        else System.Console.WriteLine("\nQueue empty");

        System.Console.WriteLine("\nQueue after using try dequeue : ");

        if (line.TryDequeue(out string result2))
            System.Console.WriteLine($"[{result2}]");
        else System.Console.WriteLine("\nQueue empty"); // Queue is empty now


        // 5- TryPeek -> show the first item safely 
        System.Console.WriteLine("\nQueue after using try peek : ");
        if (line.TryPeek(out string resultPeek))
            System.Console.WriteLine($"[{resultPeek}]");
        else System.Console.WriteLine("\nQueue empty");

        // 6- Contains (T item )
        // Search the item in the queue O(N) 
        var itemToBeSearch = "customer1";
        System.Console.WriteLine("\nQueue After using the Contains method : ");
        if (line.Contains(itemToBeSearch))
            System.Console.WriteLine($"The {itemToBeSearch} is founded");
        else System.Console.WriteLine($"The {itemToBeSearch} not founded"); // Not found because it's empty


        // 7- TrimExcess 
        // If the queue capacity is 16 but it only contains 8 items,
        // TrimExcess decreases the internal array size to exactly 8 to save memory.
        line.TrimExcess();

        // 8- ToArray -> Convert the queue to array - tip : 
        // In queue: [customer1 (Head)] -> [customer2 (Tail)]
        // The Array is : arr[0] = customer1 , arr[1] = customer2

        System.Console.WriteLine("\nThe Queue after the convert to array : ");
        // System.Console.WriteLine($"{line.ToArray()[0]}"); // Exception because the queue is empty now

        // 9- Count -> Show the number of items in the queue 

        System.Console.WriteLine($"Count : {line.Count}");
    }

    private static void Print(Queue<string> q, string op)
    {
        System.Console.WriteLine($"\n\nQueue Items After {op}: \n");
        // Iteration in Queue goes from the oldest item (Head) to the newest item (Tail)
        foreach (var item in q)
            System.Console.WriteLine($"[{item}]");

        System.Console.WriteLine("\n");
    }
}