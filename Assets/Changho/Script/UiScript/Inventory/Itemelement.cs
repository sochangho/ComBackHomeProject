using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Itemelement : MonoBehaviour
{
    public TextMeshProUGUI cnt_text;
    public Image img;   
    private string useitemname = null;


    public void SetItemelement(Items item , int cnt)
    {

        useitemname = item.ItemType();
        img.sprite = Resources.Load<Sprite>("Sprite/" + item.ItemType()) as Sprite;
        img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);
        cnt_text.text = cnt.ToString();


    }
   
   public string GetItemelement()
   {

        return useitemname;

   }


    public void SlotUse()
    {
        int cnt_veiw = 0;

        if (useitemname != null)
        {
            var items = ItemSystem.Instance.items;


            foreach(var item in items)
            {
                if(item.ItemType() == useitemname)
                {

                    item.ItemUse();
                    break;
                }

            }

            foreach(var item in items)
            {
                if(item.ItemType() == useitemname)
                {

                    cnt_veiw++;

                }

            }
            if (cnt_veiw == 0)
            {
                cnt_text.text = "";
                img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
                useitemname = null;
                img.sprite = null;

            }
            else
            {
                cnt_text.text = cnt_veiw.ToString();
            }


        }
      
    }

    public void ElementCntUpdate(int cnt)
    {

        cnt_text.text = cnt.ToString();


    }

}
