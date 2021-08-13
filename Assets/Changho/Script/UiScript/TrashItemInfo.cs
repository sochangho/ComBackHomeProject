using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrashItemInfo : MonoBehaviour
{
    public TextMeshProUGUI additem_cnt;
    public Image additem_img;
    public TextMeshProUGUI additem_name;
    

    public void OpenBox()
    {
        List<string> trashitemnames = new List<string>();
        var itemsystem = ItemSystem.Instance;

        int ran = Random.Range(0, 10);

        trashitemnames.Add("Nail");
        trashitemnames.Add("Fkiller");
        trashitemnames.Add("Bowl");
        trashitemnames.Add("Rope");


        if (ran == 0)
        {
            int item_rancnt = Random.Range(0, trashitemnames.Count);
            var item_ranstr = trashitemnames[item_rancnt];
            int update_cnt = 0;
            foreach (var item in itemsystem.prefebitems)
            {
                if (item.ItemType() == item_ranstr)
                {
                    itemsystem.ItemCreate(item);
                    itemsystem.ItemInfoUI(item.GetItemName() + "을 획득했습니다!!!", Color.blue);

                    
                    foreach(var invitem in ItemManager.Instance.itemList)
                    {
                        if(invitem.ItemType() == item.ItemType())
                        {
                            update_cnt++;

                        }

                    }

                    additem_cnt.text = update_cnt.ToString();
                
                    break;
                }

            }

            

        }
        else
        {

            itemsystem.ItemInfoUI("빈 상자 입니다..", Color.yellow);



        }


        foreach(var trash in itemsystem.trashs.Keys)
        {
            if(trash == "RandomBox")
            {

                itemsystem.trashs[trash]--;
                var box_cnt = itemsystem.trashs[trash];

                if(box_cnt == 0)
                {


                    gameObject.SetActive(false);


                }


            }



        }







        

    }





}
