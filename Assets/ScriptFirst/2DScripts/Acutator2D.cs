using System.Collections;
using UnityEngine;

public class Acutator2D : MonoBehaviour
{
    public virtual Path2D GetPath(Goal2D goal)
    {
        return new Path2D();
    }
    public virtual Steering2D GetOutPut(Path2D path, Goal2D goal)
    {
        return new Steering2D();
    }
}
