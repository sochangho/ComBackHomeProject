using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum EquipmentType
{
    Axe,
    Fishing,
    Bonfire,
    Ston,
    Bowl,
    TorchLight,
    Fkiller
  
}


public class Equipment : Items
{



    public EquipmentType equipment_type;


    public Equipment( EquipmentType type)
    {
        equipment_type = type;
        itemInfoSet();
    }


    // Start is called before the first frame update
    void Awake()
    {
       

        if (equipment_type == EquipmentType.Axe)
        {
            itemname = "도끼";
            subscript = "나무를 벨 수 있다.";
                
        }
        else if (equipment_type == EquipmentType.Fishing)
        {
            itemname = "낚시";
            subscript = "물고기를 잡을 수 있습니다.";
        }
        else if(equipment_type == EquipmentType.Bonfire)
        {
            itemname = "모닥불";
            subscript = "HP회복과 일정범위 이내의 좀비가 나타나는 것을 막을 수 있습니다. ";
        }else if(equipment_type == EquipmentType.Ston)
        {
            itemname = "돌맹이";
            subscript = "좀비를 때리거나 높이있는 과일들을 맞춰 떨어뜨릴 수 있습니다. ";
        }
        else if(equipment_type == EquipmentType.Bowl)
        {
            itemname = "물 뿌리게";
            subscript = "호수에서 물 퍼내는 용도,농장물을 기를 수 있다, 쓰레기 더미에서 수집할 수 있다.";

        }
        else if (equipment_type == EquipmentType.TorchLight)
        {
            itemname = "횃불";
            subscript ="주변에 벌래 떼를 피할 수 있다.";

            
        }
        else if(equipment_type == EquipmentType.Fkiller)
        {
            itemname = "에프킬러";
            subscript = "주변에 벌래 떼를 퇴치할 수 있다.";
        }
       
    }


    public override void itemInfoSet()
    {
        base.itemInfoSet();

        if (equipment_type == EquipmentType.Axe)
        {
            itemname = "도끼";
            subscript = "나무를 벨 수 있다.";

        }
        else if (equipment_type == EquipmentType.Fishing)
        {
            itemname = "낚시";
            subscript = "물고기를 잡을 수 있습니다.";
        }
        else if (equipment_type == EquipmentType.Bonfire)
        {
            itemname = "모닥불";
            subscript = "HP회복과 일정범위 이내의 좀비가 나타나는 것을 막을 수 있습니다. ";
        }
        else if (equipment_type == EquipmentType.Ston)
        {
            itemname = "돌맹이";
            subscript = "좀비를 때리거나 높이있는 과일들을 맞춰 떨어뜨릴 수 있습니다. ";
        }
        else if (equipment_type == EquipmentType.Bowl)
        {
            itemname = "물 뿌리게";
            subscript = "호수에서 물 퍼내는 용도,농장물을 기를 수 있다, 쓰레기 더미에서 수집할 수 있다.";

        }
        else if (equipment_type == EquipmentType.TorchLight)
        {
            itemname = "횃불";
            subscript = "주변에 벌래 떼를 피할 수 있다.";


        }
        else if (equipment_type == EquipmentType.Fkiller)
        {
            itemname = "에프킬러";
            subscript = "주변에 벌래 떼를 퇴치할 수 있다.";
        }


    }


    public override void ItemUse()
    {
        base.ItemUse();

        var player = FindObjectOfType<PlayerControl>();

        if (equipment_type == EquipmentType.Axe)
        {
            //장작 획득과 
            //나무배는 애니메이션

            var player_eq = player.usingitem;

            player_eq.GetComponent<AxeStart>().AxeWield();


        }
        else if (equipment_type == EquipmentType.Fishing)
        {
            //물고기 획득과
            //낚시하는 애니매이션

        }
        else if (equipment_type == EquipmentType.Bonfire)
        {

            var p = FindObjectOfType<PlayerControl>().spwan_point;

            RaycastHit raycastHit;

            if (Physics.Raycast(p.transform.position, Vector3.down, out raycastHit, 10f))
            {
                Vector3 tarrein_uppoint = new Vector3(raycastHit.point.x, raycastHit.point.y + 1.5f, raycastHit.point.z);

                Instantiate(Resources.Load<GameObject>("Ganeral/Eqi/Bornfire") as GameObject, tarrein_uppoint, Quaternion.identity);
                ItemSystem.Instance.ItemUseRemove(this);
            }
            else
            {
                //생성할 수 없습니다.
                ItemSystem.Instance.ItemInfoUI("모닥불을 피울 수 없습니다....", Color.red);
            }

        }
        else if (equipment_type == EquipmentType.Ston)
        {                         
          player.stons.Shot();                            
        }
        else if (equipment_type == EquipmentType.Bowl)
        {
            //물뿌리는 애니메이션과 인벤토리에서 물이있나없나확인 있으면 물을 뿌려서 식물을 기를 수 있다.

            var use = player.usingitem;
            int cnt_water = use.GetComponent<BowlWater>().GetWater();

            if (cnt_water > 0)
            {
                use.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                use.GetComponent<BowlWater>().WateringAnimation();
                cnt_water--;
                use.GetComponent<BowlWater>().SetWater(cnt_water);

            }
            else
            {
                ItemSystem.Instance.ItemInfoUI("물이 없습니다....", Color.red);

            }





        }
        else if (equipment_type == EquipmentType.TorchLight)
        {
            // 장착하는 아이템 
            //사용하면 주변의 벌레때들이 못오게한다.

            var player_eq = player.usingitem;

            player_eq.GetComponent<TorchLlightStart>().Wield();
        }
        else if(equipment_type == EquipmentType.Fkiller)
        {

            var player_eq = player.usingitem;

            player_eq.GetComponent<Spray>().SprayUse();

        }


        Debug.Log("아이템 총개수" + ItemSystem.Instance.items.Count);
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
        itemtype = equipment_type.ToString();

        return itemtype;
    }


 

 

   
}
