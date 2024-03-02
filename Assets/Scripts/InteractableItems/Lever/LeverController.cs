using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour, IInteractable
{
    public Animator m_animator;

    public LeverIndicatorScript leverIndicator;

    private bool m_on = false;

    private int currentLeverIndicator;

    [field: SerializeField] public bool b_canInteract { get; set; }
    [field: SerializeField] public bool b_isBlocked { get; set; }


    // a event is a message sent by an object to signal the occurence of an action
    // a delegate is type that holds a reference to a method.

    // define an event that represents the moment a keypad is unlocked
    public delegate void UnlockHandler();

    // use delegate to define event
    // action verb in the past tense is common naming scheme
    public event UnlockHandler Unlocked;

    // Update is called once per frame
    private void Update()
    {
    
        //if (Input.GetKeyDown("space"))
        //    Interact();
    }

    private void OnEnable()
    {
        leverIndicator.Reset += ResetLever;
    }

    public void FailedInteract()
    {
        //RATTLE
    }

    public void Interact()
    {
        ToggleLever();
    }

    public void ToggleLever()
    {
        currentLeverIndicator = leverIndicator.getState();
        if (!m_on)
        {
            m_animator.Play("LeverAnimationOn");
        }
        else m_animator.Play("LeverAnimationOff");
        m_on = !m_on;

        Unlocked?.Invoke();
    }

    public void ResetLever()
    {
        if (m_on)
        {
            m_animator.Play("LeverAnimationOff");
        }
        m_on = false;
    }

    public int getCurrentLeverIndicator()
    {
        return currentLeverIndicator;
    }
}