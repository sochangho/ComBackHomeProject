
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Inventory : Popup
{
    public delegate void InvetoryUpdate();

    public InvetoryUpdate invetoryUpdate; 


    //하위오브젝트 슬롯들
    public List<GameObject> slots;

    public List<Button> buts;

    public GameObject item_panel;

    public ItemCreateInfo itemcreatepanel;

    public GameObject[] button_objs;

    public GameObject content;

    public GameObject slot;

    public RuntimeAnimatorController animatorController;

    private void OnEnable()
    {
        SoundPlay("Click");
        PlayerStop();
    }

    private void Start()
    {

        item_panel.SetActive(false);
        PanelDestroy();
        StartCoroutine(SlotSettingDelay(SetItem()));  
        SoundPlay("Open");
    }
    private void OnDisable()
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
    public Dictionary<string, SettingItem> SetItem()
    {


        var itemslot = ItemManager.Instance.itemList;




        foreach (var item in itemslot)
        { 
           
            item.itemInfoSet();
          
        }


        var itemsDic = new Dictionary<string, SettingItem>();

        foreach (var item in itemslot)
        {
            if (itemsDic.ContainsKey(item.ItemType()))
            {
                itemsDic[item.ItemType()].itemCnt++;

            }
            else
            {
                itemsDic.Add(item.ItemType(), new SettingItem());
                itemsDic[item.ItemType()].item = item;
                itemsDic[item.ItemType()].itemCnt++;
            }


        }

 
        return itemsDic;
    }

    public void InventoryUpdate()
    {
        var orin_slotdic = new Dictionary<string, int>();

        foreach(var slot in slots)
        {
            orin_slotdic.Add(slot.GetComponent<Slot>().SlotGet().ItemType(), slot.GetComponent<Slot>().SlotCntget());         
        }
        foreach(var slot in slots)
        {            
            Destroy(slot);            
        }
        


        slots = new List<GameObject>();

        var dicnew = SetItem();


        foreach (var dic in dicnew)
        {

            var s = Instantiate(slot);
            s.transform.SetParent(content.transform);
            s.transform.localScale = new Vector2(1, 1);
            slots.Add(s);
            s.GetComponent<Slot>().SlotSeting(dic.Value.item, dic.Value.itemCnt);

            if (!orin_slotdic.ContainsKey(dic.Key))
            {
                s.AddComponent<Animator>().runtimeAnimatorController = animatorController;
            }
            else
            {
                if(orin_slotdic[dic.Key] < dic.Value.itemCnt)
                {
                    s.AddComponent<Animator>().runtimeAnimatorController = animatorController;

                }


            }
        }


    }


    public void OpenBoxButton()
    {
        SoundPlay("Click");
        if (ItemSystem.Instance.OpenBox())
        {

            InventoryUpdate();
        }

    }

    public void ClickBornfireCreate()
    {
        SoundPlay("Click");
        if (ItemSystem.Instance.BonfireAdd())
        {
            InventoryUpdate();
        }
    }


    public void ClickTorchLightCreate()
    {
        SoundPlay("Click");
        if (ItemSystem.Instance.TorchLightAdd())
        {
            InventoryUpdate();
        }

    }

    public void ClickRaftCreate()
    {

        SoundPlay("Click");
        if (ItemSystem.Instance.RaftAdd())
        {
            InventoryUpdate();
        }
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

        foreach(var but in buts)
        {

            but.interactable = false;
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

        foreach (var but in buts)
        {

            but.interactable = true;
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

    System.Collections.IEnumerator SlotSettingDelay(Dictionary<string, SettingItem> i )
    {

        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
        foreach (var dic in i)
        {

            var s = Instantiate(slot);
            s.transform.SetParent(content.transform);
            s.transform.localScale = new Vector2(1, 1);
            slots.Add(s);
            s.GetComponent<Slot>().SlotSeting(dic.Value.item, dic.Value.itemCnt);
            s.GetComponent<Button>().enabled = false;
            s.AddComponent<Animator>().runtimeAnimatorController = animatorController;
            
            yield return waitForSeconds;

        }


        foreach(var slot in slots)
        {
            slot.GetComponent<Button>().enabled = true;
        }


    }

}
