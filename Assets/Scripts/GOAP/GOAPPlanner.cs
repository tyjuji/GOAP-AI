using UnityEngine;

public class GOAPPlanner : MonoBehaviour
{
    Goal_Base[] Goals;
    Action_Base[] Actions;

    Goal_Base ActiveGoal;
    Action_Base ActiveAction;

    void Awake()
    {
        // Get all goals and actions on an object (the npc)
        Goals = GetComponents<Goal_Base>();
        Actions = GetComponents<Action_Base>();
    }

    void Update()
    {
        // Start with null
        Goal_Base bestGoal = null;
        Action_Base bestAction = null;

        // We want to find the highest priority.
        foreach (var goal in Goals)
        {
            // We need to tick the goal, before we can check it.
            goal.OnTickGoal();

            // We need to check if a goal can run and therefore is valid.
            if (!goal.CanRun())
            {
                continue;
            }

            // Is the current goal better or worse priority than the bestGoal?
            if (!(bestGoal == null || goal.CalculatePriority() > bestGoal.CalculatePriority()))
            {
                continue;
            }

            // Having found a goal, we now want to find the action with the lowest cost.
            Action_Base candidateAction = null;
            foreach (var action in Actions)
            {
                // Checking if our goal is part of the supportedgoals for the action
                if (!action.GetSupportedGoals().Contains(goal.GetType()))
                {
                    continue;
                }

                // Added CanRun to actions as well. Could be done with cost, but I think this is easier.
                if (!action.CanRun())
                {
                    continue;
                }

                // Is the action better or worse cost than the candidate?
                if (candidateAction == null || action.GetCost() < candidateAction.GetCost())
                {
                    candidateAction = action;
                }
            }

            // If we found an action above, we use it as the best action.
            if (candidateAction != null)
            {
                bestGoal = goal;
                bestAction = candidateAction;
            }
        }

        // If we don't have a goal active, we set the best one
        if (ActiveGoal == null)
        {
            ActiveGoal = bestGoal;
            ActiveAction = bestAction;

            if (ActiveGoal != null) 
            {
                ActiveGoal.OnGoalActivated(ActiveAction);
            }

            if (ActiveAction != null)
            {
                ActiveAction.OnActivated(ActiveGoal);
            }
                
        } // If the active goal doesn't change, we check the action.
        else if (ActiveGoal == bestGoal)
        {
            // If the active action isn't the best one, we change it.
            if (ActiveAction != bestAction)
            {
                ActiveAction.OnDeactivated();

                ActiveAction = bestAction;

                ActiveAction.OnActivated(ActiveGoal);
            }
        } // If we don't have a goal or it's not the best one, we change it.
        else if (ActiveGoal != bestGoal)
        {
            ActiveGoal.OnGoalDeactivated();
            ActiveAction.OnDeactivated();

            ActiveGoal = bestGoal;
            ActiveAction = bestAction;

            if (ActiveGoal != null)
            {
                ActiveGoal.OnGoalActivated(ActiveAction);
            }
                
            if (ActiveAction != null)
            {
                ActiveAction.OnActivated(ActiveGoal);
            }
                
        }

        // Finally we have an action active, so we run it.
        if (ActiveAction != null)
        {
            ActiveAction.OnTick();
        }
            
    }
}