using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashAddPopup : Popup
{

    public List<TrashItemInfo> trashItemInfos;


    private void OnEnable()
    {
        var _trashs = ItemSystem.Instance.trashs;

        foreach (var _trash in _trashs)
        {
           TrashItemInfoSet(_trash.Key, _trash.Value);
        }
    }



    private void OnDestroy()
    {
        ItemSystem.Instance.trashs.Clear();
    }


    public void TrashItemInfoSet(string itemtype , int cnt)
    {

        foreach(var transhItemInfo in trashItemInfos)
        {
            if (transhItemInfo.gameObject.activeSelf == false)
            {
                transhItemInfo.gameObject.SetActive(true);
                transhItemInfo.additem_img.sprite = Resources.Load<Sprite>("Sprite/" + itemtype) as Sprite;
                transhItemInfo.additem_cnt.text = cnt.ToString();


                break;
            }
        }                            
    } 

    public void CloseClick()
    {

        Close();

    }

}
