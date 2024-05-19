using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PausedScreenController : MonoBehaviour
{
    private VisualElement m_root;
    private Button m_mainMenuButton;
    private Button m_resumeButton;
    private Button m_exitButton;

    private UIController uiController;


    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;

        m_root = GetComponent<UIDocument>().rootVisualElement;

        uiController = GameObject.Find("UIController").GetComponent<UIController>();

        m_resumeButton = m_root.Q<Button>("ResumeButton");
        m_mainMenuButton = m_root.Q<Button>("MainMenuButton");
        m_exitButton = m_root.Q<Button>("ExitButton");

        m_resumeButton.clickable.clicked += OnResumeButtonClicked;
        m_mainMenuButton.clickable.clicked += OnMainMenuButtonClicked;
        m_exitButton.clickable.clicked += OnExitButtonClicked;
    }

    private void OnResumeButtonClicked()
    {
        Time.timeScale = 1;
        uiController.ActivatePlayerUI();
    }

    private void OnMainMenuButtonClicked()
    {
        Debug.Log("Load start Menu");
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
