using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CropsType
{
    Chilli,
    Eggplant,
    Tomato,
    Corn
}


public class Crops : Items
{
    public CropsType crops_type;

    public Crops(CropsType type)
    {

        crops_type = type;
        itemInfoSet();
    }


    void Awake()
    {
        if (crops_type == CropsType.Corn)
        {
            itemname = "옥수수";
            subscript = " ";
        }
        if (crops_type == CropsType.Chilli)
        {
            itemname = "오이고추";
            subscript = " ";
        }
        if (crops_type == CropsType.Eggplant)
        {
            itemname = "가지";
            subscript = " ";
        }
        if (crops_type == CropsType.Tomato)
        {
            itemname = "토마토";
            subscript = " ";
        }

    }


    public override void itemInfoSet()
    {
        base.itemInfoSet();


        if (crops_type == CropsType.Corn)
        {
            itemname = "옥수수";
            subscript = " ";
        }
        if (crops_type == CropsType.Chilli)
        {
            itemname = "오이고추";
            subscript = " ";
        }
        if (crops_type == CropsType.Eggplant)
        {
            itemname = "가지";
            subscript = " ";
        }
        if (crops_type == CropsType.Tomato)
        {
            itemname = "토마토";
            subscript = " ";
        }


    }

    public override void ItemUse()
    {

        var player = FindObjectOfType<PlayerControl>();

        if (crops_type == CropsType.Corn)
        {
            // 옥수수 생성
            player.player_hp += 20f;

        }
        else if (crops_type == CropsType.Chilli)
        {
            // 오이 생성
            player.player_hp += 20f; 
        }
        else if (crops_type == CropsType.Eggplant)
        {
            //벼 생성

            player.player_hp += 20f;
        }
        else if (crops_type == CropsType.Tomato)
        {
            //토마토 생성
            player.player_hp += 20f;

        }
        ItemSystem.Instance.ItemUseRemove(this);

    }

    public override string GetItemName()
    {
        return itemname;
    }

    public override string GetItemsubscript()
    {
        return subscript;
    }

    public override string ItemType()
    {
        itemtype = crops_type.ToString();

        return itemtype;
    }




}
