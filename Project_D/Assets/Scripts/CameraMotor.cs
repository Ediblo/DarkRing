using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lootAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void LateUpdate(){
        Vector3 delta = Vector3.zero;

        float deltaX = lootAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX){
            if(transform.position.x < lootAt.position.x){
                delta.x = deltaX - boundX;
            }
            else{
                delta.x = deltaX + boundX;
            }
        }

        float deltaY = lootAt.position.y - transform.position.y;
        if(deltaY > boundY || deltaY < -boundY){
            if(transform.position.y < lootAt.position.y){
                delta.y = deltaY - boundY;
            }
            else{
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
