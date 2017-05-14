using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align2D : AgentBehaviour2D
{
    // Базовая модель поведения Align являющуюся краеугольным камнем алгоритма поворота. 
    // Здесь используется тот же принцип, что и в модели поведения Arrive, но уже к вращению.
    public float targetRadius;
    public float slowRadius;
    public float timeToTarget = 0.1f;

    public override Steering2D GetSteering2D()
    {
        Steering2D steering2d = new Steering2D();
        float targetOrientation = target.GetComponent<Agent2D>().orientation;
        float rotation = targetOrientation - agent2d.orientation;
        rotation = MapToRange(rotation);
        float rotationSize = Mathf.Abs(rotation);
        if (rotationSize  < targetRadius)
        {
            return steering2d;
        }
        float targetRotation;
        rotationSize = rotationSize > slowRadius ? targetRotation = agent2d.maxRotation : targetRotation = agent2d.maxRotation * rotationSize / slowRadius;
        targetRotation *= rotation / rotationSize;
        steering2d.angular = targetRotation - agent2d.rotation;
        steering2d.angular /= timeToTarget;
        float angularAccel = Mathf.Abs(steering2d.angular);
        if (angularAccel > agent2d.maxAngularAccel)
        {
            steering2d.angular /= angularAccel;
            steering2d.angular *= agent2d.maxAngularAccel;
        }
        return steering2d;
    }
}
