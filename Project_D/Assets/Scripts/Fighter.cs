using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fighter : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    protected float immnuneTime = 1.0f;
    protected float lastImmune;

    protected Vector3 pushDirection;

    protected virtual void ReceiveDamage(Damage dmg){
        if(Time.time - lastImmune > immnuneTime){
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            if(gameObject.name == "Player")
                GameManager.instance.ShowText(dmg.damageAmount.ToString(), 30, Color.white, transform.position, Vector3.zero, 0.5f);
            else
                GameManager.instance.ShowText(dmg.damageAmount.ToString(), 30, Color.red, transform.position, Vector3.zero, 0.5f);

            if(hitpoint <= 0){
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death(){

    }
}
