using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class TomatoGrow : MonoBehaviour
{

    [SerializeField]
    private Texture2D crop_tex;

    [SerializeField]
    private Texture2D temp_tex;

    [SerializeField]
    private List<Renderer> crops_renderer;

    [SerializeField]
    private Renderer stem_renderer;

    [SerializeField]
    private float wait = 0.1f;

    [SerializeField]
    private float temp = 0.03f;

    [SerializeField]
    private float crop_wait = 0.1f;

    [SerializeField]
    private float crop_temp = 0.08f;

    [SerializeField]
    private GameObject paticle;

    [SerializeField]
    private GameObject camera_pos ;

    private GameObject maincamera;

    private GameObject croppanel;

    private Material stempSet;

    private PlayerControl player_;

    private GrowState growstate;

    public bool waterTrigger = false;
   
    
    void Start()
    {

        stem_renderer.material.SetTexture("_MainTex", temp_tex);

        foreach(var crop in crops_renderer)
        {

            crop.material.SetTexture("_MainTex", crop_tex);
        }


        stempSet = stem_renderer.material;
        croppanel = GameObject.Find("Canvas").transform.Find("cropstart").gameObject;
        maincamera = GameObject.Find("MainCamera");
        player_ = FindObjectOfType<PlayerControl>();
        camera_pos.SetActive(false);
        
    }


  

    public void Grow()
   {
        croppanel.SetActive(false);

        camera_pos.SetActive(true);
        maincamera.SetActive(false);

        int cnt = player_.usingitem.GetComponent<BowlWater>().GetWater();
        cnt--;
        player_.usingitem.GetComponent<BowlWater>().SetWater(cnt);


        if (growstate == GrowState.Step1)
        {

           StartCoroutine(StemStep(0.7f));

        }
        else if (growstate == GrowState.Step2)
        {

            StartCoroutine(StemStep(1f));

        }
       else if (growstate == GrowState.Step3)
       {
            


                StartCoroutine(CropStep());
               
      
        }

      
    }


    IEnumerator StemStep(float st)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(wait);

        while(stempSet.GetFloat("_StemGrow") < st)
        {

            stempSet.SetFloat("_StemGrow", stempSet.GetFloat("_StemGrow") + temp);
            camera_pos.transform.localPosition = new Vector3(0, stempSet.GetFloat("_StemGrow")*0.6f + 0.3f, -0.94f);


            if(stempSet.GetFloat("_StemGrow") > st)
            {

                stempSet.SetFloat("_StemGrow", st);
            }


            yield return waitForSeconds;
        }

        
        if (stempSet.GetFloat("_StemGrow") == 0.7f)
        {
            growstate = GrowState.Step2;
        }
        else if (stempSet.GetFloat("_StemGrow")  == 1f)
        {
            growstate = GrowState.Step3;
        }

        camera_pos.SetActive(false);
        maincamera.SetActive(true);
        croppanel.SetActive(true);

    }


    IEnumerator CropStep()
    {
       
        WaitForSeconds waitForSeconds = new WaitForSeconds(crop_wait);
        
        float grow_value = -0.35f;

        while(grow_value < 1f )
        {
            grow_value += crop_temp;

            foreach(var crop in crops_renderer)
            {
                crop.material.SetFloat("_CropGrow", grow_value);
               
            }

            yield return waitForSeconds;
        }


        if(grow_value > 1f)
        {

            growstate = GrowState.Complete;
        }


        foreach (var crop in crops_renderer)
        {

            crop.gameObject.AddComponent<Crops>().crops_type = CropsType.Tomato;
           
        }




        camera_pos.SetActive(false);
        maincamera.SetActive(true);

    }


    IEnumerator WarterGo()
    {
        player_.usingitem.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        float time = 0;
        while(time < 1f)
        {

            time += Time.deltaTime;

            yield return null;

        }


        Grow();


    }

    
    public void GrowStart()
    {


        StartCoroutine(WarterGo());

    }




   public void NoGrow()
    {

        ItemSystem.Instance.ItemInfoUI("물 부족...", Color.red);
    }


    private void OnTriggerEnter(Collider other)
    {
        
        
        if(other.tag == "Player" && croppanel.activeSelf == false && growstate != GrowState.Complete 
            && player_.usingitem.GetComponent<Items>().ItemType() == "Bowl" ) // 물 필요
        {
            int cnt = player_.usingitem.GetComponent<BowlWater>().GetWater();

            croppanel.SetActive(true);
            croppanel.transform.GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
            if (cnt > 0)
            {
                croppanel.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(GrowStart);
                
            }
            else
            {
                croppanel.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(NoGrow);
            }
            
            
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && croppanel.activeSelf == true)
        {

            croppanel.SetActive(false);
        }
    }


}
