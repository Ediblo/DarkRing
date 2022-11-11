using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake(){
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory){
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems(){
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 100f;
        foreach(Item item in inventory.GetItemList()){
            RectTransform itemSlotReactTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotReactTransform.gameObject.SetActive(true);
            itemSlotReactTransform.anchoredPosition = new Vector2(x*itemSlotCellSize, y*itemSlotCellSize);

            Image image = itemSlotReactTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            x++;
            if(x > 4){
                x = 0;
                y++;
            }
        }
    }
}
