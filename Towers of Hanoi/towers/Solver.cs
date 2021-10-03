using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using towers;

namespace towers
{
    public class Solver
    {
        public State Solve(State s)
        {
            //return SolveDepthFirst(s);
            return SolveBreadthFirst(s);
        }

        public State SolveDepthFirst(State s)
        {
            var stack = new Stack<State>();

            stack.Push(s);
            return SolveDepthFirst(stack);
        }

        public State SolveDepthFirst(Stack<State> stack)
        {
            while (stack.Count > 0)
            {
                var s = stack.Pop();

                // Console.WriteLine(s);

                if (IsGoal(s))
                {
                    return s;
                }

                var neighbours = GetNeighbours(s);

                foreach (var neighbour in neighbours)
                {
                    stack.Push(neighbour);
                }
            }

            return null;
        }



        public State SolveBreadthFirst(State s)
        {
            var q = new Queue<State>();
            q.Enqueue(s);
            return SolveBreadthFirst(q);

        }

        public State SolveBreadthFirst(Queue<State> q)
        {
            State s;


            while (q.TryDequeue(out s))
            {
                // Console.WriteLine(s);

                if (IsGoal(s))
                {
                    return s;
                }

                var neighbours = GetNeighbours(s);
                foreach (var neighbour in neighbours)
                {
                    q.Enqueue(neighbour);
                }
            }

            return null;
        }

        public static IEnumerable<State> GetNeighbours(State s)
        {

            // Console.WriteLine($"--  Get neighbours of {s}");


            // detect which disc is the top disc of each pin, if any
            var topDiscs = new int[3];

            for (int i = 0; i < 3; i++)
            {
                topDiscs[i] = s.DiscPositions.IndexWhere(x => x == i);
                // Console.WriteLine($" topdisc {i} is {topDiscs[i]}");
            }

            // if there is a topdisc of a Pin, it can move to any empty Pin or Pin that has a large topdisc
            for (int i = 0; i < 3; i++)
            {
                if (topDiscs[i] != -1)
                {
                    for (int j = 1; j < 3; j++)
                    {
                        int k = (i + j) % 3;

                        // Console.WriteLine($"i={i}, j={j}, k={k}");

                        if ((topDiscs[k] == -1) || (topDiscs[i] < topDiscs[k]))
                        {
                            var neighbour = new State(s);
                            neighbour.DiscPositions[topDiscs[i]] = k;
                             
                            if (!IsLoop(neighbour))
                            {
                                // Console.WriteLine($"--- {neighbour}");
                                yield return neighbour;
                            }
                        }
                    }
                }
            }
        }

        static public bool IsLoop(State s)
        {
            var p = s.previous;

            while (p != null)
            {
                if (s.Equals(p)) return true;
                p = p.previous;
            }
            return false;
        }

        static public bool IsGoal(State s)
        {
            return s.DiscPositions.Count(x => x == 2) == State.NrOfDiscs;
        }
    }
}