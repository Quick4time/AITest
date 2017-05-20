using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringPipeline2D : Wander2D // Конвейер-Управления.
{
    public int constraintSteps = 3;
    Targeter2D[] targeters;
    Decomposer2D[] decomposers;
    Constraint2D[] constraints;
    Acutator2D acutator;

    private void Start()
    {
        targeters = GetComponents<Targeter2D>();
        decomposers = GetComponents<Decomposer2D>();
        constraints = GetComponents<Constraint2D>();
        acutator = GetComponent<Acutator2D>();
    }

    public override Steering2D GetSteering2D()
    {
        Goal2D goal = new Goal2D();
        foreach (Targeter2D targeter in targeters)
        {
            goal.UpdateChannels(targeter.GetGoal());
        }
        foreach (Decomposer2D decomposer in decomposers)
        {
            goal = decomposer.Decompose(goal);
        }
        for (int i = 0; i < constraintSteps; i++)
        {
            Path2D path = acutator.GetPath(goal);
            foreach (Constraint2D constraint in constraints)
            {
                if (constraint.WillViolate(path))
                {
                    goal = constraint.Suggest(path);
                    break;
                }
                return acutator.GetOutPut(path, goal);
            }
        }
        return base.GetSteering2D();
    }
}
