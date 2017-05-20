using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceAndFollow2D : AgentBehaviour2D
{

    public override Steering2D GetSteering2D()
    {
        Steering2D steering2d = new Steering2D();
        steering2d.linear = target.transform.position - transform.position;
        steering2d.linear.Normalize();
        steering2d.linear = steering2d.linear * agent2d.maxAccel;
        Vector2 direction = transform.position - target.transform.position;
        if (direction.magnitude > 0.0)
        {
            float targetorientation = Mathf.Atan2(direction.y, direction.x);
            targetorientation *= Mathf.Rad2Deg;
            target.GetComponent<Agent2D>().orientation = targetorientation;
        }
        return steering2d;
    }
}
