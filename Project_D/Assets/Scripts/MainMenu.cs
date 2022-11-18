using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject DeleteSave_UI;
    

    public void PlayGame(){
        SceneManager.LoadScene("OpenWorld");
    }

    public void Exit(){
        Application.Quit();
    }

    public void DeleteAll(){
      //  DeleteSave_UI.SetActive(true);
        PlayerPrefs.DeleteAll();
    }

    public void CloseDeletePanel(){
     //   DeleteSave_UI.SetActive(false);
    }


   
}
