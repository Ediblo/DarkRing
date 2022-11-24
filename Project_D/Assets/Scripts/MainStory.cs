using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    public string levelToLoad = "MainMenu";

    public void abc()
    {
        SceneManager.LoadScene(levelToLoad);    
    }
    

   
}
