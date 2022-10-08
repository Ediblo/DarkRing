using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite empty_chest;
    public int goldAmount = 10;

    protected override void OnCollect(){
        
        if(!collected){

            collected = true;
            GetComponent<SpriteRenderer>().sprite = empty_chest;
            Debug.Log("Grant " + goldAmount + " gold!");
        }
    }
}
