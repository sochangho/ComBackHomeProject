using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DaySystem : MonoBehaviour
{

    public float daytime = 600f;
    public TextMeshProUGUI dayText;

    private Light light;
    private DayType daytype;
    private int days = 1;

    private float fade_value = 1f;
    private float fade_outvalue = 0.05f;



    private void Awake()
    {
        light = FindObjectOfType<Light>();
        daytype = DayType.Morning;
    }

    private void Start()
    {
        
        if(days == 1f)
        {


        }


    }

    private void OnEnable()
    {
        


    }



    IEnumerator DayRoutin()
    {
        float time = 0;
        while (true)
        {
            if(time < daytime)
            {
                time += Time.deltaTime;


            }
            else
            {
                if(daytype == DayType.Morning)
                {
                    daytype = DayType.Night;
                    
                }
                else if(daytype == DayType.Night)
                {

                    daytype = DayType.Morning;
                    StartCoroutine(DayTextFade());

                }

                time = 0;

            }

            yield return null; 
        }


    }


    IEnumerator DayTextFade()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        if(fade_value != 1f)
        {

            fade_value = 1f;

        }


        while(fade_value > 0.0f)
        {
            fade_value -= fade_outvalue;

            dayText.color = new Color(dayText.color.r, dayText.color.g, dayText.color.g, fade_value);

            yield return waitForSeconds;
        }
       
    }




    //IEnumerator LightningRoutin()
    //{

    //    while(dayType == DayType.Night)
    //    {
    //        time += Time.deltaTime;

    //        if(time > 12)
    //        {   
    //            var lightning_pos = _player.transform.position + Random.insideUnitSphere * 5;
    //            lightning.transform.position = new Vector3(lightning_pos.x, _player.transform.position.y + 14f , lightning_pos.z);
    //            lightning.LightningCollider();
    //            time = 0;

    //        }

    //        yield return null;

    //    }

    //}

}
