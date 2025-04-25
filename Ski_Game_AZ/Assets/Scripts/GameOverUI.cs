using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Image overlay;
    [SerializeField] private int nextLevelIndex = 1;
    [SerializeField] private LeaderboardUI leaderboardUI;
    private void Start()
    {
        overlay.CrossFadeAlpha(0,1f,true);
        gameOverUI.SetActive(false);
    }
    private void OnEnable()
    {
        GameEvents.raceEnd += EnableGameOverUI;
        GameEvents.Quit += Quit;
    }
    private void OnDisable()
    {
        GameEvents.raceEnd -= EnableGameOverUI;
        GameEvents.Quit -= Quit;
    }
    private void EnableGameOverUI()
    {
        gameOverUI.SetActive(true);
        leaderboardUI.ShowLeaderboard();
    }
    public void RestartLevel()
    {
        StartCoroutine(RestartCoroutine()); 
    }

    public void GameQuit()
    {
        GameEvents.CallGameQuit();
    }

    private IEnumerator RestartCoroutine()
    {
        overlay.CrossFadeAlpha(1,1,true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex);
    }
    private void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }
    private IEnumerator QuitCoroutine()
    {
        overlay.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1);
        Application.Quit();
    }

    public void GoToNextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }
    private IEnumerator NextLevelCoroutine()
    {
        overlay.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevelIndex);
    }
}

