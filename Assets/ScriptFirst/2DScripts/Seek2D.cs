using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek2D : AgentBehaviour2D {

    public override Steering2D GetSteering2D()
    {
        Steering2D steering2d = new Steering2D();
        steering2d.linear = target.transform.position - transform.position;
        steering2d.linear.Normalize();
        steering2d.linear = steering2d.linear * agent2d.maxAccel;
        return steering2d;
    }
}
