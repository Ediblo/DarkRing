using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : Collideble
{
    public GameObject Congrat_UI;
    public static bool GameIsPause = false;

    public void Exit(){
        Application.Quit();
    }

    
    protected override void OnCollide(Collider2D coll){
        if(coll.name == "Player"){
            Congrat_UI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPause = true;
        }
    }

}
