using System;
using System.Collections.Generic;

public class LockSolver
{
    public int OpenLock(string[] deadends, string target)
    {
        // Convert deadends array to a HashSet for quick lookups
        HashSet<string> deadSet = new HashSet<string>(deadends);

        // If the initial state is in deadends or the target state is in deadends, return -1
        if (deadSet.Contains("0000") || deadSet.Contains(target))
        {
            return -1;
        }

        // Initialize the queue with the initial state '0000' and distance 0
        Queue<(string state, int steps)> queue = new Queue<(string state, int steps)>();
        queue.Enqueue(("0000", 0));

        // Visited states to prevent re-visiting and cycles
        HashSet<string> visited = new HashSet<string>();
        visited.Add("0000");

        // Directions for moving the wheels up and down
        int[] directions = { 1, -1 };

        // Perform BFS
        while (queue.Count > 0)
        {
            // Get the current state and number of steps
            var (current, steps) = queue.Dequeue();

            // Check if the current state matches the target
            if (current == target)
            {
                return steps;
            }

            // Explore the neighbors
            for (int i = 0; i < 4; i++)
            {
                foreach (int direction in directions)
                {
                    // Get the new state after turning the wheel
                    string neighbor = TurnWheel(current, i, direction);

                    // If the neighbor is not in the deadends and not visited
                    if (!deadSet.Contains(neighbor) && !visited.Contains(neighbor))
                    {
                        // Enqueue the neighbor with the steps increased by 1
                        queue.Enqueue((neighbor, steps + 1));
                        // Mark the neighbor as visited
                        visited.Add(neighbor);
                    }
                }
            }
        }

        // If no solution is found, return -1
        return -1;
    }

    // Helper function to turn the wheel
    private string TurnWheel(string state, int index, int direction)
    {
        // Convert the state string to a char array
        char[] charArray = state.ToCharArray();

        // Calculate the new wheel value
        int newValue = (charArray[index] - '0' + direction + 10) % 10;

        // Update the wheel value in the char array
        charArray[index] = (char)(newValue + '0');

        // Convert the char array back to a string and return
        return new string(charArray);
    }

    public static void Main(string[] args)
    {
        LockSolver solver = new LockSolver();
        string[] deadends = { "0201", "0101", "0102", "1212", "2002" };
        string target = "0202";
        int result = solver.OpenLock(deadends, target);
        Console.WriteLine("Minimum number of turns: " + result);
    }
}
