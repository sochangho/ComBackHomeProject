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
    private List<TextMeshProUGUI> clock;

    [SerializeField]
    private List<CreateTrash> createTrashes;

    [SerializeField]
    private GameObject rain;
    [SerializeField]
    private GameObject sea;

    [SerializeField]
    private UIButton popupSystem;
    
    private Renderer seaColor;

    private Color lightning_color;

    private Color defaul_color;

    private void Awake()
    {
        seaColor = sea.GetComponent<Renderer>();
    }
    private void Start()
    {

        defaul_color = seaColor.material.GetColor("DeepWaterColor");
        lightning_color = new Color(0, 0, 0);
        StartCoroutine(TrashGameRoutin());

    }


   
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
           

        }

    }


    public void RandomBoxCount()
    {

        randombox_cnt++;
        randomboxTex.text = randombox_cnt.ToString();
        randomboxTex.transform.GetComponentInParent<Animator>().SetTrigger("textTrigger");

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

        rain.SetActive(weather_bool);
        SeaColorChange(weather_bool);

        foreach (var createtrash in createTrashes)
        {
            createtrash.ChangeList(weather_bool);
        }

        if (weather_bool)
        {

            StartCoroutine(WeatherRoutin());
        }
    
    }


    private void SeaColorChange(bool change)
    {

        if (change)
        {
            seaColor.material.SetColor("DeepWaterColor", lightning_color);
        }
        else
        {
            seaColor.material.SetColor("DeepWaterColor", defaul_color);

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

    IEnumerator TrashGameRoutin()
    {

        float time = 180;




        while(shipHp > 0 && time > 0)
        {
            time -= Time.deltaTime;

            clock[0].text = (((int)time / 60) % 60).ToString();
            clock[1].text = ((int)time % 60).ToString();

            if(time <= 0)
            {

                time = 0;
            }

            yield return null;
        }

        if(shipHp<= 0)
        {
            shipHp = 0;

            FindObjectOfType<ShipDestroy>().ShipSlice();
            FindObjectOfType<MoveShip>().enabled = false;
            StartCoroutine(TrashEndPopupRoutin());


        }


     
    }

    IEnumerator TrashEndPopupRoutin()
    {
        float time = 0;

        while (time < 0.5f)
        {
            time += Time.deltaTime;

            yield return null;
        }

        popupSystem.TrashSceneEnd();
    }
    

}
