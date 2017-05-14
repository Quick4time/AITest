using UnityEngine;
using System.Collections;

public class PathFollower : Seek {

    public Path path;
    public float pathOffset = 0.0f;
    float currentParam;

    public override void Awake()
    {
        base.Awake();
        target = new GameObject();
        currentParam = 0.0f;
    }
    // Функция GetSteering использует абстракцию, созданную классом Path, для определения позиции цели и пременяет модель Seek.
    public override Steering GetSteering()
    {
        currentParam = path.GetParam(transform.position, currentParam);
        float targetParam = currentParam + pathOffset;
        target.transform.position = path.GetPosition(targetParam);
        return base.GetSteering();
        // TODO
        // Change the approach in order to solve
        //        Vector3 targetParam = currentParam + pathOffset;
        //        target.transform.position = path.GetPosition(currentParam);
    }
}
