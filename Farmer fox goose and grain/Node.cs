using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Node
{
    public char Farmer { get; set; }
    public char Fox { get; set; }
    public char Goose { get; set; }
    public char Grain { get; set; }
    public Node previous {get; set;}

    public override bool Equals (object? obj)
    {
        return (this.GetHashCode()==obj.GetHashCode());
    }

    public override int GetHashCode()
    {
        var str = $"{Farmer}{Fox}{Goose}{Grain}";
        str = str.Replace("L","0").Replace("R","1");
        return int.Parse(str);
    }

    public string ToSolutionString()
    {
        var sb = new StringBuilder();
        var solution = new Stack<Node>();
        var counter = 0;
        solution.Push(this);

        var p=previous;
        
        while(p!=null)
        {
            counter++;
            solution.Push(p);
            p=p.previous;
        }

        sb.AppendLine($"--- Solution in {counter} steps ---");

        foreach (var item in solution)
            sb.AppendLine($"{item.ToString()}");

        return sb.ToString();


    }

    public override string ToString()
    {
        return $"Farmer: {Farmer}, Fox: {Fox}, Goose: {Goose}, Grain: {Grain}";
    }

}