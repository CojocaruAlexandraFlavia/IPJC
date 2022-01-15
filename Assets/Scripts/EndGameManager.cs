using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    private Board board;
    public GameObject endGamePanel;

    void Start()
    {
        board = FindObjectOfType<Board>();
    }

  
    public void OK()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        PlayerPrefs.SetInt("LastLevelIndex", currentSceneIndex + 1);
        PlayerPrefs.Save();    
    }

    public void EndGame()
    {
        endGamePanel.SetActive(true);

        FadePanelController fadePanelController = FindObjectOfType<FadePanelController>();
        fadePanelController.GameOver();
    }
}
