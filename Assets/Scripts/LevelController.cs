using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    float waitToLoad = 2f;
    bool levelFinishActive = false;


    public void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawn()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished == true)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        if (levelFinishActive == false)
        {
            winLabel.SetActive(true);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(waitToLoad);
            GetComponent<LevelLoader>().LoadNextScene();
        }
    }

    public void LevelTimerFinished()
    {
        Debug.Log("Told Spwaners to stop");
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }

    }

    public void HandleLoseCondition()
    {
        levelFinishActive = true;
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
}
