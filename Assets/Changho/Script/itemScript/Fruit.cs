
using UnityEngine;



public enum FuritType
{
    Apple,
    Banana,
    Coconet
}
public class Fruit : Items
{
    public FuritType fluit_type;

    public Fruit(FuritType ft)
    {
        fluit_type = ft;

    }

    private void Awake()
    {
        if (fluit_type == FuritType.Apple)
        {
          
            itemname = "사과";
            subscript = "허기짐을 5% 회복시켜준다.";
        }
        else if (fluit_type == FuritType.Banana)
        {
            itemname = "바나나";
            subscript = "허기짐을 10% 회복시켜준다.";
        }
        else if (fluit_type == FuritType.Coconet)
        {
            itemname = "코코넛";
            subscript = "허기짐을 3% 회복시켜준다.";
        }



    }

    public override void itemInfoSet()
    {
        base.itemInfoSet();

        if (fluit_type == FuritType.Apple)
        {

            itemname = "사과";
            subscript = "허기짐을 5% 회복시켜준다.";
        }
        else if (fluit_type == FuritType.Banana)
        {
            itemname = "바나나";
            subscript = "허기짐을 10% 회복시켜준다.";
        }
        else if (fluit_type == FuritType.Coconet)
        {
            itemname = "코코넛";
            subscript = "허기짐을 3% 회복시켜준다.";
        }




    }



    public override void ItemUse()
    {

        var player = FindObjectOfType<PlayerControl>();
        if (player.player_hungry <= 0)
        {
            StopCoroutine(player.hpDecrease_coroutin);
            player.hungryDecrease_coroutin= StartCoroutine(player.HungryDecease());

        }


        Debug.Log("과일 사용");
        if (fluit_type == FuritType.Apple)
        {
            Debug.Log("사과 사용");
            //HP를 5%회복
            player.player_hungry += 5;
        }
        else if (fluit_type == FuritType.Banana)
        {
            Debug.Log("바나나 사용");
            //HP를 5%회복
            //HP를 10%회복
            player.player_hungry += 10;
        }
        else if (fluit_type == FuritType.Coconet)
        {
            Debug.Log("코코넛 사용");            
            //HP를 3%회복
            player.player_hungry += 3;
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
        itemtype = fluit_type.ToString();

        return itemtype;
    }


}
