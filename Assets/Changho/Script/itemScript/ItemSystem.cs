using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{


    [HideInInspector]
    public List<GameObject> items = new List<GameObject>();

    [SerializeField]
    public ItemSlot ItemSlot = new ItemSlot();

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
       
       for(int i= 0; i < player_equ.transform.childCount; i++)
        {

            items.Add(player_equ.transform.GetChild(i).gameObject);

        } 



    }

    // 아이템 클릭 획득
    public void ItemClickAdd(GameObject item)
    {

                
        if (item.GetComponent<Items>() != null)
        {

            items.Add(item); 

     
            ItemSlotCheck(item.GetComponent<Items>());
        }


        item.SetActive (false);

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
    public void FishingItemAdd(GameObject item)
    {

        if (item.GetComponent<Items>() != null)
        {
            if (item.GetComponent<Equipment>() != null)
            {

                var equipmentItem = item.GetComponent<Equipment>();

                items.Add(new Equipment(equipmentItem.equipment_type).gameObject);


                var find_information = FindObjectOfType<UIinfo>().gameObject;

                find_information.GetComponent<UIinfo>()._infotext = item.GetComponent<Equipment>().GetItemName() + " 획득!!!";
                find_information.GetComponent<UIinfo>().TextColor(Color.blue);
                find_information.GetComponent<UIFade>().FadeStart();



                Destroy(item);

             
            }
            else if(item.GetComponent<Fish>() != null)
            {

                var fishItem = item.GetComponent<Fish>();

                items.Add(new Fish(fishItem.fish_type).gameObject);

                ItemInfoUI(item.GetComponent<Part>().GetItemName() + " 획득!!!", Color.blue);
                Destroy(item);





            }
        }
        else
        {
            return;
        }
       


    }


    public void BonfireAdd() // 모닥불 생성
    {
        float fw_cnt = 0;
        float st_cnt = 0;


        foreach (var item in items)
        {
            if (item.GetComponent<Items>() != null)
            {
                if (item.GetComponent<Part>() != null)
                {
                    var item_part = item.GetComponent<Part>();

                    if (item_part.part_type == PartType.FireWood)
                    {
                        fw_cnt++;
                    }

                    if(item_part.part_type == PartType.Firestone)
                    {
                        st_cnt++;

                    }

                }
          
            }



        }



    


        if ((fw_cnt >= 5) && (st_cnt >= 1))
        {
            items.Add(new Equipment(EquipmentType.Bonfire).gameObject);

            for(int i = 0; i < fw_cnt; i++)
            {
                for(int j = 0; j < items.Count; j++)
                {
                  
                    if(items[j].GetComponent<Part>() != null)
                    {
                        if(items[j].GetComponent<Part>().part_type == PartType.FireWood)
                        {

                            items.RemoveAt(j);
                            break;
                        }
                    }


                }

            
            }

            for (int i = 0; i < st_cnt; i++)
            {
                for (int j = 0; j < items.Count; j++)
                {

                    if (items[j].GetComponent<Part>() != null)
                    {
                        if (items[j].GetComponent<Part>().part_type == PartType.Firestone)
                        {

                            items.RemoveAt(j);
                            break;
                        }
                    }


                }


            }

            var inventory = FindObjectOfType<Inventory>();

            inventory.invetoryUpdate();
                 



        }
        else
        {

            ItemInfoUI("모닥불을 만들기에는 아이템 부족......", Color.red);

            return;
        }


    }

    public void TorchLightAdd()
    {
        int oil_cnt = 0;
        int branch_cnt = 0;
        int cloth_cnt = 0;


        foreach (var item in items)
        {
            if (item.GetComponent<Items>() != null)
            {
                if (item.GetComponent<Part>() != null)
                {
                    var item_part = item.GetComponent<Part>();

                    if (item_part.part_type == PartType.Oil)
                    {
                        oil_cnt++;
                    }

                    if (item_part.part_type == PartType.Cloth)
                    {
                        cloth_cnt++;

                    }
                    if (item_part.part_type == PartType.Branch)
                    {
                        branch_cnt++;

                    }

                }

            }

        }



        if(oil_cnt >= 1 && cloth_cnt>= 1 && branch_cnt >= 1)
        {

            var go = (GameObject)Instantiate(Resources.Load("Ganeral/Eqi/TorchLight"));
            go.transform.SetParent(FindObjectOfType<PlayerControl>().equipitem.transform);
            go.SetActive(false);
            items.Add(go);


            for (int i = 0; i <oil_cnt; i++)
            {
                for (int j = 0; j < items.Count; j++)
                {

                    if (items[j].GetComponent<Part>() != null)
                    {
                        if (items[j].GetComponent<Part>().part_type == PartType.Oil)

                        {

                            items.RemoveAt(j);
                            break;
                        }
                    }


                }


            }

            for (int i = 0; i < cloth_cnt; i++)
            {
                for (int j = 0; j < items.Count; j++)
                {

                    if (items[j].GetComponent<Part>() != null)
                    {
                        if (items[j].GetComponent<Part>().part_type == PartType.Cloth)
                        {

                            items.RemoveAt(j);
                            break;
                        }
                    }


                }


            }
            for (int i = 0; i < branch_cnt; i++)
            {
                for (int j = 0; j < items.Count; j++)
                {

                    if (items[j].GetComponent<Part>() != null)
                    {
                        if (items[j].GetComponent<Part>().part_type == PartType.Branch)
                        {

                            items.RemoveAt(j);
                            break;
                        }
                    }


                }


            }

            var inventory = FindObjectOfType<Inventory>();

            inventory.invetoryUpdate();


        }
        else
        {
            ItemInfoUI("횃불을 만들기에는 아이템 부족...." , Color.red);
            return;

        }


    }


    public void RaftAdd()
    {
        int fw_cnt = 0;



        foreach (var item in items)
        {
            if (item.GetComponent<Items>() != null)
            {
                if (item.GetComponent<Part>() != null)
                {
                    var item_part = item.GetComponent<Part>();

                    if (item_part.part_type == PartType.FireWood)
                    {
                        fw_cnt++;
                    }


                }
            }

        }



        if(fw_cnt >= 3)
        {
            items.Add(new Part(PartType.Raft).gameObject);


            for(int i = 0; i < fw_cnt; i++)
            {
                for (int j = 0; j < items.Count; j++)
                {

                    if (items[j].GetComponent<Part>() != null)
                    {
                        if (items[j].GetComponent<Part>().part_type == PartType.FireWood)

                        {

                            items.RemoveAt(j);
                            break;
                        }
                    }


                }

            }


        }
        else
        {
            ItemInfoUI("뗏목을 만들기에는 아이템 부족......" , Color.red);
            return;
        }


    }
    /// <summary>
    /// 아이템을 사용할 경우 회복아이템과 장비에서 모닥불 아이템, 돌은 사용할 경우 개수를 감소킵니다.
    /// </summary>

    public void ItemUseRemove<T>(T it ) where T: Items
    {
       
        foreach(var item in items)
        {
            if(it is Fish)
            {
                if(item.GetComponent<Fish>() != null && item.GetComponent<Fish>().fish_type == it.GetComponent<Fish>().fish_type)
                {
                    items.Remove(item);
                    break;

                }

              
            }
            else if (it is Equipment)
            {
                if (item.GetComponent<Equipment>() != null && item.GetComponent<Equipment>().equipment_type == it.GetComponent<Equipment>().equipment_type)
                {
                    items.Remove(item);
                    break;
                }
                
            }
           else  if (it is Part)
            {
                if (item.GetComponent<Part>() != null && item.GetComponent<Part>().part_type == it.GetComponent<Part>().part_type)
                {
                    items.Remove(item);
                    break;
                }
               
            }
            else if (it is Fruit)
            {
                if (item.GetComponent<Fruit>() != null && item.GetComponent<Fruit>().fluit_type == it.GetComponent<Fruit>().fluit_type)
                {
                    items.Remove(item);
                    break;

                }
               
            }
            else if (it is Seed)
            {
                if (item.GetComponent<Seed>() != null && item.GetComponent<Seed>().seed_type == it.GetComponent<Seed>().seed_type)
                {
                    items.Remove(item);
                    break;

                }
             
            }
            else if (it is Crops)
            {
                if (item.GetComponent<Crops>() != null && item.GetComponent<Crops>().crops_type == it.GetComponent<Crops>().crops_type)
                {
                    items.Remove(item);
                    break;
                }
             
            }



        }




    }



    private void ItemSlotCheck(Items item)
    {


        var find_slots = ItemSlot.slot_items;
        var find_keyslots = ItemSlot.slots_temp;

        int i = 0;
        foreach(var finds_slot in find_slots)
        {

            if((item is Fish) && (finds_slot.Key is Fish))
            {
                var item_fish = (Fish)item;
                var fish_slot = (Fish)finds_slot.Key;

                if (item_fish.fish_type == fish_slot.fish_type)
                {

                    finds_slot.Value.cnt++;
                    find_keyslots[i].GetComponent<Itemelement>().cnt_text.text = finds_slot.Value.cnt.ToString();
                }
            }
            else if ((item is Equipment) && (finds_slot.Key is Equipment))
            {
                var item_equipment = (Equipment)item;
                var equipment_slot = (Equipment)finds_slot.Key;

                if (item_equipment.equipment_type == equipment_slot.equipment_type)
                {

                    finds_slot.Value.cnt++;
                    find_keyslots[i].GetComponent<Itemelement>().cnt_text.text = finds_slot.Value.cnt.ToString();
                }
            }
            else  if ((item is Fruit) && (finds_slot.Key is Fruit))
            {
                var item_fruit = (Fruit)item;
                var fruit_slot = (Fruit)finds_slot.Key;

                if (item_fruit.fluit_type == fruit_slot.fluit_type)
                {

                    finds_slot.Value.cnt++;
                    find_keyslots[i].GetComponent<Itemelement>().cnt_text.text = finds_slot.Value.cnt.ToString();

                }
            }
           else if ((item is Part) && (finds_slot.Key is Part))
            {
                var item_part = (Part)item;
                var part_slot = (Part)finds_slot.Key;

                if (item_part.part_type == part_slot.part_type)
                {
                    finds_slot.Value.cnt++;
                    find_keyslots[i].GetComponent<Itemelement>().cnt_text.text = finds_slot.Value.cnt.ToString();
                }
            }
            else if ((item is Seed) && (finds_slot.Key is Seed))
            {
                var item_part = (Seed)item;
                var part_slot = (Seed)finds_slot.Key;

                if (item_part.seed_type == part_slot.seed_type)
                {
                    finds_slot.Value.cnt++;
                    find_keyslots[i].GetComponent<Itemelement>().cnt_text.text = finds_slot.Value.cnt.ToString();
                }
            }
            else if ((item is Crops) && (finds_slot.Key is Crops))
            {
                var item_part = (Crops)item;
                var part_slot = (Crops)finds_slot.Key;

                if (item_part.crops_type == part_slot.crops_type)
                {
                    finds_slot.Value.cnt++;
                    find_keyslots[i].GetComponent<Itemelement>().cnt_text.text = finds_slot.Value.cnt.ToString();
                }
            }



            i++;

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


