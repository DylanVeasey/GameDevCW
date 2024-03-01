using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    public Animator m_animator;

    private bool m_on = false;
    public Door[] doors;

    [field: SerializeField] public bool CanInteract { get; set; }
    [field: SerializeField] public bool IsBlocked { get; set; }

    // a event is a message sent by an object to signal the occurence of an action
    // a delegate is type that holds a reference to a method.

    // define an event that represents the moment a keypad is unlocked
    public delegate void UnlockHandler();

    // use delegate to define event
    // action verb in the past tense is common naming scheme
    public event UnlockHandler Unlocked;


    public void FailedInteract()
    {
        //RATTLE
    }

    
    virtual public void Interact()
    {
        foreach (Door door in doors)
        {
            door.Interact();
        }
        ToggleLever();
    }

    public void ToggleLever()
    {
        Debug.Log("Toggle Lever");
        if (!m_on)
        {
            m_animator.Play("On");
        }
        else m_animator.Play("Off");
        m_on = !m_on;

    }

    public void ResetLever()
    {
        if (m_on)
        {
            m_animator.Play("Off");
        }
        m_on = false;
    }
}
