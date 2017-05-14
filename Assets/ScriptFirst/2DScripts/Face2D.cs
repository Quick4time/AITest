using System.Collections;
using UnityEngine;

public class Face2D : Align2D
{
    protected GameObject targetAux;  // protected - это когдгда можно получить досттуп из другого кода путем ClassA : ClassB{} в свою очередь private только this.gameobject.    

    public override void Awake()
    {
        base.Awake();
        targetAux = target;
        target = new GameObject();
        target.AddComponent<Agent2D>();
    }
    private void OnDestroy()
    {
        Destroy(target);
    }
    public override Steering2D GetSteering2D()
    {
        Vector2 direction = targetAux.transform.position - transform.position;
        if (direction.magnitude > 0.0f)
        {
            float targetOrientation = Mathf.Atan2(direction.y, direction.x);
            targetOrientation *= Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0.0f, 0.0f, agent2d.rotation - 90.0f);
            target.GetComponent<Agent2D>().orientation = targetOrientation; // добаляем к targetOrientation -90 - 45 и т.д что бы поменять вектор текущего обьекта Face2D.
        }
        return base.GetSteering2D();
    }
}
