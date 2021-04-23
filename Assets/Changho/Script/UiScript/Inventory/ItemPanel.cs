using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemPanel : MonoBehaviour
{

    public Items item = null;

    public TextMeshProUGUI item_name;

    public TextMeshProUGUI item_subscript;

    public int panelitem_cnt;

    public GameObject usebutton_obj;

    public GridLayoutGroup layoutGroup;
  
    public void PanelSet()
    {
        item_name.text = item.GetItemName();
        item_subscript.text = item.GetItemsubscript();

    }


    public void UseClick()
    {

        if (item is Equipment)
        {
            var equ = (Equipment)item;
            FindObjectOfType<PlayerControl>().PlayerEqu(equ.equipment_type);
        }
        else
        {

            FindObjectOfType<ItemSlot>().itemslotAdd(item, panelitem_cnt);
        }
    }
    

    public void CencelClick()
    {
        gameObject.SetActive(false);
        FindObjectOfType<Inventory>().SlotClickOK();
    }





}
