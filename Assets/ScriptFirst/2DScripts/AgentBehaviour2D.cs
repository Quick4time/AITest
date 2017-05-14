using System.Collections;
using UnityEngine;

public class AgentBehaviour2D : MonoBehaviour
{
    public GameObject target;
    protected Agent2D agent2d;

    public virtual void Awake()
    {
        agent2d = gameObject.GetComponent<Agent2D>();
    }
    public virtual void Update()
    {
        agent2d.SetSteering2D(GetSteering2D());
    }

    public virtual Steering2D GetSteering2D()
    {
        return new Steering2D();
    }
    public float MapToRange (float rotation)
    {
        rotation %= 360.0f;
        if (Mathf.Abs(rotation) > 180.0f)
        {
            // это как if, else если rotation < 0.0f, то выполняем первое после ? если нет то второе. 
            rotation = rotation < 0.0f ? rotation += 360.0f : rotation -= 360.0f; 
        }
        return rotation;
    }
    public Vector2 GetOriAsVec (float orientation)
    {
        Vector2 vector = Vector2.zero;
        vector.y = Mathf.Sin(orientation * Mathf.Rad2Deg) * 1.0f;
        vector.x = Mathf.Cos(orientation * Mathf.Rad2Deg) * 1.0f;
        return vector.normalized;
    }
}
