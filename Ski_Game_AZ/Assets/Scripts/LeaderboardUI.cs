using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    [SerializeField] private Leaderboards leaderboards;
    [SerializeField] private GameObject leaderboardPanel;
    [SerializeField] private TextMeshProUGUI[] timeTexts;

    private void Start()
    {
        leaderboardPanel.SetActive(false);
    }

    public void ShowLeaderboard()
    {
        leaderboardPanel.SetActive(true);
        List<float> bestTimes = leaderboards.GetBestTimes();
        for (int i = 0; i < timeTexts.Length; i++)
        {
            if (i < bestTimes.Count && bestTimes[i] < 99999)
                timeTexts[i].text = $"{i + 1}. {bestTimes[i]:F2}s";
            else
                timeTexts[i].text = $"{i + 1}. ---";
        }
    }
}
