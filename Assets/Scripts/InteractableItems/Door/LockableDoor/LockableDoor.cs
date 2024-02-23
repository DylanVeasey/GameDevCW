using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockableDoor : Door
{
    public DoorTypeIndicator LockableController;
    private int LockableControllerState;


    public void TryUnlock(int compareState)
    {
        LockableControllerState = LockableController.getState();
        Debug.Log(LockableController);
        Debug.Log(compareState);
        if(LockableControllerState == compareState)
        {
            this.Interact();
        }
    }
}