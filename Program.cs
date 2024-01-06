using System;
using System.Collections.Generic;

public class ChainingHashTable
{
    private readonly int size;
    private readonly List<int>[] items;

    public ChainingHashTable(int size)
    {
        this.size = size;
        items = new List<int>[size];
    }

    public void Add(int value)
    {
        int index = HashFunction(value);

        if (items[index] == null)
        {
            items[index] = new List<int>();
        }

        items[index].Add(value);
    }

    public bool Contains(int value)
    {
        int index = HashFunction(value);

        if (items[index] != null)
        {
            return items[index].Contains(value);
        }

        return false;
    }

    public void DisplayElementsBeforeHashing(int[] elements)
    {
        Console.WriteLine("Elementy przed haszowaniem:");
        foreach (var element in elements)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }

    public void DisplayElementsAfterHashing()
    {
        Console.WriteLine("\nElementy po haszowaniu:");
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Slot {i}: ");
            if (items[i] != null)
            {
                foreach (var item in items[i])
                {
                    Console.Write($"{item} ");
                }
            }
            Console.WriteLine();
        }
    }

    private int HashFunction(int value)
    {
        return Math.Abs(value % size);
    }
}

public class Program
{
    public static void Main()
    {
        int[] elements = { 1, 2, 3, 11 };

        // Tworzenie nowej tablicy haszującej z adresowaniem łańcuchowym
        ChainingHashTable hashTable = new ChainingHashTable(10);

        // Wyświetlanie elementów przed haszowaniem
        hashTable.DisplayElementsBeforeHashing(elements);

        // Dodawanie elementów do tablicy haszującej
        foreach (var element in elements)
        {
            hashTable.Add(element);
        }

        // Wyświetlanie elementów po haszowaniu
        hashTable.DisplayElementsAfterHashing();

        // Sprawdzanie obecności elementów
        Console.WriteLine("\nCzy 1 istnieje? " + hashTable.Contains(1));  // Zwraca true
        Console.WriteLine("Czy 4 istnieje? " + hashTable.Contains(4));  // Zwraca false
    }
}
