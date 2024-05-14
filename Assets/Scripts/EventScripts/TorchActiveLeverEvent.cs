using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchActiveLeverEvent : MonoBehaviour
{
    public Lever torch;

    private void OnEnable()
    {
        torch = this.GetComponent<Lever>();
        Debug.Log(torch);
        WindowEvent.onWindowActivateLever += updateTorch;
    }

    private void updateTorch()
    {
        Debug.Log("UPDATE TORCH");
        //Allow the torch to be interactable 
        torch.b_isBlocked = false;
    }
}
