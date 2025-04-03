using System;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        foreach (char letter in letters)
        {
            if (!word.Contains(letter))
            {
                PermutationsChoose(results, letters, size, word + letter);
            }
        }
    }

    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s == 0) return 1;
        if (s < 0) return 0;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;

        return ways;
    }

    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern.Substring(0, index) + '0' + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + '1' + pattern.Substring(index + 1), results);
    }

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        if (!maze.IsValidMove(currPath, x, y))
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(string.Join("->", currPath.Select(p => $"({p.Item1},{p.Item2})")));
            return;
        }

        SolveMaze(results, maze, x + 1, y, new List<ValueTuple<int, int>>(currPath));
        SolveMaze(results, maze, x, y + 1, new List<ValueTuple<int, int>>(currPath));
        SolveMaze(results, maze, x - 1, y, new List<ValueTuple<int, int>>(currPath));
        SolveMaze(results, maze, x, y - 1, new List<ValueTuple<int, int>>(currPath));
    }
}
