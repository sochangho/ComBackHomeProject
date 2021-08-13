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
            if (TutorialSystem.Instance.tutorial_index == 4)
            {

                ui.GoChoice();
            }
            else
            {

                ItemSystem.Instance.ItemInfoUI("입장 불가 ...!", Color.red);

            }
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
