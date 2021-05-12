using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGround : BaseScene
{
    

    // Start is called before the first frame update
    void Start()
    {
        var itemsystem = ItemSystem.Instance;
        var daysystem = DaySystem.Instance;
        var tutorialsystem = TutorialSystem.Instance;

        if(itemsystem.trashAddPopup == true)
        {
            OpenPopup<TrashAddPopup>("UI/Popup/TrashAddPopup");            
            itemsystem.TrashAdd();
            itemsystem.trashAddPopup = false;

        }

        if(daysystem.day_trigger == true)
        {
            daysystem.RestartDaySystem();
            daysystem.day_trigger = false;
            
        }

        var ar =  Instantiate(Resources.Load<GameObject>("Ganeral/ArrowObj"));
        tutorialsystem.arrow = ar.GetComponent<Arrow>();
        
    }

   
}
