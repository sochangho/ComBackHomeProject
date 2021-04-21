using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SeedType
{

    ChilliSeed,
    EggplantSeed,
    TomatoSeed,
    CornSeed
}

public class Seed : Items
{
    public SeedType seed_type;

    public Seed(SeedType st)
    {
        seed_type = st;
        itemInfoSet();
    }


    void Awake()
    {
       if(seed_type == SeedType.CornSeed)
       {
            itemname = "옥수수 씨앗";
            subscript = "옥수수 농작물";
        }
       if(seed_type == SeedType.ChilliSeed)
       {
            itemname = "오이고추 씨앗";
            subscript ="오이고추 농작물";
        }
       if(seed_type == SeedType.EggplantSeed)
       {
            itemname = "가지 씨앗";
            subscript = "가지 농작물";
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
        if (seed_type == SeedType.ChilliSeed)
        {
            itemname = "오이고추 씨앗";
            subscript = "오이고추 농작물";
        }
        if (seed_type == SeedType.EggplantSeed)
        {
            itemname = "가지 씨앗";
            subscript = "가지 농작물";
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
            
        }
        if (seed_type == SeedType.ChilliSeed)
        {
          
        }
        if (seed_type == SeedType.EggplantSeed)
        {
          
        }
        if (seed_type == SeedType.TomatoSeed)
        {
            
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
