using UnityEngine;

public class AvoidWall2D : Seek2D
{
    public float avoidDistance;
    public float lookAhead;
    public LayerMask mask;


    public override void Awake()
    {
        base.Awake();
        target = new GameObject();
    }
    
    public override Steering2D GetSteering2D()
    {
        Steering2D steering = new Steering2D();
        Vector2 position = transform.position;
        Vector2 rayVector = agent2d.velocity.normalized * lookAhead;
        rayVector += position;
        Vector2 direction = rayVector - position;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, lookAhead, mask);
        Debug.DrawRay(position, direction * lookAhead,Color.blue);
        if (hit)
        {
            position = hit.point + hit.normal * avoidDistance;
            target.transform.position = position;
            steering = base.GetSteering2D();
        }
        return steering;
    }
   
}
