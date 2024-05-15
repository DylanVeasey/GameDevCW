using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOverScreenController : MonoBehaviour
{
    private VisualElement m_root;
    private Button m_mainMenuButton;
    private Button m_restartButton;
    private Button m_exitButton;


    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;

        m_root = GetComponent<UIDocument>().rootVisualElement;

        m_mainMenuButton = m_root.Q<Button>("MainMenuButton");
        m_restartButton = m_root.Q<Button>("RestartButton");
        m_exitButton = m_root.Q<Button>("ExitButton");

        Debug.Log(m_mainMenuButton);
        Debug.Log(m_restartButton);

        m_mainMenuButton.clickable.clicked += OnMainMenuButtonClicked;
        m_restartButton.clickable.clicked += OnRestartButtonClicked;
        m_exitButton.clickable.clicked += OnExitButtonClicked;
    }

    private void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("StartMenu");
    }

    private void OnRestartButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
