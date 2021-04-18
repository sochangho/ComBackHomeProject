
using UnityEngine;


public enum FishType
{
    Big,
    Middle,
    Small
}


public class Fish : Items
{
    public FishType fish_type;

    //[HideInInspector]
    //public float big_cnt;

    //[HideInInspector]
    //public float middle_cnt;

    //[HideInInspector]
    //public float small_cnt;


   public Fish(FishType type)
    {

        fish_type = type;
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(fish_type == FishType.Big)
        {
            itemname = "큰 물고기";
            subscript = "허기짐 15% 회복시켜준다.";
        }
        else if (fish_type == FishType.Middle)
        {
            itemname = "중간 물고기";
            subscript = "허기짐 10% 회복시켜준다.";
        }
        else if (fish_type == FishType.Small)
        {
            itemname = "작은 물고기";
            subscript ="허기짐 5% 회복시켜준다.";
        }
       
    }


    public override void itemInfoSet()
    {
        base.itemInfoSet();


        if (fish_type == FishType.Big)
        {
            itemname = "큰 물고기";
            subscript = "허기짐 15% 회복시켜준다.";
        }
        else if (fish_type == FishType.Middle)
        {
            itemname = "중간 물고기";
            subscript = "허기짐 10% 회복시켜준다.";
        }
        else if (fish_type == FishType.Small)
        {
            itemname = "작은 물고기";
            subscript = "허기짐 5% 회복시켜준다.";
        }


    }

    public override void ItemUse()
    {
        var player = FindObjectOfType<PlayerControl>();

        if(player.player_hungry <= 0)
        {
            StopCoroutine(player.hpDecrease_coroutin);
           player.hungryDecrease_coroutin = StartCoroutine(player.HungryDecease());

        }

        Debug.Log("물고기 사용");
        if (fish_type == FishType.Big)
        {
            //HP를 15%회복

            player.player_hungry += 15;

        }
        else if (fish_type == FishType.Middle)
        {
            //HP를 10%회복
            player.player_hungry += 10;
        }
        else if (fish_type == FishType.Small)
        {
            //HP를 5%회복
            player.player_hungry += 5;
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
        itemtype = fish_type.ToString();

        return itemtype;
    }

}
