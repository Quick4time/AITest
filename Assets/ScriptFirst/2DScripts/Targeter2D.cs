using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Класс определяющий модель поведения, ориентированную на конкретную цель.
public class Targeter2D : MonoBehaviour
{
    public virtual Goal2D GetGoal()
    {
        return new Goal2D();
    }
}
