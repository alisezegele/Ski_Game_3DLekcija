using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;

    private bool isGameStarted = false;

    private void Start()
    {
        Time.timeScale = 0f; // Pause the game
        mainMenuPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
        if (!isGameStarted && (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape)))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        isGameStarted = true;
        mainMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
