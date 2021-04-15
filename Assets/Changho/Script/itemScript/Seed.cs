using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SeedType
{

    CucumberSeed,
    RiceplantSeed,
    TomatoSeed,
    CornSeed
}

public class Seed : Items
{
    public SeedType seed_type;

    public Seed(SeedType st)
    {
        seed_type = st;
    }


    void Awake()
    {
       if(seed_type == SeedType.CornSeed)
       {
            itemname = "옥수수 씨앗";
            subscript = "옥수수 농작물";
        }
       if(seed_type == SeedType.CucumberSeed)
       {
            itemname = "오이 씨앗";
            subscript ="오이 농작물";
        }
       if(seed_type == SeedType.RiceplantSeed)
       {
            itemname = "벼 씨앗";
            subscript = "벼 농작물";
        }
       if(seed_type == SeedType.TomatoSeed)
        {
            itemname = "토마토 씨앗";
            subscript = "토마토 농작물";
        }

    }

    public override void itemInfoSet()
    {
        base.itemInfoSet();

        if (seed_type == SeedType.CornSeed)
        {
            itemname = "옥수수 씨앗";
            subscript = "옥수수 농작물";
        }
        if (seed_type == SeedType.CucumberSeed)
        {
            itemname = "오이 씨앗";
            subscript = "오이 농작물";
        }
        if (seed_type == SeedType.RiceplantSeed)
        {
            itemname = "벼 씨앗";
            subscript = "벼 농작물";
        }
        if (seed_type == SeedType.TomatoSeed)
        {
            itemname = "토마토 씨앗";
            subscript = "토마토 농작물";
        }



    }
    public override void ItemUse()
    {
        if (seed_type == SeedType.CornSeed)
        {
            // 옥수수 생성
        }
        else if (seed_type == SeedType.CucumberSeed)
        {
            // 오이 생성
        }
        else if (seed_type == SeedType.RiceplantSeed)
        {
            //벼 생성
        }
        else if (seed_type == SeedType.TomatoSeed)
        {
            //토마토 생성
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
        itemtype = seed_type.ToString();

        return itemtype;
    }

}
