using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrashItemInfo : MonoBehaviour
{
    public TextMeshProUGUI additem_cnt;
    public Image additem_img;
    public Button additem_button;

     private void Start()
    {
        if (additem_img.sprite.name != "RandomBox")
        {
            additem_button.gameObject.SetActive(false);
        }
        else
        {
            additem_button.gameObject.SetActive(true);

        }


    }







}
