using UnityEngine;
using System.Collections;

public class Face : Align
{
    protected GameObject targetAux;

    public override void Awake()
    {
        base.Awake();
        targetAux = target;
        target = new GameObject();
        target.AddComponent<Agent>();
    }
    
    public override Steering GetSteering()
    {
        Vector3 direction = targetAux.transform.position - transform.position;
        if (direction.magnitude > 0.0f)
        {
            float targetOrientation = Mathf.Atan2(direction.x, direction.z);
            targetOrientation *= Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(targetOrientation, Vector3.forward); // Flip face.
            target.GetComponent<Agent>().orientation = targetOrientation;
        }
        return base.GetSteering();
    }
    
    void OnDestroy()
    {
        Destroy(target);
    }
}
/*
Vector2 dir = target.transform.poisition - transform.position;
float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

 Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
 diff.Normalize();
 
 float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
 transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

     Vector3 dir = targetAux.transform.position - transform.position;
        dir.y = 0;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(targetAux.transform.rotation, rot, speed * Time.deltaTime);
*/
