using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Solver
{
    public static Node start = new Node{
        Farmer = 'L',
        Fox = 'L',
        Goose = 'L',
        Grain = 'L'
    };

    public static Node goal = new Node {
        Farmer = 'R',
        Fox = 'R',
        Goose = 'R',
        Grain = 'R'
    };

    public Node SolveDepthFirst(Node n)
    {
        var stack = new Stack<Node>();

        stack.Push(n);
        return SolveDepthFirst(stack);
    }

    public Node SolveDepthFirst(Stack<Node> stack)
    {
        while (stack.Count > 0)
        {
            var n = stack.Pop();

            // Console.WriteLine(n);

            if (IsGoal(n))
            {
                return n;
            }

            if (IsValid(n) && !IsLoop(n))
            {
                var neighbours = GetNeighbours(n);

                foreach (var neighbour in neighbours)
                {
                    stack.Push(neighbour);
                }
            }
        }

        return null;
    }



    public Node SolveBreadthFirst(Node n)
    {
        var q = new Queue<Node>();
        q.Enqueue(n);
        return SolveBreadthFirst(q);

    }

    public Node SolveBreadthFirst(Queue<Node> q)
    {
        Node n;


        while (q.TryDequeue(out n))
        {
            // Console.WriteLine(s);

            if (IsGoal(n))
            {
                return n;
            }

            if (IsValid(n) && !IsLoop(n))
            {
                var neighbours = GetNeighbours(n);
                foreach (var neighbour in neighbours)
                {
                    q.Enqueue(neighbour);
                }
            }
        }

        return null;
    }


    public IEnumerable<Node> GetNeighbours(Node n)
    {

        // Farmer can cross alone or with one of the things on the same river bank
        var bank = n.Farmer;

        // Farmer can cross alone
        yield return new Node{
            Farmer=Cross(n.Farmer),
            Fox=n.Fox,
            Goose=n.Goose,
            Grain=n.Grain,
            previous=n
        };

        // Farmer can cross with one thing from the same bank
        if(n.Fox == n.Farmer)
         yield return new Node{
            Farmer=Cross(n.Farmer),
            Fox=Cross(n.Fox),
            Goose=n.Goose,
            Grain=n.Grain,
            previous=n
        };

        if(n.Goose == n.Farmer)
         yield return new Node{
            Farmer=Cross(n.Farmer),
            Fox=n.Fox,
            Goose=Cross(n.Goose),
            Grain=n.Grain,
            previous=n
        };

        if(n.Grain == n.Farmer)
         yield return new Node{
            Farmer=Cross(n.Farmer),
            Fox=n.Fox,
            Goose=n.Goose,
            Grain=Cross(n.Grain),
            previous=n
        };

    }

    public char Cross(char c)
    {
        if (c=='L') return 'R';

        return 'L';
    }

    public bool IsValid(Node n)
    {
        // no Goose with Grain without Farmer on one bank
        if ((n.Goose==n.Grain) && (n.Goose!=n.Farmer)) return false;

        // no Fox with Goose without Farmer on one bank
        if ((n.Goose==n.Fox) && (n.Goose!=n.Farmer)) return false;

        return true;
    }

    public bool IsGoal(Node n)
    {
        return n.Equals(goal);
    }

    public bool IsLoop(Node n)
    {
        // Follow previous nodes and see if you fnd your equal
        var p = n.previous;

        while (p!=null)
        {
            if (n.Equals(p)) return true;
            p = p.previous;
        }

        return false;
    }
}