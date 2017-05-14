using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower2D : Seek2D
{
    public Path2D path;
    public float pathOffset = 0.0f;
    float currentParam;

    public override void Awake()
    {
        base.Awake();
        target = new GameObject();
        currentParam = 0.0f;
    }

    // Функция GetSteering использует абстракцию, созданную классом Path, для определения позиции цели и пременяет модель Seek.
    public override Steering2D GetSteering2D()
    {
        currentParam = path.GetParam(transform.position, currentParam);
        float targetParam = currentParam + pathOffset;
        target.transform.position = path.GetPosition(targetParam);
        return base.GetSteering2D();
        // TODO
        // Change the approach in order to solve
        //        Vector3 targetParam = currentParam + pathOffset;
        //        target.transform.position = path.GetPosition(currentParam);
    }
}
