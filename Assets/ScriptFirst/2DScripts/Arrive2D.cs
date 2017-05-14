using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive2D : AgentBehaviour2D {


    public float targetRadius;
    public float slowRadius;
    public float timeToTarget = 0.1f;

    public override Steering2D GetSteering2D()
    {
        // Первая половина функции GetSteering вычесляет скорость в зависимости от расстояния до цели и радиуса замедления.
        Steering2D steering2d = new Steering2D();
        Vector2 direction = target.transform.position - transform.position;
        float distance = direction.magnitude;
        float targetSpeed;
        if (distance < targetRadius)
        {
            return steering2d;
        }
        if (distance > slowRadius)
        {
            targetSpeed = agent2d.maxSpeed;
        }
        else
        {
            targetSpeed = agent2d.maxSpeed * distance / slowRadius;
        }
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
