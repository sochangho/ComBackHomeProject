﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquUI : MonoBehaviour
{ 

    [SerializeField]
    public Image None_Image;

    [SerializeField]
    private GameObject equ_Image;


    [SerializeField]
    public GameObject equbutton;

    public void ImageChange(EquipmentType eqtype)
    {
        Debug.Log(eqtype.ToString());
        var ei = equ_Image.GetComponent<Image>().sprite;

        if(eqtype == EquipmentType.Axe)
        {
            equ_Image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/Axe") as Sprite;
        }
        if(eqtype == EquipmentType.Bowl)
        {
            equ_Image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/WaterCan") as Sprite;
        }
        if(eqtype == EquipmentType.Fishing)
        {
            equ_Image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/Fishing") as Sprite;
        }
        if(eqtype == EquipmentType.TorchLight)
        {
            
            equ_Image.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/TorchLight") as Sprite;

        }


        
    }

    public void ImageNone()
    {
        
        if (equ_Image != None_Image)
        {
            equ_Image.GetComponent<Image>().sprite = None_Image.sprite;
        }

        PlayerControl.Instance.PlayerEquStateChange();
        equbutton.SetActive(false);
    }

    public void OpenEquCancel()
    {
        if (equbutton.activeSelf == false && PlayerControl.Instance.player_equState == PlayerEquState.Equ) {
            Debug.Log("wewewe");
            equbutton.SetActive(true);
        }
        else if(equbutton.activeSelf == true)
        {
            equbutton.SetActive(false);
            
        }

    }




}
