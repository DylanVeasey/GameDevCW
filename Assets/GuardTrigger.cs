using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardTrigger : MonoBehaviour
{

    private bool B_isTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("A collider has entered the Guard trigger");
        ToggleIsTriggered();
    }

    private void ToggleIsTriggered()
    {
        if (B_isTriggered)
        {
            B_isTriggered = false;
        }
        else
        {
            B_isTriggered = true;
        }
    }

    public bool getIsTriggered()
    {
        return B_isTriggered;
    }
}
