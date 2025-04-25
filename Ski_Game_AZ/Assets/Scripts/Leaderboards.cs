using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaderboards : MonoBehaviour
{
    [SerializeField] private List<float> bestTimes = new();

    public List<float> GetBestTimes()
    {
        return bestTimes;
    }
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        LoadTimes();
    }
    public void AddRaceTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();
        SaveTimes();
    }

    private void SaveTimes()
    {
        string levelKey = SceneManager.GetActiveScene().name;
        for (int i = 0; i < 5; i++)
        {
            if ( i<bestTimes.Count)
                PlayerPrefs.SetFloat(levelKey + " time" + i, bestTimes[i]);
        }
        PlayerPrefs.Save();
    }
    private void LoadTimes()
    {
        string levelKey = SceneManager.GetActiveScene().name;
        bestTimes = new List<float>();
        for (int i = 0; i < 5; i++)
        {
            bestTimes.Add(PlayerPrefs.GetFloat(levelKey + " time" + i, 99999));
        }
    }
}