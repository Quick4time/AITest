using System.Collections;
using UnityEngine;

public class Wander2D : Face2D
{
    public float offset; // смещение.
    public float radius; // радиус.
    public float rate;   // уровень отклонения.

    public override void Awake()
    {
        target = new GameObject();
        target.transform.position = transform.position;
        base.Awake();
    }
    public override Steering2D GetSteering2D()
    {
        Steering2D steering2d = new Steering2D();
        float wanderOrientation = Random.Range(-1.0f, 1.0f) * rate;
        float targetOrientation = wanderOrientation + agent2d.orientation;
        Vector2 orientationVec = GetOriAsVec(agent2d.orientation);
        Vector2 targetPosition = (offset * orientationVec) + (Vector2)transform.position;
        targetPosition = targetPosition + (GetOriAsVec(targetOrientation) * radius);
        targetAux.transform.position = targetPosition;
        steering2d = base.GetSteering2D();
        steering2d.linear = targetAux.transform.position - transform.position;
        steering2d.linear.Normalize();
        steering2d.linear *= agent2d.maxAccel;
        return steering2d;
        
    }
}
