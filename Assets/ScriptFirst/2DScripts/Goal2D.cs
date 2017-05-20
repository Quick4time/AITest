using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal2D
{
    public bool isPosition;
    public bool isOrientation;
    public bool isVelocity;
    public bool isRotation;

    public float orientation;
    public float rotation;
    public Vector2 position;
    public Vector2 velocity;

    public Goal2D()
    {
        isPosition = false;
        isOrientation = false;
        isVelocity = false;
        isRotation = false;
        orientation = 0.0f;
        rotation = 0.0f;
        velocity = Vector2.zero;
        position = Vector2.zero;
    }

    public void UpdateChannels(Goal2D o)
    {
        if (o.isOrientation)
            orientation = o.orientation;
        if (o.isRotation)
            rotation = o.orientation;
        if (o.isPosition)
            position = o.position;
        if (o.isVelocity)
            velocity = o.velocity;
    }
}
