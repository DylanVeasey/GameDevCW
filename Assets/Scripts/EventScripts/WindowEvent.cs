using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowEvent : Door
{

    private bool hasActivated = false;


    public delegate void OnWindowActivateLever();
    public static OnWindowActivateLever onWindowActivateLever;

    public delegate void OnWindowUnlightTorch();
    public static OnWindowUnlightTorch onWindowUnlightTorch;

    override
    public void Interact()
    {
        if (!hasActivated)
        {
            if (!b_isOpen)
            {
                Debug.Log("WINDOW EVENT");
                audioSource.Play();
                StartCoroutine(updateTorches());

                //play particles, sounds, ects
            }
            
        }
        if (b_isOpen)
        {
            audioSource.Stop();
        }
        ToggleDoor();

    }

    private IEnumerator updateTorches()
    {
        hasActivated = true;

        yield return new WaitForSeconds(1);
        

        onWindowActivateLever?.Invoke();
        onWindowUnlightTorch?.Invoke();

        yield return null;
    }
}
