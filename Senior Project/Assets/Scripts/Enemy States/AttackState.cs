using UnityEngine;

public class AttackState : State
{
    public ChaseState chaseState;
    public bool hasLeftAttackRange = false;
    public SwapChase swapChase;

    public override State RunCurrentState()
    {
        if (hasLeftAttackRange && !(swapChase.inRange))
        {
            return chaseState;
        }
        else
        {
            return this;
        }
        
    }
}
