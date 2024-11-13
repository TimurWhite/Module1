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
    static void Main()
    {
        // Read input from INPUT.TXT file
        var inputLines = File.ReadAllLines("D:\\CSD\\Module1\\Module1\\INPUT.txt");
        var firstLine = inputLines[0].Split();
        int n = int.Parse(firstLine[0]);
        int authority = int.Parse(firstLine[1]);
        
        List<Friend> friends = new List<Friend>();

        // Parse each friend's required authority and influence
        for (int i = 1; i <= n; i++)
        {
            var line = inputLines[i].Split();
            int ai = int.Parse(line[0]);
            int bi = int.Parse(line[1]);
            friends.Add(new Friend { Index = i, RequiredAuthority = ai, Influence = bi });
        }

        // Sort friends by their required authority
        friends = friends.OrderBy(f => f.RequiredAuthority).ToList();

        List<int> convincedFriends = new List<int>();
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

        // Output results to OUTPUT.TXT file
        using (var outputFile = new StreamWriter("D:\\CSD\\Module1\\Module1\\OUTPUT.txt"))
        {
            outputFile.WriteLine(convincedFriends.Count);
            outputFile.WriteLine(string.Join(" ", convincedFriends));
        }
    }
}