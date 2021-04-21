
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Popup
{
    public delegate void InvetoryUpdate();

    public InvetoryUpdate invetoryUpdate; 


    //하위오브젝트 슬롯들
    public List<GameObject> slots;

    public GameObject item_panel;

 
 

    private void Start()
    {

        item_panel.SetActive(false);

        //invetoryUpdate = new InvetoryUpdate(SetItem);
        //invetoryUpdate += SetSprit;

        //invetoryUpdate();


        SetItem();
    }

    public void OnCloseButtonPress()
    {
        if(item_panel.activeSelf == true)
        {
            item_panel.SetActive(false);
        }
        FindObjectOfType<PlayerControl>().enabled = true;
        Close();
    }


    /// <summary>
    /// 인벤토리에 들어갈 아이템 개수를 초기화 시킵니다.
    /// </summary>
    public void SetItem()
    {


        var itemslot = ItemSystem.Instance.items;

        foreach (var item in itemslot)
        {
            item.itemInfoSet();
            Debug.Log(item.ItemType());
        }




        for (int i = 0; i < itemslot.Count; i++)
        {

            for (int j = 0; j < slots.Count; j++)
            {


                if (slots[j].GetComponent<Slot>().SlotGet() == null)
                {
                   
                    slots[j].GetComponent<Slot>().SlotSeting(itemslot[i]);
                    
                    break;
                }
                else
                {
                    if(slots[j].GetComponent<Slot>().SlotGet().ItemType() == itemslot[i].ItemType())
                    {
                        
                     slots[j].GetComponent<Slot>().SlotCnt();
                    
                     break;
                    }
                    
                }
            }
        }


    }




    //public void ClickBornfireCreate()
    //{
    //    ItemSystem.Instance.BonfireAdd();    
    //}


    //public void ClickTorchLightCreate()
    //{
    //    ItemSystem.Instance.TorchLightAdd();

    //}

    //public void ClickRaftCreate()
    //{
    //    var its = ItemSystem.Instance.items;

    //    foreach(var it in its)
    //    {
    //        if(it.GetComponent<Part>() != null && it.GetComponent<Part>().part_type == PartType.Raft)
    //        {
    //            ItemSystem.Instance.ItemInfoUI("이미 뗏목을 만들었습니다!!!", Color.yellow);
    //            return;

    //        }


    //    }



    //    ItemSystem.Instance.RaftAdd();
    //}

}
