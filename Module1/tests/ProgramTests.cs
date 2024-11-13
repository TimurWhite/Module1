using System;
using System.Collections.Generic;
using Xunit;

public class ProgramTests
{
    [Fact]
    public void TestProcessFriends_SuccessfulConvincing()
    {
        // Arrange
        var inputLines = new string[]
        {
            "3 5",
            "3 2",
            "2 -1",
            "4 3"
        };
        var authority = 5;
        var friends = new List<Friend>
        {
            new Friend { Index = 1, RequiredAuthority = 3, Influence = 2 },
            new Friend { Index = 2, RequiredAuthority = 2, Influence = -1 },
            new Friend { Index = 3, RequiredAuthority = 4, Influence = 3 }
        };

        // Act
        var (convincedCount, convincedFriends) = Program.ProcessFriends(friends, authority);

        // Assert
        Assert.Equal(2, convincedCount); // Expected number of convinced friends
        Assert.Contains(1, convincedFriends); // Friend with index 1 should be convinced
        Assert.Contains(3, convincedFriends); // Friend with index 3 should be convinced
    }

    [Fact]
    public void TestProcessFriends_NotEnoughAuthority()
    {
        // Arrange
        var inputLines = new string[]
        {
            "3 3",
            "5 2",
            "4 -1",
            "6 3"
        };
        var authority = 3;
        var friends = new List<Friend>
        {
            new Friend { Index = 1, RequiredAuthority = 5, Influence = 2 },
            new Friend { Index = 2, RequiredAuthority = 4, Influence = -1 },
            new Friend { Index = 3, RequiredAuthority = 6, Influence = 3 }
        };

        // Act
        var (convincedCount, convincedFriends) = Program.ProcessFriends(friends, authority);

        // Assert
        Assert.Equal(0, convincedCount); // No friends should be convinced
    }

    [Fact]
    public void TestProcessFriends_AllFriendsConvinced()
    {
        // Arrange
        var inputLines = new string[]
        {
            "3 10",
            "5 2",
            "4 -1",
            "6 3"
        };
        var authority = 10;
        var friends = new List<Friend>
        {
            new Friend { Index = 1, RequiredAuthority = 5, Influence = 2 },
            new Friend { Index = 2, RequiredAuthority = 4, Influence = -1 },
            new Friend { Index = 3, RequiredAuthority = 6, Influence = 3 }
        };

        // Act
        var (convincedCount, convincedFriends) = Program.ProcessFriends(friends, authority);

        // Assert
        Assert.Equal(3, convincedCount); // All friends should be convinced
        Assert.Equal(new List<int> { 1, 2, 3 }, convincedFriends); // All friends with indices 1, 2, 3 should be convinced
    }
}
