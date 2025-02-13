using System;
using System.Collections.Generic;

class MyHashMap
{
    private const int SIZE = 1000; // Fixed array size
    private LinkedList<KeyValuePair<int, int>>[] map;

    public MyHashMap()
    {
        map = new LinkedList<KeyValuePair<int, int>>[SIZE];
    }

    private int Hash(int key)
    {
        return key % SIZE;
    }

    public void Put(int key, int value)
    {
        int index = Hash(key);
        if (map[index] == null)
            map[index] = new LinkedList<KeyValuePair<int, int>>();

        foreach (var pair in map[index])
        {
            if (pair.Key == key)
            {
                map[index].Remove(pair);
                break;
            }
        }

        map[index].AddLast(new KeyValuePair<int, int>(key, value));
    }

    public int Get(int key)
    {
        int index = Hash(key);
        if (map[index] != null)
        {
            foreach (var pair in map[index])
            {
                if (pair.Key == key)
                    return pair.Value;
            }
        }
        return -1; // Key not found
    }

    public void Remove(int key)
    {
        int index = Hash(key);
        if (map[index] != null)
        {
            foreach (var pair in map[index])
            {
                if (pair.Key == key)
                {
                    map[index].Remove(pair);
                    break;
                }
            }
        }
    }

    public static void Main()
    {
        MyHashMap hashMap = new MyHashMap();
        hashMap.Put(1, 10);
        hashMap.Put(2, 20);
        Console.WriteLine(hashMap.Get(1)); 
        hashMap.Remove(1);
        Console.WriteLine(hashMap.Get(1)); 
    }
}
