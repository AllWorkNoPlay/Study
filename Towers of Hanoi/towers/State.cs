using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using towers;

namespace towers
{
    public class State
    {
        public static int NrOfDiscs = 3;

        public int[] DiscPositions;

        public State previous;
        public State()
        {
            DiscPositions = new int[NrOfDiscs];
        }

        public State(State s) //constructor creating a Clone
        {
            DiscPositions = new int[NrOfDiscs];
            Array.Copy(s.DiscPositions, DiscPositions, NrOfDiscs);
            previous = s;
        }

        public override int GetHashCode()
        {
            return int.Parse(String.Join("", DiscPositions));
        }

        public override bool Equals(object obj)
        {
            if (!(obj is State)) return false;

            var other = (State)obj;

            return DiscPositions.SequenceEqual(other.DiscPositions);

        }

        public override string ToString()
        {
            return $"¦ {HumanReadableDiscsOnPin(0)} ¦ {HumanReadableDiscsOnPin(1)} ¦ {HumanReadableDiscsOnPin(2)} ¦";
        }

        public string HumanReadableDiscsOnPin(int pin)
        {
            return String.Join(",", DiscPositions.IndexesWhere(x => x == pin).Reverse().Select(x => x + 1));
        }


        public string ToSolutionString()
        {
            var sb = new StringBuilder();
            var solution = new Stack<State>();
            var counter = 0;

            solution.Push(this);

            var p = previous;

            while (p != null)
            {
                counter++;
                solution.Push(p);
                p = p.previous;
            }

            sb.Append($"--- Solution in {counter} steps ---");
            foreach (var item in solution)
                sb.Append($"{item}\n");

            return sb.ToString();
        }
    }
}