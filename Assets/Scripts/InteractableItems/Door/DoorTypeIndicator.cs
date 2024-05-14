using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTypeIndicator : MonoBehaviour
{
    public int doorTypeIndicatorState;

    private GameObject Gem;

    private Material DoorIndicatorMaterialRed;
    private Material DoorIndicatorMaterialBlue;
    private Material DoorIndicatorMaterialGreen; 

    public void Start()
    {
        Gem = this.transform.GetChild(1).GetChild(0).gameObject;
        Debug.Log(Gem);
        switch (doorTypeIndicatorState) {
            case 1:
                //set material to Red
                DoorIndicatorMaterialRed = (Material)Resources.Load("Art/Materials/DoorIndicatorMaterialRed", typeof(Material));
                Gem.GetComponent<MeshRenderer>().material = DoorIndicatorMaterialRed;
                break;
            case 2:
                //set material to Green
                DoorIndicatorMaterialGreen = (Material)Resources.Load("Art/Materials/DoorIndicatorMaterialGreen", typeof(Material));
                Gem.GetComponent<MeshRenderer>().material = DoorIndicatorMaterialGreen;
                break;
            case 3:
                //set material to Blue
                DoorIndicatorMaterialBlue = (Material)Resources.Load("Art/Materials/DoorIndicatorMaterialBlue", typeof(Material));
                Gem.GetComponent<MeshRenderer>().material = DoorIndicatorMaterialBlue;
                break;
        }
    }

    public int getState() { 
        return doorTypeIndicatorState;
    }
}
