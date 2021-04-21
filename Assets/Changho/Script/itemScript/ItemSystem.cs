using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{


    [HideInInspector]
    public List<Items> items = new List<Items>();

    [HideInInspector]
    public Dictionary<string, int> trashs = new Dictionary<string, int>();

  
    [HideInInspector]
    public int randomboxAdd;

    [HideInInspector]
    public bool trashAddPopup = false;


    public List<Items> prefebitems;

    public bool warterTrigger = false;

   
    private static ItemSystem _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static ItemSystem Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(ItemSystem)) as ItemSystem;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {

       var player_equ =  FindObjectOfType<PlayerControl>().equipitem;


        ItemCreate("Axe");
       
    }


    public void ItemCreate(string itemtypename)
    {

        foreach(var additem in prefebitems)
        {
            if(additem.ItemType() == itemtypename)
            {
                var go = Instantiate(additem.gameObject);
                items.Add(go.GetComponent<Items>());
                go.transform.SetParent(this.transform);
                go.SetActive(false);
                        
            }
        }

    }
    

    /// <summary>
    /// 팝업창 뜨면 실행
    /// </summary>
    public void TrashAdd()
    {
        
        foreach(var trash in trashs)
        {
            for(int j =0; j < trash.Value; j++)
            {

                ItemCreate(trash.Key);

            }


        }


    }


    // 아이템 클릭 획득
    public void ItemClickAdd(GameObject item)
    {

                
        if (item.GetComponent<Items>() != null)
        {

            foreach(var additem in prefebitems)
            {
                if(item.GetComponent<Items>().ItemType() == additem.ItemType())
                {
                    var go = Instantiate(additem.gameObject);
                    items.Add(go.GetComponent<Items>());
                    go.transform.SetParent(this.transform);
                    go.SetActive(false);
                    Destroy(item);
                    ItemSlotCheck(item.GetComponent<Items>());

                }
                

            }

                       
        }
    }



    /// <summary>
    /// 바가지가 있으면 물획득가능 물획득 한번 후에 바가지는 파괴
    /// </summary>
    public void WaterAdd()
    {
        int cnt_bowl = 0;

        foreach(var item in items)
        {
           
          if(item.GetComponent<Items>().ItemType() == "Bowl")
          {
                cnt_bowl++;
                var water_cnt = item.GetComponent<BowlWater>().GetWater();
                water_cnt++;
                item.GetComponent<BowlWater>().SetWater(water_cnt);
                ItemInfoUI("물 획득!!", Color.blue);
                break;
                
          }

        }

        if(cnt_bowl == 0)
        {

            ItemInfoUI("물 뿌리개가 없습니다 ... ", Color.red);
        }
    }

    // 아이템 낚시로 획득
    //public void FishingItemAdd(GameObject item)
    //{

    //    if (item.GetComponent<Items>() != null)
    //    {
    //        if (item.GetComponent<Equipment>() != null)
    //        {

    //            var equipmentItem = item.GetComponent<Equipment>();

    //            items.Add(new Equipment(equipmentItem.equipment_type).gameObject);


    //            var find_information = FindObjectOfType<UIinfo>().gameObject;

    //            find_information.GetComponent<UIinfo>()._infotext = item.GetComponent<Equipment>().GetItemName() + " 획득!!!";
    //            find_information.GetComponent<UIinfo>().TextColor(Color.blue);
    //            find_information.GetComponent<UIFade>().FadeStart();



    //            Destroy(item);

             
    //        }
    //        else if(item.GetComponent<Fish>() != null)
    //        {

    //            var fishItem = item.GetComponent<Fish>();

    //            items.Add(new Fish(fishItem.fish_type).gameObject);

    //            ItemInfoUI(item.GetComponent<Part>().GetItemName() + " 획득!!!", Color.blue);
    //            Destroy(item);





    //        }
    //    }
    //    else
    //    {
    //        return;
    //    }
       


    //}


    //public void BonfireAdd() // 모닥불 생성
    //{
    //    float fw_cnt = 0;
    //    float st_cnt = 0;


    //    foreach (var item in items)
    //    {
    //        if (item.GetComponent<Items>() != null)
    //        {
    //            if (item.GetComponent<Part>() != null)
    //            {
    //                var item_part = item.GetComponent<Part>();

    //                if (item_part.part_type == PartType.FireWood)
    //                {
    //                    fw_cnt++;
    //                }

    //                if(item_part.part_type == PartType.Firestone)
    //                {
    //                    st_cnt++;

    //                }

    //            }
          
    //        }



    //    }



    


    //    if ((fw_cnt >= 5) && (st_cnt >= 1))
    //    {
    //        items.Add(new Equipment(EquipmentType.Bonfire).gameObject);

    //        for(int i = 0; i < fw_cnt; i++)
    //        {
    //            for(int j = 0; j < items.Count; j++)
    //            {
                  
    //                if(items[j].GetComponent<Part>() != null)
    //                {
    //                    if(items[j].GetComponent<Part>().part_type == PartType.FireWood)
    //                    {

    //                        items.RemoveAt(j);
    //                        break;
    //                    }
    //                }


    //            }

            
    //        }

    //        for (int i = 0; i < st_cnt; i++)
    //        {
    //            for (int j = 0; j < items.Count; j++)
    //            {

    //                if (items[j].GetComponent<Part>() != null)
    //                {
    //                    if (items[j].GetComponent<Part>().part_type == PartType.Firestone)
    //                    {

    //                        items.RemoveAt(j);
    //                        break;
    //                    }
    //                }


    //            }


    //        }

    //        var inventory = FindObjectOfType<Inventory>();

    //        inventory.invetoryUpdate();
                 



    //    }
    //    else
    //    {

    //        ItemInfoUI("모닥불을 만들기에는 아이템 부족......", Color.red);

    //        return;
    //    }


    //}

    //public void TorchLightAdd()
    //{
    //    int oil_cnt = 0;
    //    int branch_cnt = 0;
    //    int cloth_cnt = 0;


    //    foreach (var item in items)
    //    {
    //        if (item.GetComponent<Items>() != null)
    //        {
    //            if (item.GetComponent<Part>() != null)
    //            {
    //                var item_part = item.GetComponent<Part>();

    //                if (item_part.part_type == PartType.Oil)
    //                {
    //                    oil_cnt++;
    //                }

    //                if (item_part.part_type == PartType.Cloth)
    //                {
    //                    cloth_cnt++;

    //                }
    //                if (item_part.part_type == PartType.Branch)
    //                {
    //                    branch_cnt++;

    //                }

    //            }

    //        }

    //    }



    //    if(oil_cnt >= 1 && cloth_cnt>= 1 && branch_cnt >= 1)
    //    {

    //        var go = (GameObject)Instantiate(Resources.Load("Ganeral/Eqi/TorchLight"));
    //        go.transform.SetParent(FindObjectOfType<PlayerControl>().equipitem.transform);
    //        go.SetActive(false);
    //        items.Add(go);


    //        for (int i = 0; i <oil_cnt; i++)
    //        {
    //            for (int j = 0; j < items.Count; j++)
    //            {

    //                if (items[j].GetComponent<Part>() != null)
    //                {
    //                    if (items[j].GetComponent<Part>().part_type == PartType.Oil)

    //                    {

    //                        items.RemoveAt(j);
    //                        break;
    //                    }
    //                }


    //            }


    //        }

    //        for (int i = 0; i < cloth_cnt; i++)
    //        {
    //            for (int j = 0; j < items.Count; j++)
    //            {

    //                if (items[j].GetComponent<Part>() != null)
    //                {
    //                    if (items[j].GetComponent<Part>().part_type == PartType.Cloth)
    //                    {

    //                        items.RemoveAt(j);
    //                        break;
    //                    }
    //                }


    //            }


    //        }
    //        for (int i = 0; i < branch_cnt; i++)
    //        {
    //            for (int j = 0; j < items.Count; j++)
    //            {

    //                if (items[j].GetComponent<Part>() != null)
    //                {
    //                    if (items[j].GetComponent<Part>().part_type == PartType.Branch)
    //                    {

    //                        items.RemoveAt(j);
    //                        break;
    //                    }
    //                }


    //            }


    //        }

    //        var inventory = FindObjectOfType<Inventory>();

    //        inventory.invetoryUpdate();


    //    }
    //    else
    //    {
    //        ItemInfoUI("횃불을 만들기에는 아이템 부족...." , Color.red);
    //        return;

    //    }


    //}


    //public void RaftAdd()
    //{
    //    int fw_cnt = 0;



    //    foreach (var item in items)
    //    {
    //        if (item.GetComponent<Items>() != null)
    //        {
    //            if (item.GetComponent<Part>() != null)
    //            {
    //                var item_part = item.GetComponent<Part>();

    //                if (item_part.part_type == PartType.FireWood)
    //                {
    //                    fw_cnt++;
    //                }


    //            }
    //        }

    //    }



    //    if(fw_cnt >= 3)
    //    {
    //        items.Add(new Part(PartType.Raft).gameObject);


    //        for(int i = 0; i < fw_cnt; i++)
    //        {
    //            for (int j = 0; j < items.Count; j++)
    //            {

    //                if (items[j].GetComponent<Part>() != null)
    //                {
    //                    if (items[j].GetComponent<Part>().part_type == PartType.FireWood)

    //                    {

    //                        items.RemoveAt(j);
    //                        break;
    //                    }
    //                }


    //            }

    //        }


    //    }
    //    else
    //    {
    //        ItemInfoUI("뗏목을 만들기에는 아이템 부족......" , Color.red);
    //        return;
    //    }


    //}
    /// <summary>
    /// 아이템을 사용할 경우 회복아이템과 장비에서 모닥불 아이템, 돌은 사용할 경우 개수를 감소킵니다.
    /// </summary>

    public void ItemUseRemove<T>(T it ) where T: Items
    {
       
        foreach(var item in items)
        {
         
            if(item.ItemType() == it.ItemType())
            {
                Debug.Log("삭제"); 
                items.Remove(item);
                Destroy(item.gameObject);
                break;
            }


        }




    }



    private void ItemSlotCheck(Items item)
    {
        var elements = FindObjectOfType<ItemSlot>().useitems;
        int cnt_update = 0;
     
        foreach(var element in elements)
        {
            if(element.GetItemelement() == item.ItemType())
            {
                foreach (var it in items)
                {
                    if (it.ItemType() == item.ItemType())
                    {

                        cnt_update++;

                    }

                }

                element.ElementCntUpdate(cnt_update);
                break;
            }


        }


     


    }


    public void ItemInfoUI(string str , Color font_color)
    {

        var find_information = FindObjectOfType<UIinfo>().gameObject;

        find_information.GetComponent<UIinfo>()._infotext = str;
        find_information.GetComponent<UIinfo>().TextColor(font_color);
        find_information.GetComponent<UIFade>().FadeStart();

    }
}


