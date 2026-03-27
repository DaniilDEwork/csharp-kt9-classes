using System;
using System.Collections.Generic;

class Stack<T> where T : IComparable<T>
{
    private List<T> items = new List<T>();

    public void Push(T item)
    {
        items.Add(item);
    }

    public T Pop()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Стек пуст");

        T item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return item;
    }

    public T Max()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Стек пуст");

        T max = items[0];

        for (int i = 1; i < items.Count; i++)
        {
            if (items[i].CompareTo(max) > 0)
            {
                max = items[i];
            }
        }

        return max;
    }
}

class Pair<T, U>
    where T : class
    where U : class
{
    public T First { get; set; }
    public U Second { get; set; }

    public Pair(T first, U second)
    {
        First = first;
        Second = second;
    }

    public void Swap()
    {
        if (!(Second is T) || !(First is U))
            throw new InvalidOperationException("Нельзя поменять местами значения разных несовместимых типов");

        T temp = First;
        First = (T)(object)Second;
        Second = (U)(object)temp;
    }
}

class Calculator<T> where T : new()
{
    public static T Add(T x, T y)
    {
        return (T)((dynamic)x + (dynamic)y);
    }

    public static T Zero()
    {
        return new T();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Обобщенный класс Stack<T>");
        Stack<int> stack = new Stack<int>();
        stack.Push(5);
        stack.Push(12);
        stack.Push(8);

        Console.WriteLine("Максимальный элемент стека: " + stack.Max());
        Console.WriteLine("Удаленный элемент: " + stack.Pop());

        Console.WriteLine();
        Console.WriteLine("2. Обобщенный класс Pair<T, U>");

        Pair<string, string> pair = new Pair<string, string>("Первое", "Второе");
        Console.WriteLine("До Swap: " + pair.First + " | " + pair.Second);

        pair.Swap();
        Console.WriteLine("После Swap: " + pair.First + " | " + pair.Second);

        Console.WriteLine();
        Console.WriteLine("3. Обобщенный класс Calculator<T>");

        Console.WriteLine("Сумма int: " + Calculator<int>.Add(10, 20));
        Console.WriteLine("Zero для int: " + Calculator<int>.Zero());

        Console.WriteLine("Сумма double: " + Calculator<double>.Add(2.5, 3.5));
        Console.WriteLine("Zero для double: " + Calculator<double>.Zero());

        Console.ReadLine();
    }
}