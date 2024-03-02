using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverIndicatorScript : MonoBehaviour, IInteractable
{

    public Material[] Materials;
    public LockedLever lockedLever;

    [field: SerializeField] public bool b_canInteract { get; set; }
    [field: SerializeField] public bool b_isBlocked { get; set; }

    private int currentState = 0;

    public delegate void ResetHandler();

    public event ResetHandler Reset;

    public void FailedInteract()
    {
        //RATTLE
        Debug.Log("Failed Interact");
    }

    public void Interact()
    {
        //Update the current state of the indicator to the next state.
        currentState += 1;
        if (currentState >= Materials.Length) currentState = 0;

        this.GetComponent<MeshRenderer>().material = Materials[currentState];


        //TODO: Reset the lever and all of the doors.
        lockedLever.ResetSystem();
    }

    public int getState()
    {
        return currentState;
    }
}
