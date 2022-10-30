using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collideble
{
    // Sat thuong
    public int[] damagePoint = {1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 31};
    public float[] pushForce = {2.0f, 2.3f, 2.6f, 2.9f, 3.2f, 3.5f, 3.8f, 4.1f, 4.4f, 4.7f, 5.0f, 6.0f};
    
    // Nang cap vu khi
    public int weaponLevel = 0;
    public SpriteRenderer spriteRenderer;


    // Animation chem
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
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
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel]
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    private void Swing(){
        anim.SetTrigger("Swing");
        
    }

    public void UpgradeWeapon(){
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }

    public void SetWeaponLevel(int level){
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
