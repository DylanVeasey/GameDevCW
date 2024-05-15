using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private UIController uiController;

    public void Start()
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController> ();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("A collider has entered the End Game trigger");
        StartCoroutine(endGame());
    }

    private IEnumerator endGame()
    {
        yield return new WaitForSeconds(1);
        uiController.ActivateGameVictoryScreen();
    }
}
