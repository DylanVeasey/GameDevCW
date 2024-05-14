using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAttackState : IGuardState
{
    // Player Object
    private GameObject player;
    private PlayerController playerController;
    private int i = 0;

    public bool isOnCooldown = false;

    public void OnEnter(GuardStateController controller)
    {
        //Stop Moving
        Debug.Log("ENTERED ATTACK STATE");
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    public void OnExit(GuardStateController controller)
    {
      //move back to chasing state
    }

    public void UpdateState(GuardStateController controller)
    {
        //Attack the Player Once then leave the state


        if (!isOnCooldown)
        {
            isOnCooldown = true;
            controller.startCoroutine();
        }
    }

    

}
