using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardIdleState : IGuardState
{
    public void OnEnter(GuardStateController controller)
    {
        controller.m_animator.Play(controller.m_guardIdleHash);
    }

    public void OnExit(GuardStateController controller)
    {

    }

    public void UpdateState(GuardStateController controller) 
    {
        //When player enters the area, go to patrol state
        //Check is player has activated the trigger
        if (controller.entryTrigger.getIsTriggered())
        {
            controller.ChangeState(controller.patrollingState);
        }

    }

}
