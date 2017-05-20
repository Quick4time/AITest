using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle2D : AgentBehaviour2D
{
    public override Steering2D GetSteering2D()
    {
        Steering2D steering2d = new Steering2D();
        return steering2d;
    }
}
