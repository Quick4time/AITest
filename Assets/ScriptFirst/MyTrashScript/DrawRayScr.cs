using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRayScr : MonoBehaviour {

    public GameObject targetAux;
    public Vector2 dir;
    public float duration;
    public LayerMask layers;



    private void OnDrawGizmos()
    {
        Color color = Color.cyan;
        Debug.DrawRay(transform.position, dir, color);
    }

    void Update ()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, duration, layers);

        if (hit.collider != null)
        {
            Debug.Log("Test ray");
        }
	}
}
