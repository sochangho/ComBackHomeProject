using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TrashSystem : MonoBehaviour
{

    private int nail_cnt = 0;
    private int rope_cnt = 0;
    private int watercan_cnt = 0;
    private int fkiller_cnt = 0;
    private int randombox_cnt = 0;


    public float shipHp = 100;


    [SerializeField]
    private TextMeshProUGUI nailTex;

    [SerializeField]
    private TextMeshProUGUI ropeTex;

    [SerializeField]
    private TextMeshProUGUI warterTex;
    
    [SerializeField]
    private TextMeshProUGUI fkillerTex;

    [SerializeField]
    private TextMeshProUGUI randomboxTex;


    [SerializeField]
    private List<CreateTrash> createTrashes;


    public void IncreaseCount(GameObject trash)
    {

        if(trash.GetComponent<Items>() != null)
        {
            var trash_type = trash.GetComponent<Items>();

            if(trash_type.ItemType() == "Nail")
            {
                nail_cnt++;

                nailTex.text = nail_cnt.ToString();
                nailTex.transform.GetComponentInParent<Animator>().SetTrigger("textTrigger");
            }
            if (trash_type.ItemType() == "Rope")
            {
                rope_cnt++;

                ropeTex.text = rope_cnt.ToString();
                ropeTex.transform.GetComponentInParent<Animator>().SetTrigger("textTrigger");
            }
            if (trash_type.ItemType() == "Bowl")
            {
                watercan_cnt++;

                warterTex.text = watercan_cnt.ToString();
                warterTex.transform.GetComponentInParent<Animator>().SetTrigger("textTrigger");
            }
            if (trash_type.ItemType() == "Fkiller")
            {
                fkiller_cnt++;
                fkillerTex.text = fkiller_cnt.ToString();
                fkillerTex.transform.GetComponentInParent<Animator>().SetTrigger("textTrigger");
            }
            if (trash_type.ItemType() == "RandomBox")
            {
                randombox_cnt++;
                randomboxTex.text = randombox_cnt.ToString();
                randomboxTex.transform.GetComponentInParent<Animator>().SetTrigger("textTrigger");
            }

        }

    }

    public void ItemZero()
    {
         nail_cnt = 0;
         rope_cnt = 0;
         watercan_cnt = 0;
         fkiller_cnt = 0;
         randombox_cnt = 0;


        nailTex.text = nail_cnt.ToString();
        ropeTex.text = rope_cnt.ToString();
        warterTex.text = watercan_cnt.ToString();
        fkillerTex.text = fkiller_cnt.ToString();
        randomboxTex.text = randombox_cnt.ToString();
        nailTex.transform.GetComponentInParent<Animator>().SetTrigger("textTrigger");
        ropeTex.transform.GetComponentInParent<Animator>().SetTrigger("textTrigger");
        warterTex.transform.GetComponentInParent<Animator>().SetTrigger("textTrigger");
        fkillerTex.transform.GetComponentInParent<Animator>().SetTrigger("textTrigger");
        randomboxTex.transform.GetComponentInParent<Animator>().SetTrigger("textTrigger");
    } 


    public void WeatherChange(bool weather_bool)
    {

        foreach(var createtrash in createTrashes)
        {
            createtrash.ChangeList(weather_bool);
        }



        if (weather_bool)
        {

            StartCoroutine(WeatherRoutin());
        }
    
    }




    IEnumerator WeatherRoutin()
    {
        float time = 0;

        while(time < 30f)
        {

            time += Time.deltaTime;

            yield return null;

        }


        WeatherChange(false);

    }

}
