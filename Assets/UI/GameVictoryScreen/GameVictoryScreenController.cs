using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private VisualElement m_root;

    private Button m_mainMenuButton;
    private Button m_exitButton;

    private UIController uiController;

    // Start is called before the first frame update
    void Start()
    {
        uiController = GameObject.Find("UIController").GetComponent<UIController>();

        m_root = GetComponent<UIDocument>().rootVisualElement;

        m_mainMenuButton = m_root.Q<Button>("MainMenuButton");
        m_exitButton = m_root.Q<Button>("ExitButton");

        m_mainMenuButton.clickable.clicked += OnMainMenuButtonClicked;
        m_exitButton.clickable.clicked += OnExitButtonClicked;
    }

    private void OnMainMenuButtonClicked()
    {
        uiController.DeactivateAll();
        SceneManager.LoadScene("StartMenu");
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
