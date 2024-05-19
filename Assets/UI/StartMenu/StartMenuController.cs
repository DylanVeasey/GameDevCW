using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class StartMenuController : MonoBehaviour
{

    private VisualElement m_root;
    private Button m_startButton;
    private Button m_exitButton;

   

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;

        m_root = GetComponent<UIDocument>().rootVisualElement;

        m_startButton = m_root.Q<Button>("StartButton");
        m_exitButton = m_root.Q<Button>("ExitButton");

        


        m_startButton.clickable.clicked += OnStartButtonClicked;
    }

    private void OnStartButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }


}
