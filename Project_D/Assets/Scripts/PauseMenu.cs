using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject pauseMenuUI;

    public GameObject QuitGame;
    

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPause){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit(){
        Application.Quit();
    }

    public void OpenYesNo(){
        pauseMenuUI.SetActive(false);
        QuitGame.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseYesNo(){
        pauseMenuUI.SetActive(false);
        QuitGame.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart (){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMap1(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("OpenWorld");
    }

    public void LoadMap2(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map2");
    }
}
