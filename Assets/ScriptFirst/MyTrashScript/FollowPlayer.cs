using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float speed = 2.0f;
    private float minDistance = 1.0f;
    private float range = 5;

    private void Update()
    {
        range = Vector2.Distance(transform.position, target.position);
        if (range > minDistance)
        {
            Debug.Log(range);
            Debug.DrawLine(transform.position, target.position);

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
