using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_Wall_Event : MonoBehaviour
{

    public Lever torch;
    //Change the material and remove the 'ember' 
    private GameObject Torch_Light;

    // Start is called before the first frame update
    private void OnEnable()
    {
        WindowEvent.onWindowEvent += updateTorch;
    }

    private void updateTorch()
    {
        //Update the Model of the torch
        Torch_Light = this.transform.GetChild(0).gameObject;
        Destroy(Torch_Light);

        //Allow the torch to be interactable 
        torch.b_canInteract = true;
    }


}
