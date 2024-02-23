using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Convention to prepend interface names with "I"
public interface IInteractable
{
    bool CanInteract { get;  set; }
    bool IsBlocked { get;  set; }

    public void TryInteract()
    {
        Debug.Log("TRY INTERACT");
        if(CanInteract)
        {
            if (IsBlocked)
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