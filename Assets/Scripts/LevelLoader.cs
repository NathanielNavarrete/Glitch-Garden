using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0) {
            StartCoroutine(LoadStartScreen());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LoadStartScreen() {

        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void ResetNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Scene");
    }
}
