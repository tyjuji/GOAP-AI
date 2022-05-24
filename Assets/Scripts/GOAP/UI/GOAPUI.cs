using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAPUI : MonoBehaviour
{
    [SerializeField] GameObject GoalPrefab;
    [SerializeField] RectTransform GoalRoot;

    Dictionary<MonoBehaviour, GoalUI> DisplayedGoals = new Dictionary<MonoBehaviour, GoalUI>();

    public void UpdateGoal(MonoBehaviour goal, string name, string status, float priority)
    {
        // Add goal to dictionary, if not already in
        if (!DisplayedGoals.ContainsKey(goal))
        {
            DisplayedGoals[goal] = Instantiate(GoalPrefab, Vector3.zero, Quaternion.identity, GoalRoot).GetComponent<GoalUI>();
        }
            
        // Update the goal as it gets calculated.
        DisplayedGoals[goal].UpdateGoalInfo(name, status, priority);
    }
}
