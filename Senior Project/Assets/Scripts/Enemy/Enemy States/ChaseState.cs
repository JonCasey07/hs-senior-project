using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public bool isInAttackRange = false;
    public ActivateAttack activateAttack;

    public override State RunCurrentState()
    {
        if(isInAttackRange && activateAttack.isInRange)
        {
            return attackState;
        }
        else
        {
            return this;
        }
    }
}
