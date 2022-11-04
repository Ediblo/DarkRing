using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject QuitGame;

    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenYesNo(){
        QuitGame.SetActive(true);
        Time.timeScale = 1f;
    }

    public void CloseYesNo(){
        QuitGame.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit(){
        Application.Quit();
    }
}
