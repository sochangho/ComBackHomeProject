using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oldhouse : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            FindObjectOfType<Camera>().nearClipPlane = 7f;
            var daySystem = DaySystem.Instance;

            if(daySystem.Day_Type != DayType.Night)
            {

                daySystem.Day_Type = DayType.NightGo;

            }



        }




    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            FindObjectOfType<Camera>().nearClipPlane = 1f;
            var daySystem = DaySystem.Instance;

            if (daySystem.Day_Type != DayType.Morning)
            {

                daySystem.Day_Type = DayType.MorningGo;

            }


       
        }




    }




}
