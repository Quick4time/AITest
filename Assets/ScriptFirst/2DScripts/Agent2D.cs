using System.Collections;
using UnityEngine;

public class Agent2D : MonoBehaviour
{
    public float maxSpeed;
    public float maxAccel;
    public float orientation;
    public float rotation;
    public float maxRotation;
    public float maxAngularAccel;
    public Vector2 velocity;
    protected Steering2D steering2d;

    private void Start()
    {
        velocity = Vector2.zero;
        steering2d = new Steering2D();
    }
    public void SetSteering2D(Steering2D steering2d)
    {
        this.steering2d = steering2d;
    }
    public virtual void Update()
    {
        Vector2 displacement = velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;
        if (orientation < 0.0f)
            orientation += 360.0f;
        else if (orientation > 360.0f)
            orientation -= 360.0f;
        transform.Translate(displacement, Space.World);
        transform.rotation = new Quaternion(); //Quaternion.Euler(0.0f, 0.0f, orientation);
        transform.Rotate(Vector3.forward, orientation);
    }
    public virtual void LateUpdate()
    {
        velocity += steering2d.linear * Time.deltaTime;
        rotation += steering2d.angular * Time.deltaTime;
        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity = velocity * maxSpeed;
        }
        if (rotation > maxRotation)
        {
            rotation = maxRotation;
        }
        if (steering2d.angular == 0.0f)
        {
            rotation = 0.0f;
        }
        if (steering2d.linear.sqrMagnitude == 0.0f)
        {
            velocity = Vector2.zero;
        }
        steering2d = new Steering2D();
    }
}
