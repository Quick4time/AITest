using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingLocation : MonoBehaviour
{ 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Agent"))
            return;
        Agent2D agent = other.GetComponent<Agent2D>();
        Jump jump = other.GetComponent<Jump>();

        if (agent == null || jump == null)
            return;
        
        jump.Isolate(false);
        jump.jumpPoint = null;
    }
}
