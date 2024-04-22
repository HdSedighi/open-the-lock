# Intuition
The problem can be solved using a breadth-first search (BFS) approach. The lock can be viewed as a graph where each state (a 4-digit code) is a node, and each move (turning one wheel one slot up or down) is an edge that connects two nodes. The goal is to find the shortest path from the initial state (0000) to the target state without passing through any deadend states.

# Approach
1. Start with the initial state 0000 and mark it as visited.
2. Use a queue to perform a BFS, starting with the initial state.
3. In each iteration, dequeue the current state and check if it matches the target state.
4. If it does, return the number of steps taken to reach the target state.
5. If it doesn't, generate the neighboring states by turning each wheel one slot up and down.
6. For each neighboring state, check if it is a deadend or has already been visited.
7. If the neighboring state is valid, enqueue it and mark it as visited.
8. Continue the process until the queue is empty, and return -1 if the target state cannot be reached.
# Complexity
- Time complexity:
The time complexity of the BFS approach is O(N×10^4), where N is the length of the target code (4 in this case), and each state has 10 possible neighbors (one for each digit from 0 to 9). The worst case is when all possible codes (10,000) need to be explored.
- Space complexity:
The space complexity is O(10^4) since we need to store the visited states to avoid revisiting them and maintain a queue for BFS traversal. This can be up to 10,000 different states (10 choices for each of the 4 wheels).
