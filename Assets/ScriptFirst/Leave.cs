﻿using UnityEngine;
using System.Collections;
// Page 25 AI book
public class Leave : AgentBehaviour {

    public float escapeRadius;
    public float dangerRadius;
    public float timeToTarget = 0.5f;

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        Vector3 direction = transform.position - target.transform.position;
        float distance = direction.magnitude;
        if (distance > dangerRadius)
            return steering;
        float reduce;
        if (distance < escapeRadius)
            reduce = 0;
        else
            reduce = distance / dangerRadius * agent.maxSpeed;
        float targetSpeed = agent.maxSpeed - reduce;
        Vector3 desiredVelocity = direction;
        desiredVelocity.Normalize();
        desiredVelocity *= targetSpeed;
        steering.linear = desiredVelocity - agent.velocity;
        steering.linear /= timeToTarget;
        if (steering.linear.magnitude > agent.maxAccel)
        {
            steering.linear.Normalize();
            steering.linear *= agent.maxAccel;
        }
        return steering;
    }
}
