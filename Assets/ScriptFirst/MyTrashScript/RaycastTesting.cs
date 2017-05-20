using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTesting : MonoBehaviour {

    public float maxRayDistance = 25f;


	void FixedUpdate ()
    {
        // Это код для одиночного RayHit
        //Debug.DrawRay(transform.position, new Vector2(-transform.position.x * maxRayDistance, transform.position.y), Color.blue);
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), maxRayDistance); // TransfomDirection что юы лучь rotate with object
        Debug.DrawLine(transform.position, transform.position + transform.TransformDirection(Vector2.right) * maxRayDistance, Color.red); // TransfomDirection что юы лучь rotate with object
        if (hit)
        {
            Debug.Log("You hit a ray" + hit.rigidbody.gameObject.name);
            Debug.DrawLine(hit.point, hit.point + Vector2.up * 5);
            //Destroy(gameObject);
        }
        /*
        // Это код для Raycast[]
        RaycastHit2D[] hitts = Physics2D.RaycastAll(transform.position, Vector2.right, maxRayDistance);
        Debug.DrawLine(transform.position, transform.position + (Vector3)Vector2.right * maxRayDistance, Color.blue);

        foreach (RaycastHit2D hit in hitts)
        {
            Debug.Log("You hit: " + hit.rigidbody.gameObject.name);
            Debug.DrawLine(hit.point, hit.point + Vector2.up * 5.0f, Color.green); 
        }*/
	}
}
