using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardChasingState : IGuardState
{


    private Vector3 lastKnownPlayerPosition;

    public void OnEnter(GuardStateController controller)
    {
        //Set current position of player as last known player position
        lastKnownPlayerPosition = controller.player.transform.position;
        controller.agent.destination = lastKnownPlayerPosition;
    }

    public void OnExit(GuardStateController controller)
    {

    }

    public void UpdateState(GuardStateController controller)
    {
        //Move to players last known position
        if (Vector3.Distance(controller.agent.transform.position, lastKnownPlayerPosition) < 1f)
        {
            controller.ChangeState(controller.patrollingState);
        }

        //If can see player, update last known position
        RaycastHit _hit;
        Debug.DrawRay(controller.agent.transform.position, controller.agent.transform.forward * 10, Color.green);
        if (Physics.Raycast(controller.agent.transform.position, controller.agent.transform.forward, out _hit, 100))
        {
            if (_hit.transform.CompareTag("Player"))
            {
                Debug.Log("Still Chasing Player");
                lastKnownPlayerPosition = controller.player.transform.position;
                controller.agent.destination = lastKnownPlayerPosition;
            }

        }
    }
}
