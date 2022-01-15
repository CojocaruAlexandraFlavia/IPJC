using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        Time.timeScale = 1f;

        if(!PlayerPrefs.HasKey("LastLevelIndex"))
        {
            PlayerPrefs.SetInt("LastLevelIndex", 1);  
            PlayerPrefs.Save();
        }    
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevelIndex"));
    }

    public void QuitGame() {
        Application.Quit();
    }
}
