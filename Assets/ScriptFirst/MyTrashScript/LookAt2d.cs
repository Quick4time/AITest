using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt2d : MonoBehaviour {

    public GameObject target;
    [SerializeField]
    private float speedRotation = 0.5f;
    /*
    [SerializeField]
    private float maxSpeed;
    Vector3 linear;
    Vector3 velocity;
    [SerializeField]
    private float maxAccel;
    /*
    private void Start()
    {
        linear = Vector3.zero;
        velocity = Vector3.zero;
    }
    */
    private void Update()
    {
        /*
        linear = target.transform.position - transform.position;
        linear.Normalize();
        linear = linear * maxAccel;
        
        float AngleRad = Mathf.Atan2(target.transform.position.y - gameObject.transform.position.y, target.transform.position.x - gameObject.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        */

        Vector3 dir = target.transform.position - transform.position;
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(0,0, rot_z - 90);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, speedRotation * Time.deltaTime);
    }
    /*
    private void LateUpdate()
    {
        velocity += linear * Time.deltaTime;
        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity = velocity * maxSpeed;
        }
    }
    */

}
