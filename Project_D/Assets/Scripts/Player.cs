using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Mover
{
    private SpriteRenderer spriteRenderer;
    private bool isAlive = true;
 /*   private Inventory inventory;

    [SerializeField] private UI_Inventory uiInventory;

    private void Awake(){
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        ItemWorld.SpawnItemWorld(new Vector3(3,3), new Item {itemType = Item.ItemType.HealthPotion, amount = 1});
        ItemWorld.SpawnItemWorld(new Vector3(-3,3), new Item {itemType = Item.ItemType.ManaPotion, amount = 1});
    } */
    

    protected override void Start(){
        base.Start();
        spriteRenderer =  GetComponent<SpriteRenderer>();
    }

    protected override void ReceiveDamage(Damage dmg){
        if(!isAlive)
            return;

        base.ReceiveDamage(dmg);
        GameManager.instance.OnHitPointChange();
    }

    protected override void Death(){
        isAlive = false;
        GameManager.instance.deathMenuAnim.SetTrigger("Show");
    }

    private void FixedUpdate(){
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if(isAlive)
            UpdateMotor(new Vector3(x,y,0));
    }

    public void SwappSprite(int skinid){
        spriteRenderer.sprite = GameManager.instance.playerSprites[skinid];
    }

    public void OnLevelUp(){
        maxHitpoint++;
        hitpoint = maxHitpoint;
    }

    public void SetLevel(int level){
        for(int i = 0; i < level; i++)
            OnLevelUp();
    }
    
    public void Heal(int healingAmount){
        if(hitpoint == maxHitpoint)
            return;

        hitpoint += healingAmount;
        if(hitpoint > maxHitpoint)
            hitpoint = maxHitpoint;
        GameManager.instance.ShowText("+" + healingAmount.ToString() + " hp", 40, Color.green, transform.position, Vector3.up * 30, 1.0f);
        GameManager.instance.OnHitPointChange();
    }

    public void Respawn(){
        Heal(maxHitpoint);
        isAlive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
        
    }
}
