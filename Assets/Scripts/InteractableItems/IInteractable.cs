using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Convention to prepend interface names with "I"
public interface IInteractable
{
    bool b_canInteract { get;  set; }
    bool b_isBlocked { get;  set; }

    public void TryInteract()
    {
        Debug.Log("TRY INTERACT");
        if(b_canInteract)
        {
            if (b_isBlocked)
            {
                Debug.Log("FAILED INTERACT");
                FailedInteract();
            }
            else
            {
                Debug.Log("INTERACT");
                Interact();
            }
        }
        
    }

    public void Interact();
    public void FailedInteract();
}