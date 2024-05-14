using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrollingState : IGuardState
{
    // Player Object
    private GameObject player;
    private int i = 0;
    private int layerMask =~ 1 << 2;

    public void OnEnter(GuardStateController controller)
    {
        //Go to first waypoint
        controller.agent.destination = controller.Waypoints[i].position;
        player = GameObject.Find("Player");

        controller.m_animator.Play(controller.m_guardWalkHash);

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

        //Check to see if the Guard can see the player directly in front of them.
        RaycastHit _hit;
        Vector3 guardPosition_default = controller.agent.transform.position;
        Vector3 guardPostion_center = controller.agent.transform.position;
        guardPosition_default.y += 1;
        
        Debug.DrawRay(guardPosition_default, controller.agent.transform.forward * 30, Color.green);
        if (Physics.Raycast(guardPosition_default, controller.agent.transform.forward, out _hit, 300))
        {
            if (_hit.transform.CompareTag("Player"))
            {
                Debug.Log("Detected Player");
                controller.ChangeState(controller.chasingState);
            }
            
        }

        //If the player is within 5 metres of the player, check if the player is visible in any direction of the guard.
        if (Vector3.Distance(controller.agent.transform.position, player.transform.position) < 5.0f)
        {
            Vector3 direction_to_model = player.transform.position - controller.agent.transform.position;
            Debug.DrawRay(guardPostion_center, direction_to_model, Color.red);
            if (Physics.Raycast(guardPostion_center, direction_to_model, out _hit, 300))
            {

                if (_hit.transform.CompareTag("Player"))
                {
                    Debug.Log("Noticed Player");
                    controller.ChangeState(controller.chasingState);
                }

            }
        }



    }
}
