using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrollingState : IGuardState
{
    private int i = 0;

    public void OnEnter(GuardStateController controller)
    {
        //Go to first waypoint
        controller.agent.destination = controller.Waypoints[i].position;
    }

    public void OnExit(GuardStateController controller)
    {
        controller.agent.destination = controller.agent.transform.position;
    }

    public void UpdateState(GuardStateController controller)
    {
        //Move Through Waypoints
        if (Vector3.Distance(controller.agent.transform.position, controller.Waypoints[i].position) < 1f)
        {
            if (i + 1 < controller.Waypoints.Length)
            {
                i++;
            }
            else
            {
                i = 0;
            }
            controller.agent.destination = controller.Waypoints[i].position;

        }

        //Check to see if the Guard can see the player
        RaycastHit _hit;
        Debug.DrawRay(controller.agent.transform.position, controller.agent.transform.forward * 10, Color.green);
        if (Physics.Raycast(controller.agent.transform.position, controller.agent.transform.forward, out _hit, 100))
        {
            if (_hit.transform.CompareTag("Player"))
            {
                Debug.Log("Detected Player");
                controller.ChangeState(controller.chasingState);
            }
            
        }


    }
}
