public interface IGoal
{
    int CalculatePriority();
    bool CanRun();

    void OnTickGoal();
    void OnGoalActivated(Action_Base _linkedAction);
    void OnGoalDeactivated();
}
