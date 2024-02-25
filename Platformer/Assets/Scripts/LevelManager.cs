using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void OpenLevel2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2");
        
    }
    public void OpenLevel3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level3");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }



}
