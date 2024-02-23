using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedLever : Lever
{
    public LeverIndicatorScript LockedLeverController;
    private int LockedLeverControllerState;

    public LockableDoor[] LockedDoors;

    //Get the state of the Door from the 'Lockable Component' which requires 
    // a LockableControllerState

    override
    public void Interact()
    {
        LockedLeverControllerState = LockedLeverController.getState();
        Debug.Log(LockedLeverControllerState);
        foreach (LockableDoor LockedDoor in LockedDoors)
        {
            LockedDoor.TryUnlock(LockedLeverControllerState);
        }
        ToggleLever();
    }

    public void ResetSystem()
    {
        //Reset Lever
        this.ResetLever();

        //Reset each door
        foreach (LockableDoor LockedDoor in LockedDoors)
        {
            LockedDoor.ResetDoor();
        }

    }
}
