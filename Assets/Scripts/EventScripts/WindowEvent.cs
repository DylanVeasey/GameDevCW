using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowEvent : Door
{

    public delegate void OnWindowEvent();
    public static OnWindowEvent onWindowEvent;

    override
    public void Interact()
    {
        if (!m_isOpen)
        {
            Debug.Log("WINDOW EVENT");
            onWindowEvent?.Invoke();
            //play particles, sounds, ects
        }
        else
        {
            //stop the particles, ect
        }

        ToggleDoor();

    }
}
