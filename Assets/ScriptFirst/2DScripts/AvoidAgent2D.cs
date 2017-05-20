using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidAgent2D : AgentBehaviour2D
{   // Создадим модель AvoidAgent2D с радиусом, определяющим область столкновения, и список агентов для уклонения.
    public float collisonRadius = 0.4f;
    GameObject[] targets;

    private void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Agent");
    }

    public override Steering2D GetSteering2D()
    {
        // Добавим переменные для вычесления расстояния и скорость агентов, находящихся поблизости.
        Steering2D steering2d = new Steering2D();
        float shortestTime = Mathf.Infinity;
        GameObject firstTarget = null;
        float firstMinSeparation = 0.0f;
        float firstDistance = 0.0f;
        Vector2 firstRelativePos = Vector2.zero;
        Vector2 firstRelativeVel = Vector2.zero;
        // Найдем юлижайшего агента, с которым может столкнуться текущий.
        foreach (GameObject t in targets)
        {
            Vector2 relativePos;
            Agent2D targetAgent = t.GetComponent<Agent2D>();
            relativePos = t.transform.position - transform.position;
            Vector2 relativeVel = targetAgent.velocity - agent2d.velocity;
            float relativeSpeed = relativeVel.magnitude;
            float timeToCollision = Vector2.Dot(relativePos, relativeVel);
            timeToCollision /= relativeSpeed * relativeSpeed * -1;
            float distance = relativePos.magnitude;
            float minSeparation = distance - relativeSpeed * timeToCollision;
            if (minSeparation > 2 * collisonRadius)
                continue;

            if (timeToCollision > 0.0f && timeToCollision < shortestTime)
            {
                shortestTime = timeToCollision;
                firstTarget = t;
                firstMinSeparation = minSeparation;
                firstRelativePos = relativePos;
                firstRelativeVel = relativeVel;
            }
        }
        // Если такой агент имеется пытаемся его обойти.
        if (firstTarget == null)
        {
            return steering2d;
        }   
        if (firstMinSeparation <= 0.0f || firstDistance < 2 * collisonRadius)
        {
            firstRelativePos = firstTarget.transform.position;
        }
        else
        {
            firstRelativePos += firstRelativeVel * shortestTime;
        }
        firstRelativePos.Normalize();
        steering2d.linear = -firstRelativePos * agent2d.maxAccel;
        return steering2d;
    }
}
