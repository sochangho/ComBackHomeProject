using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    public List<Itemelement> useitems;


    private bool z_trigger = false;
    private bool x_trigger = false;
    private bool c_trigger = false;
    private bool v_trigger = false;


    /// <summary>
    /// Z입력
    /// </summary>
    public void ItemUseZ()
    {
        if (!z_trigger)
        {
            useitems[0].SlotUse();
            z_trigger = true;
            StartCoroutine(ZRoutin());
        }
    }


    /// <summary>
    /// X입력
    /// </summary>
    public void ItemUseX()
    {
        if (!x_trigger)
        {
            useitems[1].SlotUse();
            x_trigger = true;
            StartCoroutine(XRoutin());
        }
       
    }


    /// <summary>
    /// C입력
    /// </summary>

    public void ItemUseC()
    {

        if (!c_trigger)
        {
            useitems[2].SlotUse();
            c_trigger = true;
            StartCoroutine(CRoutin());
        }

       
    }
    /// <summary>
    /// V입력
    /// </summary>
    public void ItemUseV()
    {

        if (!v_trigger)
        {
            useitems[3].SlotUse();
            v_trigger = true;
            StartCoroutine(VRoutin());
        }

    }



    public void itemslotAdd(Items item ,int itemcnt)
    {
        var cnt = 0;
        foreach(var useitem in useitems)
        {
            if (useitem.GetItemelement() == null)
            {
                useitem.SetItemelement(item, itemcnt);
                cnt++;
                break;
            }
            else if(useitem.GetItemelement()== item.ItemType())
            {
                ItemSystem.Instance.ItemInfoUI("이미 사용중인 아이템 입니다!", Color.red);
                break;
            }

        }

     


    }


    IEnumerator ZRoutin()
    {

        float time = 0;


        while (time < 0.3f)
        {

            time += Time.deltaTime;

            yield return null;

        }

        if (z_trigger)
        {

            z_trigger = false;
        }


    }

    IEnumerator CRoutin()
    {

        float time = 0;


        while (time < 0.3f)
        {

            time += Time.deltaTime;

            yield return null;

        }

        if (c_trigger)
        {

            c_trigger = false;
        }


    }

    IEnumerator XRoutin()
    {

        float time = 0;


        while (time < 0.3f)
        {

            time += Time.deltaTime;

            yield return null;

        }

        if (x_trigger)
        {

            x_trigger = false;
        }


    }

    IEnumerator VRoutin()
    {

        float time = 0;


        while (time < 0.3f)
        {

            time += Time.deltaTime;

            yield return null;

        }

        if (v_trigger)
        {

            v_trigger = false;
        }


    }


}



public class ItemInfo
{
   public int cnt;
   public Image info_image;

    public ItemInfo(int cnt , Image image)
    {
        this.cnt = cnt;
        info_image = image;
    }


}
