using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Sprite dirtSprite;
    public Sprite grassSprite;
    public Sprite waterSprite;

    public List<Transform> Slot = new List<Transform>();
    public GameObject SlotItem;
    List<GameObject> items = new List<GameObject>();

   public void UpdateInventory(Inventory myInven)
    {
        foreach(var slotItems in items)
        {
            Destroy(slotItems);
        }
        items.Clear();

        int idx = 0;
        foreach(var item in myInven.items)
        {
            var go = Instantiate(SlotItem, Slot[idx].transform);
            go.transform.localPosition = Vector3.zero;
            SlotItemPrefab sItem = go.GetComponent<SlotItemPrefab>();
            items.Add(go);

            switch(item.Key)
            {
                case BlockType.Dirt:
                    sItem.ItemSetting(dirtSprite, "Dirt x" + item.Value);
                    break;
                case BlockType.Grass:
                    sItem.ItemSetting(grassSprite, "Grass x" + item.Value);
                    break;
                case BlockType.Water:
                    sItem.ItemSetting(waterSprite, "Water x" + item.Value);
                    break;
            }
            idx++;
        }
    }
}
