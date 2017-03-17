using UnityEngine;
using System.Collections;
//Page 26 AI BOOK)
public class AgentBehaviour : MonoBehaviour {

    public GameObject target;
    protected Agent agent;
    public float maxSpeed;


    public virtual void Awake()
    {
        agent = gameObject.GetComponent<Agent>();
    }
    public float MapToRange(float rotation)
    {
        rotation %= 360.0f;
        if (Mathf.Abs(rotation) > 180.0f)
        {
            if (rotation < 0.0f)
                rotation += 360.0f;
            else
                rotation -= 360.0f;
        }
        return rotation;
    }
    public virtual void Update()
    {
        agent.SetSteering(GetSteering());
    }
    public virtual Steering GetSteering()
    {
        return new Steering();
    }

}
