using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade2D : Flee2D {

    public float maxPrediction;
    private GameObject targetAux;
    private Agent2D targetAgent;

    public override void Awake()
    {
        base.Awake();
        targetAgent = target.GetComponent<Agent2D>();
        targetAux = target;
        target = new GameObject();
    }

    public override Steering2D GetSteering2D()
    {
        Vector2 direction = targetAux.transform.position - transform.position;
        float distance = direction.magnitude;
        float speed = agent2d.velocity.magnitude;
        float prediction;
        if (speed <= distance / maxPrediction)
        {
            prediction = maxPrediction;
        }
        else
        {
            prediction = distance / speed;
        }

        target.transform.position = targetAux.transform.position;
        target.transform.position += (Vector3)targetAgent.velocity * prediction;
        return base.GetSteering2D();
    }

    void OnDestroy()
    {
        Destroy(targetAux);
    }
}
