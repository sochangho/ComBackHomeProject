using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class BornfireStart : MonoBehaviour
{

    private float time = 0;

    [SerializeField]
    private float limit_time = 20;
    [SerializeField]
    private float delay = 0.3f;
    [SerializeField]
    private GameObject paticleobj;

    [SerializeField]
    private GameObject smoke_paticleobj;

    [SerializeField]
    private Light bonfire_light;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private GameObject gaugeui;


  
    public GameObject Fire
    {

        get
        {
            return paticleobj;
        }

    }


    public GameObject Smoke
    {
        get
        {
            return smoke_paticleobj;
        }

    }

   
    private PlayerControl _player;

    private Coroutine bornfire_coroutin;

    private bool fireTrigger = true;

    public FireState bonfire_state = FireState.Firing;

    private void Start()
    {
        _player = FindObjectOfType<PlayerControl>();
        bornfire_coroutin = StartCoroutine(BornfireCorutin());
        var cu =CreateUi();
        if (cu != null)
        {
            StartCoroutine(BornfireRoutinGauge(cu));
        }

       

    }



    public void BonfireEnd()
    {


        GetComponent<NavMeshObstacle>().enabled = false;
        StopCoroutine(bornfire_coroutin);
        fireTrigger = false;
    }

    IEnumerator BornfireCorutin()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.3f);
        paticleobj.GetComponent<ParticleSystem>().Play();
        while (true)//(time < limit_time)
        {
         
            time += Time.deltaTime;


            if(Vector3.Distance(paticleobj.transform.position, _player.transform.position) < 3f)
            {

               if(_player.player_hp < 100)
                {
                    _player.player_hp += 0.1f;

                }
                else
                {
                    _player.player_hp = 100;

                }

            }

            yield return waitForSeconds;

        }

        //paticleobj.SetActive(false);
        //fireTrigger = false;
        //StopCoroutine(bornfire_coroutin);
    }

    private void OnTriggerEnter(Collider other)
    {
        
       if(other.tag == "Zombi" && fireTrigger == true)
        {

           
            other.GetComponentInParent<Enemy>().State = EnemyState.Gohome;
            other.GetComponentInParent<Enemy>().searchTrigger = false;
        }
 
             
    }

    private void OnTriggerExit(Collider other)
    {
        
        if(other.tag == "Zombi" && fireTrigger == true)
        {
            
            other.GetComponentInParent<Enemy>().searchTrigger = true;


        }


    }

    IEnumerator BornfireRoutinGauge(GameObject ui)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        while(ui.GetComponent<Image>().fillAmount > 0f)
        {

            ui.GetComponent<Image>().fillAmount -= 0.01f;

            yield return waitForSeconds;

        }

        paticleobj.SetActive(false);
        bonfire_state = FireState.End;
        smoke_paticleobj.SetActive(true);        
        BonfireEnd();
        Destroy(ui);

    }

    private GameObject CreateUi()
    {
        if(bonfire_state == FireState.End)
        {
            return null;
        }


        var ui = Instantiate(gaugeui);
        ui.transform.SetParent(canvas.transform);
        ui.transform.localPosition = new Vector3(0, 0, 0);
        ui.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0.63f);


        return ui;
    }


    


}
