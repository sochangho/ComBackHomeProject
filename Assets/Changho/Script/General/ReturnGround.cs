﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGround : BaseScene
{
    

    // Start is called before the first frame update
    void Start()
    {
        var itemsystem = ItemSystem.Instance;


        if(itemsystem.trashAddPopup == true)
        {
            OpenPopup<TrashAddPopup>("UI/Popup/TrashAddPopup");            
            itemsystem.TrashAdd();
            itemsystem.trashAddPopup = false;

        }
    }

   
}
