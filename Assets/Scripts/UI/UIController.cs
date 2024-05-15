using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // This class controls all of the UI, the default state for the UI is the player UI,
    // when other UI screens are deactivated, they will default to the player UI.

    public GameObject UIPlayer;
    public GameObject UIGameOverScreen;
    public GameObject UIGameVictoryScreen;
    public GameObject UICrosshair;
    public GameObject UIPausedScreen;

    public void OnAwake()
    {
        UIPlayer.SetActive(true);
        UICrosshair.SetActive(true);
    }

    public void DeactivateAll()
    {
        UIGameOverScreen.SetActive(false);
        UIGameVictoryScreen.SetActive(false);

        UIPlayer.SetActive(false);
        UICrosshair.SetActive(false);
    }

    public void ActivePlayerUI()
    {
        //Deactivate all other UI
        UIGameOverScreen.SetActive(false);
        UIGameVictoryScreen.SetActive(false);
        UIPausedScreen.SetActive(false);

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        //Activate new UI
        UIPlayer.SetActive(true);
        UICrosshair.SetActive(true);
    }

    public void ActivateGameOverScreen()
    {
        //Deactivate all other UI
        UIPlayer.SetActive(false);
        UICrosshair.SetActive(false);
        UIGameVictoryScreen.SetActive(false);
        UIPausedScreen.SetActive(false);

        //Pause game and Lock Cursor
        Time.timeScale = 0;
        UnityEngine.Cursor.lockState = CursorLockMode.None;

        //Activate new UI
        UIGameOverScreen.SetActive(true);
    }

    public void ActivateGameVictoryScreen()
    {
        //Deactivate all other UI
        UIPlayer.SetActive(false);
        UICrosshair.SetActive(false);
        UIGameOverScreen.SetActive(false);
        UIPausedScreen.SetActive(false);

        //Pause game and Lock Cursor
        Time.timeScale = 0;
        UnityEngine.Cursor.lockState = CursorLockMode.None;

        //Activate new UI
        UIGameVictoryScreen.SetActive(true);
    }

    public void ActivatePausedScreen()
    {
        //Deactivate all other UI
        UIPlayer.SetActive(false);
        UICrosshair.SetActive(false);
        UIGameOverScreen.SetActive(false);
        UIGameVictoryScreen.SetActive(false);

        //Pause game and Lock Cursor
        Time.timeScale = 0;
        UnityEngine.Cursor.lockState = CursorLockMode.None;

        //Activate new UI
        UIPausedScreen.SetActive(true);
    }


}
