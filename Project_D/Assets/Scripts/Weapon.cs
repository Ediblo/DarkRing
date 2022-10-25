using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collideble
{
    // Sat thuong
    public int damagePoint = 1;
    public float pushForce = 2.0f;
    
    // Nang cap vu khi
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;


    // Animation chem
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update(){
        base.Update();

        if(Input.GetKeyDown(KeyCode.Space)){
            if(Time.time - lastSwing > cooldown){
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D coll){
        if(coll.tag == "Fighter"){
            if(coll.name == "Player"){
                return;
            }

            
            Damage dmg = new Damage{
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing(){
        anim.SetTrigger("Swing");
        
    }
}
