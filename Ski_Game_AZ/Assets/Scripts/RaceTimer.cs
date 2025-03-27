using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    [SerializeField] private float penaltyTime = 1f;
    
    private bool timerRunning = false;
    private float raceTime = 0;

    private void Update()
    {
        if(timerRunning)
            raceTime += Time.deltaTime;
    }
    private void OnEnable()
    {
        GameEvents.raceStart += StartRace;
        GameEvents.raceEnd += FinishRace;
        GameEvents.racePenalty += Penalty;
    }

    private void OnDisable()
    {
        GameEvents.raceStart -= StartRace;
        GameEvents.raceEnd -= FinishRace;
        GameEvents.racePenalty -= Penalty;
    }

    private void Penalty()
    {
        raceTime += penaltyTime;
        Debug.Log("Penalty received");
    }

    private void StartRace()
    {
        timerRunning = true;
        Debug.Log("Race started");
    }

    private void FinishRace()
    {
        timerRunning = false;
        Debug.Log("Race finished");
        Debug.Log("Race time: " + raceTime);
    }
}
