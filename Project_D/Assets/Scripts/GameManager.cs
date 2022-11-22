using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    private void Awake() {
        if(GameManager.instance != null){
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(hud);
            Destroy(menu);
            Destroy(pausemenu);
            
            return;           
        }
        
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        
    }
        public List<Sprite> playerSprites;
        public List<Sprite> weaponSprites;
        public List<int> weaponPrices;
        public List<int> xpTable;

        public Player player;
        public Weapon weapon;
        
        public FloatingTextManager floatingTextManager;
        public RectTransform hitpointBar;
        public Animator deathMenuAnim;
        public GameObject hud;
        public GameObject menu;
        public GameObject pausemenu;

        public int gold;
        public int experience;

       
        

        public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration){
            floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
        }

        // Nang cap vu khi 
        public bool TryUpgradeWeapon(){
            // Kiem tra vu khi da max level
            if(weaponPrices.Count <= weapon.weaponLevel)
                return false;

            if(gold >= weaponPrices[weapon.weaponLevel]){
                gold -= weaponPrices[weapon.weaponLevel];
                weapon.UpgradeWeapon();
                return true;
            }

            return false;
        }

        public void OnHitPointChange(){
            float ratio = (float)player.hitpoint / (float)player.maxHitpoint;
            hitpointBar.localScale = new Vector3(1, ratio, 1);
        }

        // He thong kinh nghiem
        public int GetCurrentLevel(){
            int r = 0;
            int add = 0;

            while(experience >= add){
                add += xpTable[r];
                r++; 

                if(r == xpTable.Count) // Kiem tra max level
                    return r;
            }

            return r;
        }

        public int GetXpToLevel(int level){
            int r = 0;
            int xp = 0;

            while(r < level){
                xp += xpTable[r];
                r++;
            }

            return xp;
        }

        public void GrantXp(int xp){
            int currLevel = GetCurrentLevel();
            experience += xp;
            if(currLevel < GetCurrentLevel())
                OnLevelUp();
        }

        public void OnLevelUp(){
            player.OnLevelUp();
            OnHitPointChange();
        }

        // Load Scene
        public void OnSceneLoaded(Scene s, LoadSceneMode mode){
            player.transform.position = GameObject.Find("SpawnPoint").transform.position;
        }

        // Death menu and Respawn
        public void Respawn(){
            deathMenuAnim.SetTrigger("Hide");
            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            player.Respawn();
        }
            

        public void SaveState(){

            string s = " ";

            s += "0" + " | ";
            s += gold.ToString() + " | ";
            s += experience.ToString() + " | ";
            
            s += weapon.weaponLevel.ToString();
           
            PlayerPrefs.SetString("SaveState", s);
        }

        public void LoadState(Scene s, LoadSceneMode mode){

            SceneManager.sceneLoaded -= LoadState;

            if(!PlayerPrefs.HasKey("SaveState"))
                return;

            string[] data = PlayerPrefs.GetString("SaveState").Split('|');

            gold = int.Parse(data[1]);
            experience = int.Parse(data[2]);
            if(GetCurrentLevel() != 1)
                player.SetLevel(GetCurrentLevel());
            weapon.SetWeaponLevel(int.Parse(data[3]));
            
            
            
            
        }
    
}
