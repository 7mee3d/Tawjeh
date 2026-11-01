public class Program
{
    public class Box<T>
    {
        public Box(T value)
        {
            this._Value = value;
        }

        private  T _Value ; 

        public T GetValue() => _Value;
        public T SetValue(T val) => _Value = val;
        public void Display() => System.Console.WriteLine($"Value = {_Value}");
    }

    private static void Main(string[] args)
    {
        var intBox = new Box<int>(100);

        Console.WriteLine(intBox.GetValue());

        intBox.SetValue(200);

        intBox.Display();

        System.Console.WriteLine("\n\n\n");

        var stringBox = new Box<string>("Hello Generics");
        Console.WriteLine(stringBox.GetValue());

        var doubleBox = new Box<double>(99.5);
        Console.WriteLine(doubleBox.GetValue());

    }

}