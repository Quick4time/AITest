using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave2D : AgentBehaviour2D {

    public float escapeRadius;
    public float dangerRadius;
    public float timeToTarget = 0.1f;

    public override Steering2D GetSteering2D()
    {
        // Первая половина функции GetSteering вычесляет расстояние.
        Steering2D steering2d = new Steering2D();
        Vector3 direction = transform.position - target.transform.position;
        float distance = direction.magnitude;
        if (distance > dangerRadius)
        {
            return steering2d;
        }
        float reduce; // снижать
        if (distance < escapeRadius)
        {
            reduce = 0.0f;
        }
        else
        {
            reduce = distance / dangerRadius * agent2d.maxSpeed;
        }
        float targetSpeed = agent2d.maxSpeed - reduce;

        // Вторая часть функции GetSteering, где устанавливаются управляющие значения, а скорость ограничивается максимальным значением.
        Vector3 desiredVelocity = direction; // desired(Желательная).
        desiredVelocity.Normalize();
        desiredVelocity *= targetSpeed;
        steering2d.linear = desiredVelocity - (Vector3)agent2d.velocity;
        steering2d.linear /= timeToTarget;
        if (steering2d.linear.magnitude > agent2d.maxAccel)
        {
            steering2d.linear.Normalize();
            steering2d.linear *= agent2d.maxAccel;
        }
        return steering2d;
    }
}
