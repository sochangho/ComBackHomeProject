using UnityEngine;
using UnityEngine.UI;


public class Slot:MonoBehaviour
{
    
    private Items item = new Items();

    private int item_cnt = 0;

    private Text itemcntText;

    private Image slot_image;

    public void Awake()
    {

        itemcntText = GetComponentInChildren<Text>();
        slot_image = GetComponent<Image>();  

    }

   


    public void SlotSeting(Items additem)
    {

        item = additem;
        Debug.Log(item);
        slot_image.sprite = Resources.Load<Sprite>("Sprite/"+item.ItemType()) as Sprite;
        item_cnt++;
        itemcntText.text = item_cnt.ToString();

    } 
    

    public Items SlotGet()
    {

        return item;

    }

    public void SlotCnt()
    {

        item_cnt++;
        itemcntText.text = item_cnt.ToString();
    }

    public void Clickitem()
    {

        if (item != null)
        {

            var panel = FindObjectOfType<Inventory>().item_panel;
            panel.GetComponent<ItemPanel>().item = item;
            panel.GetComponent<ItemPanel>().panelitem_cnt = item_cnt;
            if (panel.activeSelf == false)
            {

                panel.SetActive(true);
                panel.GetComponent<ItemPanel>().PanelSet();

            }

        }

    }










}




