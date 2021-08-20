using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{

    private UIButton ui;


    private void Awake()
    {


        ui = GetComponent<UIButton>();
    }


    private void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Player")
        {
            

                ui.GoChoice();
     
        }
      
    }

    private void OnTriggerExit(Collider other)
    {
        
        if(other.tag == "Player")
        {

            if (FindObjectOfType<SeaGoChoice>() != null)
            {

                FindObjectOfType<SeaGoChoice>().OnCloseChoice();
            }
        }



    }

}
