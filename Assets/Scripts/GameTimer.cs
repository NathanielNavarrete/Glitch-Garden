﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime = 10;
    bool triggerLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggerLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            Debug.Log("Level Timer done");
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggerLevelFinished = true;
        }
    }
}
