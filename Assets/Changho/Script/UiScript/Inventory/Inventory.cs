
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Popup
{
    public delegate void InvetoryUpdate();

    public InvetoryUpdate invetoryUpdate; 


    //하위오브젝트 슬롯들
    public List<GameObject> slots;

    public GameObject item_panel;

    //슬롯 프리팹 오브젝트
    public Image Bigfish_Image;

    public Image Middlefish_Image;

    public Image Smallfish_Image;

    public Image Apple_Image;

    public Image Banana_Image;

    public Image Coconut_Image;

    public Image Axe_Image;

    public Image Bonfire_Image;

    public Image Fishing_Image;

    public Image Ston_Image;

    public Image Bowl_Image;

    public Image TorchLight_Image;

    public Image Fkiller_Image;

    public Image Nail_Image;

    public Image Rope_Image;

    public Image Firewood_Image;

    public Image Cloth_Image;

    public Image Oil_Image;

    public Image Fireston_Image;

    public Image Water_Image;

    public Image Branch_Image;

    public Image Raft_Image;

    public Image CornSeed_Image;

    public Image CucumberSeed_Image;

    public Image RicePlantSeed_Image;

    public Image TomatoSeed_Image;

    public Image Corn_Image;

    public Image Cucumber_Image;

    public Image RicePlant_Image;

    public Image Tomato_Image;


 

    private void Start()
    {

        item_panel.SetActive(false);

        invetoryUpdate = new InvetoryUpdate(SetItem);
        invetoryUpdate += SetSprit;

        invetoryUpdate();
    }

    public void OnCloseButtonPress()
    {
        if(item_panel.activeSelf == true)
        {
            item_panel.SetActive(false);
        }
        PlayerControl.Instance.enabled = true;
        Close();
    }


    /// <summary>
    /// 인벤토리에 들어갈 아이템 개수를 초기화 시킵니다.
    /// </summary>
    public void SetItem()
    {


        var itemslot = ItemSystem.Instance.items;

        foreach (var item in itemslot)
        {
            item.GetComponent<Items>().itemInfoSet();
        }




        for (int i = 0; i < itemslot.Count; i++)
        {

            for (int j = 0; j < slots.Count; j++)
            {

                if (slots[j].GetComponent<Slot>()._fish == null
                    && slots[j].GetComponent<Slot>()._equ == null
                    && slots[j].GetComponent<Slot>()._part == null && slots[j].GetComponent<Slot>()._fruit == null
                    && slots[j].GetComponent<Slot>()._seed == null && slots[j].GetComponent<Slot>()._crops == null)
                {
                    if (itemslot[i] != null && itemslot[i].GetComponent<Fish>() != null)
                    {
                        slots[j].GetComponent<Slot>()._fish = itemslot[i].GetComponent<Fish>();
                        slots[j].GetComponent<Slot>().cnt++;

                        if(i == itemslot.Count)
                        {
                            return;
                        }


                        break;
                    }
                    else if (itemslot[i] != null &&itemslot[i].GetComponent<Equipment>() != null)
                    {
                        slots[j].GetComponent<Slot>()._equ = itemslot[i].GetComponent<Equipment>();
                        slots[j].GetComponent<Slot>().cnt++;

                        if (i == itemslot.Count)
                        {
                            return;
                        }

                        break;
                    }
                    else if (itemslot[i] != null && itemslot[i].GetComponent<Part>() != null)
                    {
                        slots[j].GetComponent<Slot>()._part = itemslot[i].GetComponent<Part>();
                        slots[j].GetComponent<Slot>().cnt++;
                        if (i == itemslot.Count)
                        {
                            return;
                        }

                        break;
                    }
                    else if (itemslot[i] != null && itemslot[i].GetComponent<Fruit>() != null)
                    {
                        slots[j].GetComponent<Slot>()._fruit = itemslot[i].GetComponent<Fruit>();
                        slots[j].GetComponent<Slot>().cnt++;
                        if (i == itemslot.Count)
                        {
                            return;
                        }


                        break;
                    }
                    else if (itemslot[i] != null && itemslot[i].GetComponent<Seed>() != null)
                    {
                        slots[j].GetComponent<Slot>()._seed = itemslot[i].GetComponent<Seed>();
                        slots[j].GetComponent<Slot>().cnt++;
                        if (i == itemslot.Count)
                        {
                            return;
                        }


                        break;
                    }
                    else if (itemslot[i] != null && itemslot[i].GetComponent<Crops>() != null)
                    {
                        slots[j].GetComponent<Slot>()._crops = itemslot[i].GetComponent<Crops>();
                        slots[j].GetComponent<Slot>().cnt++;
                        if (i == itemslot.Count)
                        {
                            return;
                        }


                        break;
                    }


                }
                else
                {
                    if (slots[j].GetComponent<Slot>()._fish != null && itemslot[i].GetComponent<Fish>() != null)
                    {
                        if (slots[j].GetComponent<Slot>()._fish.fish_type == itemslot[i].GetComponent<Fish>().fish_type)
                        {
                            slots[j].GetComponent<Slot>().cnt++;

                            if (i == itemslot.Count )
                            {
                                return;
                            }


                            break;
                        }
                    }
                    if (slots[j].GetComponent<Slot>()._equ != null && itemslot[i].GetComponent<Equipment>() != null)
                    {
                        if (slots[j].GetComponent<Slot>()._equ.equipment_type == itemslot[i].GetComponent<Equipment>().equipment_type)
                        {
                            slots[j].GetComponent<Slot>().cnt++;

                            if (i == itemslot.Count)
                            {
                                return;
                            }


                            break;
                        }
                    }
                    if (slots[j].GetComponent<Slot>()._part != null && itemslot[i].GetComponent<Part>() != null)
                    {
                        if (slots[j].GetComponent<Slot>()._part.part_type == itemslot[i].GetComponent<Part>().part_type)
                        {
                            slots[j].GetComponent<Slot>().cnt++;

                            if (i == itemslot.Count )
                            {
                                return;
                            }


                            break;
                        }
                    }
                    if (slots[j].GetComponent<Slot>()._fruit != null && itemslot[i].GetComponent<Fruit>() != null)
                    {
                        if (slots[j].GetComponent<Slot>()._fruit.fluit_type == itemslot[i].GetComponent<Fruit>().fluit_type)
                        {
                            slots[j].GetComponent<Slot>().cnt++;

                            if (i == itemslot.Count )
                            {
                                return;
                            }


                            break;
                        }
                    }
                    if (slots[j].GetComponent<Slot>()._seed != null && itemslot[i].GetComponent<Seed>() != null)
                    {
                        if (slots[j].GetComponent<Slot>()._seed.seed_type == itemslot[i].GetComponent<Seed>().seed_type)
                        {
                            slots[j].GetComponent<Slot>().cnt++;

                            if (i == itemslot.Count)
                            {
                                return;
                            }


                            break;
                        }
                    }
                    if (slots[j].GetComponent<Slot>()._crops != null && itemslot[i].GetComponent<Crops>() != null)
                    {
                        if (slots[j].GetComponent<Slot>()._crops.crops_type == itemslot[i].GetComponent<Crops>().crops_type)
                        {
                            slots[j].GetComponent<Slot>().cnt++;

                            if (i == itemslot.Count)
                            {
                                return;
                            }


                            break;
                        }
                    }
                }




            }

        }


      
    }


    /// <summary>
    /// 스프라이트 이미지를 적용
    /// </summary>
    public void SetSprit()
    {
        foreach(var slot in slots)
        {
            if(slot.GetComponent<Slot>()._fish != null)
            {
                var sp_type = slot.GetComponent<Slot>()._fish.fish_type;
                if(sp_type == FishType.Big)
                {
                    slot.GetComponent<Image>().sprite = Bigfish_Image.sprite;
                }
                if (sp_type == FishType.Middle)
                {
                    slot.GetComponent<Image>().sprite = Middlefish_Image.sprite;
                }
                if (sp_type == FishType.Small)
                {
                    slot.GetComponent<Image>().sprite = Smallfish_Image.sprite;
                }

            }
            if(slot.GetComponent<Slot>()._equ != null)
            {
                var sp_type = slot.GetComponent<Slot>()._equ.equipment_type;
                if (sp_type == EquipmentType.Axe)
                {
                    slot.GetComponent<Image>().sprite = Axe_Image.sprite;
                }
                if (sp_type == EquipmentType.Bonfire)
                {
                    slot.GetComponent<Image>().sprite = Bonfire_Image.sprite;
                }
                if (sp_type == EquipmentType.Fishing)
                {
                    slot.GetComponent<Image>().sprite = Fishing_Image.sprite;
                }
                if (sp_type == EquipmentType.Bowl)
                {
                    slot.GetComponent<Image>().sprite = Bowl_Image.sprite;
                }
                if(sp_type == EquipmentType.TorchLight)
                {
                    slot.GetComponent<Image>().sprite = TorchLight_Image.sprite; 
                }
                if (sp_type == EquipmentType.Fkiller)
                {
                    slot.GetComponent<Image>().sprite = Fkiller_Image.sprite;
                }
            }
            if(slot.GetComponent<Slot>()._part != null)
            {
                var sp_type = slot.GetComponent<Slot>()._part.part_type;
                if (sp_type == PartType.FireWood)
                {
                    slot.GetComponent<Image>().sprite = Firewood_Image.sprite;
                }
                if (sp_type == PartType.Nail)
                {
                    slot.GetComponent<Image>().sprite = Nail_Image.sprite;
                }
                if (sp_type == PartType.Rope)
                {
                    slot.GetComponent<Image>().sprite = Rope_Image.sprite;
                }
                if (sp_type == PartType.Cloth)
                {
                    slot.GetComponent<Image>().sprite = Cloth_Image.sprite;
                }
                if (sp_type == PartType.Firestone)
                {
                    slot.GetComponent<Image>().sprite = Fireston_Image.sprite;
                }
                if (sp_type == PartType.Oil)
                {
                    slot.GetComponent<Image>().sprite = Oil_Image.sprite;
                }
                if (sp_type == PartType.Water)
                {
                    slot.GetComponent<Image>().sprite = Water_Image.sprite;
                }
                if(sp_type == PartType.Branch)
                {
                    slot.GetComponent<Image>().sprite = Branch_Image.sprite;
                }
                if(sp_type == PartType.Raft)
                {
                    slot.GetComponent<Image>().sprite = Raft_Image.sprite;
                }
                if (sp_type == PartType.DefaultSton)
                {
                    slot.GetComponent<Image>().sprite = Ston_Image.sprite;
                }
            }
            if (slot.GetComponent<Slot>()._fruit != null)
            {
                var sp_type = slot.GetComponent<Slot>()._fruit.fluit_type;
                if (sp_type == FuritType.Apple)
                {
                    slot.GetComponent<Image>().sprite = Apple_Image.sprite;
                }
                if (sp_type == FuritType.Banana)
                {
                    slot.GetComponent<Image>().sprite = Banana_Image.sprite;
                }
                if (sp_type == FuritType.Coconet)
                {
                    slot.GetComponent<Image>().sprite = Coconut_Image.sprite;
                }
            }
            if (slot.GetComponent<Slot>()._seed != null)
            {
                var sp_type = slot.GetComponent<Slot>()._seed.seed_type;
                if (sp_type == SeedType.CornSeed)
                {
                    slot.GetComponent<Image>().sprite = CornSeed_Image.sprite;
                }
                if (sp_type == SeedType.CucumberSeed)
                {
                    slot.GetComponent<Image>().sprite = CucumberSeed_Image.sprite;
                }
                if (sp_type == SeedType.RiceplantSeed)
                {
                    slot.GetComponent<Image>().sprite = RicePlantSeed_Image.sprite;
                }
                if (sp_type == SeedType.TomatoSeed)
                {
                    slot.GetComponent<Image>().sprite = TomatoSeed_Image.sprite;
                }
            }
            if (slot.GetComponent<Slot>()._crops != null)
            {
                var sp_type = slot.GetComponent<Slot>()._crops.crops_type;
                if (sp_type == CropsType.Corn)
                {
                    slot.GetComponent<Image>().sprite = Corn_Image.sprite;
                }
                if (sp_type == CropsType.Cucumber)
                {
                    slot.GetComponent<Image>().sprite = Cucumber_Image.sprite;
                }
                if (sp_type == CropsType.Riceplant)
                {
                    slot.GetComponent<Image>().sprite = RicePlant_Image.sprite;
                }
                if (sp_type == CropsType.Tomato)
                {
                    slot.GetComponent<Image>().sprite = Tomato_Image.sprite;
                }
            }



        }
    }
    


    public void ClickBornfireCreate()
    {
        ItemSystem.Instance.BonfireAdd();    
    }


    public void ClickTorchLightCreate()
    {
        ItemSystem.Instance.TorchLightAdd();

    }

    public void ClickRaftCreate()
    {
        var its = ItemSystem.Instance.items;

        foreach(var it in its)
        {
            if(it.GetComponent<Part>() != null && it.GetComponent<Part>().part_type == PartType.Raft)
            {
                ItemSystem.Instance.ItemInfoUI("이미 뗏목을 만들었습니다!!!", Color.yellow);
                return;

            }


        }



        ItemSystem.Instance.RaftAdd();
    }

}
