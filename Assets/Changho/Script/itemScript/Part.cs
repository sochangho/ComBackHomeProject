using UnityEngine;


public enum PartType
{
    Nail, //못
    Rope,
    FireWood,
    Cloth,
    Oil,
    Firestone,
    Water,
    Branch,
    Raft,
    DefaultSton

}


public class Part : Items
{

    public PartType part_type;

    public Part(PartType type)
    {

        part_type = type;
        itemInfoSet();
    }


    //천(횃불,돛단배), 기름(횃불), 부싯돌(돌 중에 특별한 돌)

    void Awake()
    {
        if(part_type == PartType.Nail)
        {
            itemname = "못";
            subscript = "배를 수리하기 위한 도구";

        }
        else if (part_type == PartType.Rope)
        {
            itemname = "밧줄";
            subscript = "배를 수리하기 위한 도구";
        }
        else if (part_type == PartType.FireWood)
        {
            itemname = "장작";
            subscript ="배를 수리하고 모닥불을 피울 수 있는 도구";
        }
        else if(part_type == PartType.Cloth)
        {
            itemname = "천";
            subscript = "배의 돗을 만들고 횟불을 만들 때 필요";
        }
        else if (part_type == PartType.Oil)
        {
            itemname = "기름";
            subscript = "횟불에 불붙일때 필요하다";

        }
        else if (part_type == PartType.Firestone)
        {
            itemname = "부싯돌";
            subscript = "모닥불을 만들 때 필요하다.";
        }
        else if(part_type == PartType.Water)
        {
            itemname = "물";
            subscript = "농장물 성장시키기 위해 필요하다.";

        }
        else if(part_type == PartType.Branch)
        {
            itemname = "나뭇가지";
            subscript = "횟불을 만들 수 있다.";

        }
        else if (part_type == PartType.Raft)
        {
            itemname = "뗏못";
            subscript ="바다에서 낚시를 하거나 쓰레기 수집을 할 수 있다.";

        }
        else if(part_type == PartType.DefaultSton)
        {
            itemname = "돌";
            subscript = "나무를 맞춰 과일을 떨어뜨리거나 벌레때들을 맞춰서 공격할 수 있다.";

        }
    }


    public override void itemInfoSet()
    {
        base.itemInfoSet();

        if (part_type == PartType.Nail)
        {
            itemname = "못";
            subscript = "배를 수리하기 위한 도구";

        }
        else if (part_type == PartType.Rope)
        {
            itemname = "밧줄";
            subscript = "배를 수리하기 위한 도구";
        }
        else if (part_type == PartType.FireWood)
        {
            itemname = "장작";
            subscript = "배를 수리하고 모닥불을 피울 수 있는 도구";
        }
        else if (part_type == PartType.Cloth)
        {
            itemname = "천";
            subscript = "배의 돗을 만들고 횟불을 만들 때 필요";
        }
        else if (part_type == PartType.Oil)
        {
            itemname = "기름";
            subscript = "횟불에 불붙일때 필요하다";

        }
        else if (part_type == PartType.Firestone)
        {
            itemname = "부싯돌";
            subscript = "모닥불을 만들 때 필요하다.";
        }
        else if (part_type == PartType.Water)
        {
            itemname = "물";
            subscript = "농장물 성장시키기 위해 필요하다.";

        }
        else if (part_type == PartType.Branch)
        {
            itemname = "나뭇가지";
            subscript = "횟불을 만들 수 있다.";

        }
        else if (part_type == PartType.Raft)
        {
            itemname = "뗏못";
            subscript = "바다에서 낚시를 하거나 쓰레기 수집을 할 수 있다.";

        }
        else if (part_type == PartType.DefaultSton)
        {
            itemname = "돌";
            subscript = "나무를 맞춰 과일을 떨어뜨리거나 벌레때들을 맞춰서 공격할 수 있다.";

        }


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
        itemtype = part_type.ToString();

        return itemtype;
    }

}
