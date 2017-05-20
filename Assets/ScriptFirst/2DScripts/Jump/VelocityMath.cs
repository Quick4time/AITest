using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMath : AgentBehaviour2D
{
    public float timeToTarget = 0.1f;

    public override void Awake()
    {
        base.Awake();
    }

    public override Steering2D GetSteering2D()
    {
        Steering2D steering = new Steering2D();
        steering.linear = target.GetComponent<Agent2D>().velocity - agent2d.velocity;
        steering.linear /= timeToTarget;
        if (steering.linear.magnitude > agent2d.maxAccel)
        {
            steering.linear = steering.linear.normalized * agent2d.maxAccel;
        }     
        steering.angular = 0.0f;
        return steering;
    }
}
