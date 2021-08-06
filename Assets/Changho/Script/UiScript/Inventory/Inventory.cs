﻿
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

    public ItemCreateInfo itemcreatepanel;

    public GameObject[] button_objs;



    private void OnEnable()
    {
        SoundPlay("Click");
    }

    private void Start()
    {

        item_panel.SetActive(false);
        PanelDestroy();
        PlayerStop();
        SetItem();

        SoundPlay("Open");
    }
    private void OnDestroy()
    {

        SoundPlay("Close");
        PlayerStart();


    }

    private void PlayerStop()
    {
        var player = FindObjectOfType<PlayerControl>();

        player.PlayerControlStop();
        player.Anim.WalkAnimation(false);
        player.Anim.RunAnimation(false);
    }

    private void PlayerStart()
    {

        FindObjectOfType<PlayerControl>().PlayerControlStart();

    }


    private void PanelDestroy()
    {

       if( FindObjectOfType<PanelActive>()!= null)
        {

            Destroy(FindObjectOfType<PanelActive>().gameObject);

        }


    }




    public void OnCloseButtonPress()
    {
       
        if(item_panel.activeSelf == true)
        {
            item_panel.SetActive(false);
        }
      
        SoundPlay("Click");
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

    public void InventoryUpdate()
    {
        foreach(var slot in slots)
        {

            if (slot.GetComponent<Slot>().SlotGet() != null)
            {
                slot.GetComponent<Slot>().SlotNullSet();
            }
        }

        SetItem();
    }


    public void OpenBoxButton()
    {
        SoundPlay("Click");
        ItemSystem.Instance.OpenBox();

        InventoryUpdate();

    }

    public void ClickBornfireCreate()
    {
        SoundPlay("Click");
        ItemSystem.Instance.BonfireAdd();
        InventoryUpdate();
    }


    public void ClickTorchLightCreate()
    {
        SoundPlay("Click");
        ItemSystem.Instance.TorchLightAdd();
        InventoryUpdate();

    }

    public void ClickRaftCreate()
    {

        SoundPlay("Click");
        ItemSystem.Instance.RaftAdd();
        InventoryUpdate();
    }


    public void SlotClickDefanse(string itemtype)
    {


        foreach(var slot in slots)
        {
           
            if(slot.GetComponent<Slot>().SlotGet().ItemType() != itemtype)
            {

                slot.GetComponent<Button>().interactable = false;

            }
        }
    }



    public void SlotClickOK()
    {

        foreach (var slot in slots)
        {

            if (!slot.GetComponent<Button>().interactable)
            {
                slot.GetComponent<Button>().interactable = true;

            }
        }



    }


    public void  TorchLightInfo()
    {
        if (itemcreatepanel.gameObject.activeSelf == false)
        {

            itemcreatepanel.gameObject.SetActive(true);
            itemcreatepanel.transform.position = button_objs[1].transform.position;
            itemcreatepanel.tmp.text = "\r\n" + " 천 : 1개" + "\r\n" + " 나뭇가지 : 1개" + "\r\n" + " 기름 : 1개";
        }
    }

    public void BonfireInfo()
    {

        if (itemcreatepanel.gameObject.activeSelf == false)
        {


            itemcreatepanel.gameObject.SetActive(true);
            itemcreatepanel.transform.position = button_objs[0].transform.position;
            itemcreatepanel.tmp.text = "\r\n" + " 나무 : 5개" + "\r\n" + "  부싯돌 : 1개";
        }
        
    }

    public void LaftInfor()
    {
        if (itemcreatepanel.gameObject.activeSelf == false)
        {

            itemcreatepanel.gameObject.SetActive(true);
            itemcreatepanel.transform.position = button_objs[2].transform.position;
            itemcreatepanel.tmp.text = "\r\n" + " 나무 : 3개"; ;
        }
    }

    public void PanelRemove()
    {
        itemcreatepanel.gameObject.SetActive(false);


    }

    public void SoundPlay(string name)
    {

        Sounds.Instance.SoundPlay(name);

    }

}
