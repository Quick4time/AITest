using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {
    public float maxSpeed;
    public float maxAccel;
    public float orientation; // check
    public float rotation;  // check
    public float maxRotation; // check
    public float maxAngularAccel;
    public Vector3 velocity;
    protected Steering steering;

    void Start()
    {
        velocity = Vector3.zero;
        steering = new Steering();
    }

    public void SetSteering (Steering steering)
    {
        this.steering = steering;
    }
    
    public virtual void Update()
    {
        Vector3 displacment = velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;
        if (orientation < 0.0f)
            orientation += 360.0f;
        else if (orientation > 360.0f)
            orientation -= 360.0f;
        transform.Translate(displacment, Space.World);
        transform.rotation = new Quaternion();
        transform.Rotate(Vector3.up, orientation);

    } 
    public virtual void LateUpdate()
    {
        velocity += steering.linear * Time.deltaTime;
        rotation += steering.angular * Time.deltaTime;
        if(velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity = velocity * maxSpeed;
        }
        if (rotation > maxRotation)
        {
            rotation = maxRotation;
        }
        if (steering.angular == 0.0f)
        {
            rotation = 0.0f;
        }
        if (steering.linear.sqrMagnitude == 0.0f)
        {
            velocity = Vector3.zero;
        }
        steering = new Steering();
    }
}
