using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject DeleteSaveInfo;
    public GameObject QuitGame;

    public void PlayGame(){
        SceneManager.LoadScene("OpenWorld");
    }

    public void Exit(){
        Application.Quit();
    }

    public void DeleteAll(){
        PlayerPrefs.DeleteAll();
        
    }


   
}
