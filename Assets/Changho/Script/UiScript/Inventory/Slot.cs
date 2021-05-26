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
            FindObjectOfType<Inventory>().SlotClickDefanse(item.ItemType());
            var panel = FindObjectOfType<Inventory>().item_panel;
            panel.GetComponent<ItemPanel>().item = item;
            panel.GetComponent<ItemPanel>().panelitem_cnt = item_cnt;
            if (panel.activeSelf == false)
            {

                panel.SetActive(true);
                panel.GetComponent<ItemPanel>().PanelSet();

            }



            if(item is Part)
            {

                if (panel.GetComponent<ItemPanel>().usebutton_obj.activeSelf)
                {
                    panel.GetComponent<ItemPanel>().usebutton_obj.SetActive(false);
                }

                panel.GetComponent<ItemPanel>().layoutGroup.padding.left = 75;
                panel.GetComponent<ItemPanel>().layoutGroup.padding.right = 0;
                panel.GetComponent<ItemPanel>().layoutGroup.padding.top = 5;
                panel.GetComponent<ItemPanel>().layoutGroup.padding.bottom = 0;
                panel.GetComponent<ItemPanel>().layoutGroup.spacing = new Vector2(25f, 0f);




            }
            else
            {
                if (!panel.GetComponent<ItemPanel>().usebutton_obj.activeSelf)
                {
                    panel.GetComponent<ItemPanel>().usebutton_obj.SetActive(true);
                }

                panel.GetComponent<ItemPanel>().layoutGroup.padding.left = 20;
                panel.GetComponent<ItemPanel>().layoutGroup.padding.right = 0;
                panel.GetComponent<ItemPanel>().layoutGroup.padding.top = 5;
                panel.GetComponent<ItemPanel>().layoutGroup.padding.bottom = 0;
                panel.GetComponent<ItemPanel>().layoutGroup.spacing = new Vector2(25f, 0f);




            }

        }





    }


    public void SlotNullSet()
    {

        item = null;
        item_cnt = 0;
        slot_image.sprite = Resources.Load<Sprite>("Sprite/Rectangle") as Sprite;
        itemcntText.text = "";
    }







}




