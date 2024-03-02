using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedLever : Lever
{
    //Doors
    public int numDoorsControlled = 0;

    public List<Door> doorsControlled = new List<Door>();
    public List<DoorTypeIndicator> doorIndicators = new List<DoorTypeIndicator>();

    //Lever Indicators
    public LeverIndicatorScript LockedLeverController;
    private int LockedLeverControllerState;

    //Get the state of the Door from the 'Lockable Component' which requires 
    // a LockableControllerState

    override
    public void Interact()
    {
        LockedLeverControllerState = LockedLeverController.getState();
        Debug.Log(LockedLeverControllerState);

        for (int i = 0; i < numDoorsControlled; i++)
        {
            TryUnlock(i, LockedLeverControllerState);
        }
        ToggleLever();
    }

    public void TryUnlock(int doorNumber, int leverControllerState)
    {
        Debug.Log(doorIndicators[doorNumber].getState());
        Debug.Log(leverControllerState);
      
        if (doorIndicators[doorNumber].getState() == leverControllerState)
        {
            doorsControlled[doorNumber].Interact();
        }
    }

    public void ResetSystem()
    {
        //Reset Lever
        this.ResetLever();

        //Reset each door

    }
}
