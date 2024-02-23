using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTypeIndicator : MonoBehaviour
{
    public int doorTypeIndicator;

    public GameObject Object;

    public int getState() { 
        return doorTypeIndicator;
    }
}
