using System.Collections;
using UnityEngine;

public class Constraint2D : MonoBehaviour
{
    public virtual bool WillViolate(Path2D path)// Нарушит
    {
        return true;
    }
    public virtual Goal2D Suggest (Path2D path) // Предлагать
    {
        return new Goal2D();
    }
}
