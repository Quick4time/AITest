using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decomposer2D : MonoBehaviour
{
    public virtual Goal2D Decompose(Goal2D goal)
    {
        return goal;
    }
}
