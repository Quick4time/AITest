using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentPlayer2D : Agent2D {
    
	// Update is called once per frame
	public override void Update ()
    {
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        velocity *= maxSpeed;
        Vector3 translation = velocity * Time.deltaTime;
        transform.Translate(translation, Space.World);
        orientation = transform.rotation.eulerAngles.y;
    }
}
