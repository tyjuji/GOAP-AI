using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GoalUI : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public Slider Priority;
    public TextMeshProUGUI Status;

    public void UpdateGoalInfo(string name, string status, float priority)
    {
        Name.text = name;
        Status.text = status;
        Priority.value = priority;
    }
}
