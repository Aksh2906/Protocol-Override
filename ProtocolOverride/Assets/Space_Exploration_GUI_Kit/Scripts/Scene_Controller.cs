using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SpaceGUI
{
    public class Scene_Controller : MonoBehaviour
{
    public LevelLoader levelLoader;

    void Awake()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    public void NextScene()
    {
        StartCoroutine(levelLoader.LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void PreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void exit_game()
    {
        Application.Quit();
    }
    public void startOver()
    {
        StartCoroutine(levelLoader.LoadNextLevel(0));
    }
}
}
