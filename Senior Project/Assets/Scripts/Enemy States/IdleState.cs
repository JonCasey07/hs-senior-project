using UnityEngine;

public class IdleState : State
{
    public bool canSeeThePlayer = false;
    public ChaseState chaseState;

    public override State RunCurrentState()
    {
        if(canSeeThePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }
}
