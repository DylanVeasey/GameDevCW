using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardChasingState : IGuardState
{

    private GameObject player;
    private Vector3 lastKnownPlayerPosition;

    public void OnEnter(GuardStateController controller)
    {
        //Set current position of player as last known player position
        lastKnownPlayerPosition = controller.player.transform.position;
        controller.agent.destination = lastKnownPlayerPosition;
        player = GameObject.Find("Player");

       
        controller.m_animatior.Play(controller.m_guardRunHash);

    }

    public void OnExit(GuardStateController controller)
    {

    }

    public void UpdateState(GuardStateController controller)
    {
        //Move to players last known position
        //Check if we have are close to the players last known position, if we are too close, and we have not updated, assume we have lost the player
        if (Vector3.Distance(controller.agent.transform.position, lastKnownPlayerPosition) < 1f)
        {
            controller.ChangeState(controller.patrollingState);
        }

        Vector3 guardPosition = controller.agent.transform.position;

        Vector3 direction_to_model = player.transform.position - controller.agent.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction_to_model);
        controller.agent.transform.rotation = rotation;

        //If can see player, update last known position
        RaycastHit _hit;
        Debug.DrawRay(guardPosition, controller.agent.transform.forward * 10, Color.green);
        if (Physics.Raycast(guardPosition, controller.agent.transform.forward, out _hit, 300))
        {
            Debug.Log(_hit.collider.gameObject.layer);
            if (_hit.transform.CompareTag("Player"))
            {
                Debug.Log("Still Chasing Player");
                lastKnownPlayerPosition = controller.player.transform.position;
                controller.agent.destination = lastKnownPlayerPosition;
            }
            else
            {
                controller.ChangeState(controller.patrollingState);
            }

        }

        // If the Guard is within 2 meters of the player, change to the attack state. 
        if (Vector3.Distance(controller.agent.transform.position, player.transform.position) < 2.5f)
        {
            controller.ChangeState(controller.attackState);
        }
    }
}
