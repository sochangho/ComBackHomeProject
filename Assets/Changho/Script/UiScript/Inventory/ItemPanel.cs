using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemPanel : Slot
{
    [SerializeField]
    public TextMeshProUGUI nametex;

    [SerializeField]
    public TextMeshProUGUI subscripttex;

    [SerializeField]
    private GameObject use_button;

    [SerializeField]
    private GameObject cancel_button;

    public Image itemimage;


    public void Start()
    {
        if(_part != null)
        {
            use_button.SetActive(false);
        }
    }


    public void UseButtonclick()
    {
        var itemslot = GameObject.Find("ItemSlot").GetComponent<ItemSlot>();

        if(itemslot.slot_items.Count == 4)
        {
            return;
            
        }


        if (_fish != null)
        {

            FindKey(_fish, itemslot);
          
        }
        else if (_equ != null)
        {

            if (_equ.equipment_type == EquipmentType.Axe || _equ.equipment_type == EquipmentType.Bowl
                || _equ.equipment_type == EquipmentType.Fishing || _equ.equipment_type == EquipmentType.TorchLight)
            {
                PlayerControl.Instance.PlayerEqu(_equ.equipment_type);
               
            }
            else
            {

                FindKey(_equ, itemslot);
            }
        }
        else if (_fruit != null)
        {
            FindKey(_fruit, itemslot);
        }
        else if(_seed != null)
        {
            FindKey(_seed, itemslot);

        }
        else if (_crops != null)
        {
            FindKey(_crops, itemslot);

        }


    }


    public void CancelButton()
    {

        if (gameObject.activeSelf == true)
        {
           var inventory  = gameObject.GetComponentInParent<Inventory>();

           foreach(var inS in inventory.slots)
            {
                if(inS.GetComponent<Button>().interactable == false)
                {
                    inS.GetComponent<Button>().interactable = true;
                }


            }


            if (_fish != null)
            {
                _fish = null;
            }
            else if (_equ != null)
            {
                _equ = null;
            }
            else if (_fruit != null)
            {
                _fruit = null;
            }
            else if (_part != null)
            {
                _part = null;
            }
            else if (_seed != null)
            {
                _seed = null;
            }
            else if (_seed != null)
            {
                _seed = null;
            }


            gameObject.SetActive(false);
        }
    }



    private void FindKey<T>(T type , ItemSlot its) where T: Items
    {
        bool eg = false ;

        foreach (var i in its.slot_items)
        {
           
            if (i.Key.ItemType() == type.ItemType())
            {

                eg = true;
                break;
               
            }
          
        }

        if (eg == false)
        {
            its.slot_items.Add(type, new ItemInfo(cnt , itemimage));
            its.SetItemWindow();
         
        }
        else
        {
            var find_information = GameObject.Find("Information");

            find_information.GetComponent<UIinfo>()._infotext = "이미 사용중인 아이템 입니다.";
            find_information.GetComponent<UIFade>().FadeStart();
          
        }


    }
}
