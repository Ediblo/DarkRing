using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // Text
    public Text levelText, hitpointText, goldText, upgradeCostText, xpText;

    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    // Chon nhan vat
    public void OnArrowClick(bool right){
        if(right){
            currentCharacterSelection++;

            if(currentCharacterSelection == GameManager.instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChanged();
        }
        else{
            currentCharacterSelection--;

            if(currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;

            OnSelectionChanged();

        }
    }

    private void OnSelectionChanged(){
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
        GameManager.instance.player.SwappSprite(currentCharacterSelection);
    }

    // Nang cap vu khi

    public void OnUpgradeClick(){
        if(GameManager.instance.TryUpgradeWeapon()){
            UpdateMenu();
        }
    }

    // Cap nhat thong tin nhan vat
    public void UpdateMenu(){

        //Thong tin vu khi
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        if(GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
            upgradeCostText.text = "MAX";
        else
            upgradeCostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();

        // Thong tin nhan vat
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        goldText.text = GameManager.instance.gold.ToString();
        levelText.text = GameManager.instance.GetCurrentLevel().ToString();

        // Thanh kinh nghiem
        int currLevel = GameManager.instance.GetCurrentLevel();
        if(currLevel == GameManager.instance.xpTable.Count){
            xpText.text = GameManager.instance.experience.ToString() + " total experience porints";
            xpBar.localScale = Vector3.one;
        }
        else{
            int prevLevelXp = GameManager.instance.GetXpToLevel(currLevel - 1);
            int currLevelXp = GameManager.instance.GetXpToLevel(currLevel);

            int diff = currLevelXp - prevLevelXp;
            int currXpIntoLevel = GameManager.instance.experience - prevLevelXp;

            float completionRatio = (float)currXpIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currXpIntoLevel.ToString() + " / " + diff;
        }
    }
}
