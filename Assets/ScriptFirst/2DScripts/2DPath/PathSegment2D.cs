using System.Collections;
using UnityEngine;
// Определим пользовательский тип данных Pathsegment;

public class PathSegment2D
{
    public Vector2 a;
    public Vector2 b;
    
    public PathSegment2D() : this (Vector2.zero, Vector2.zero) { }
    
    public PathSegment2D (Vector2 a, Vector2 b)
    {
        this.a = a;
        this.b = b;
    }
}
