using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMan : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject levels;

    public void LevelsOpen()
    {
        menu.SetActive(false);
        levels.SetActive(true);
    }

    public void BackToMenu()
    {
        levels.SetActive(false);
        menu.SetActive(true);
    }

    public void LevelGo1()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    public void LevelGo2()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1f;
    }

    public void LevelGo3()
    {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1f;
    }
}
