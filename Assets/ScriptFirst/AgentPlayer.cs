using UnityEngine;
using System.Collections;

public class AgentPlayer : Agent {

    public override void Update()
    {
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        velocity *= maxSpeed;
        Vector3 translation = velocity * Time.deltaTime;
        transform.Translate(translation, Space.World);
    }

}
