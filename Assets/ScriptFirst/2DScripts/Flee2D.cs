using System.Collections;
using UnityEngine;

public class Flee2D : AgentBehaviour2D
{
    public override Steering2D GetSteering2D()
    {
        Steering2D steering2d = new Steering2D();
        steering2d.linear = transform.position - target.transform.position;
        steering2d.linear.Normalize();
        steering2d.linear = steering2d.linear * agent2d.maxAccel;
        return steering2d;
    }
}
