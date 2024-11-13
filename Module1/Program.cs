using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Friend
{
    public int Index { get; set; }
    public int RequiredAuthority { get; set; }
    public int Influence { get; set; }
}

class Program
{
    // Method to read and parse input from a file
    public static (int, List<Friend>) ReadInput(string filePath)
    {
        var inputLines = File.ReadAllLines(filePath);
        var firstLine = inputLines[0].Split();
        int n = int.Parse(firstLine[0]);
        int authority = int.Parse(firstLine[1]);
        
        List<Friend> friends = new List<Friend>();

        for (int i = 1; i <= n; i++)
        {
            var line = inputLines[i].Split();
            int ai = int.Parse(line[0]);
            int bi = int.Parse(line[1]);
            friends.Add(new Friend { Index = i, RequiredAuthority = ai, Influence = bi });
        }

        return (authority, friends);
    }

    // Core logic for determining the friends that can be convinced
    public static (int, List<int>) ProcessFriends(List<Friend> friends, int initialAuthority)
    {
        // Sort friends by their required authority
        friends = friends.OrderBy(f => f.RequiredAuthority).ToList();

        List<int> convincedFriends = new List<int>();
        int authority = initialAuthority;

        foreach (var friend in friends)
        {
            if (authority >= friend.RequiredAuthority)
            {
                // Convince this friend
                convincedFriends.Add(friend.Index);
                // Increase or decrease authority by friend's influence
                authority += friend.Influence;
            }
        }

        return (convincedFriends.Count, convincedFriends);
    }

    // Method to write the output to a file
    public static void WriteOutput(string filePath, int count, List<int> convincedFriends)
    {
        using (var outputFile = new StreamWriter(filePath))
        {
            outputFile.WriteLine(count);
            outputFile.WriteLine(string.Join(" ", convincedFriends));
        }
    }

    // Main method - This would still handle file reading and writing
    public static void Main()
    {
        var (authority, friends) = ReadInput("D:\\CSD\\Module1\\Module1\\INPUT.txt");
        var (convincedCount, convincedFriends) = ProcessFriends(friends, authority);
        WriteOutput("D:\\CSD\\Module1\\Module1\\OUTPUT.txt", convincedCount, convincedFriends);
    }
}
