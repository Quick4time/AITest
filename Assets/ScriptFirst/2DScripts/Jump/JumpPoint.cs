using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint
{
    public Vector2 jumpLocation;
    public Vector2 landingLocation;
    public Vector2 deltaPosition; // Расстояние от точки прыжка до точки приземления.

    public JumpPoint () : this (Vector2.zero, Vector2.zero) { }

    public JumpPoint (Vector2 a, Vector2 b)
    {
        this.jumpLocation = a;
        this.landingLocation = b;
        this.deltaPosition = this.landingLocation - this.jumpLocation;
    }
}
