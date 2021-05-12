using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class DaySystem : MonoBehaviour
{


    [SerializeField]
    private List<Transform> enemy_transformSpawns;

    [SerializeField]
    private float daytime = 300f;

    [SerializeField]
    private float raintime = 200f;

    [SerializeField]
    private GameObject rain_obj;

    private bool day_Seatrigger_night = false;

    private bool day_Seatrigger_morning = false;

    private bool day_enemytrigger = false;

    public bool day_trigger = false;

    private DayType dayType;


    public DayType Day_Type
    {

        get
        {
            return dayType;
        }
        set
        {
            dayType = value;
        }
    }


    private Weather weatherType = Weather.Idle;

    [SerializeField]
    private Light daylight;

    [SerializeField]
    private Terrain terrain;

    private PlayerControl player;

    private Coroutine dayroutin;

    private Coroutine rainroutin;

    private float temp_hp;

    private float temp_hungry;

    private float temp_force;


    private static DaySystem _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static DaySystem Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(DaySystem)) as DaySystem;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);

    }

  

    private void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        daylight.intensity = 2;
        dayType = DayType.Morning;
        dayroutin = StartCoroutine(DayRoutin());
        rainroutin = StartCoroutine(RainRoutin());

        player.player_hp = 100;
        player.player_hungry = 100;
        player.player_force = 100;

        player.transform.position = FindObjectOfType<PlayerPoint>().PlayerStartPoint();
        player.target = FindObjectOfType<PlayerPoint>().PlayerStartPoint();
    }


    public void StopDaySystem()
    {

        ObjectPoolMgr.Instance.objpool[2].Reset();
        StopCoroutine(dayroutin);
        StopCoroutine(rainroutin);


       temp_hp = player.player_hp;
       temp_hungry = player.player_hungry;
       temp_force =  player.player_force;
        
        daylight.gameObject.SetActive(false);
       terrain.gameObject.SetActive(false);
    }

    public void RestartDaySystem()
    {
        if(player == null)
        {

            player = FindObjectOfType<PlayerControl>();
        }


        dayroutin = StartCoroutine(DayRoutin());
        rainroutin = StartCoroutine(RainRoutin());
        daylight.gameObject.SetActive(true);
        terrain.gameObject.SetActive(true);

        player.player_hp = temp_hp;
        player.player_hungry = temp_hungry;
        player.player_force = temp_force;


        player.transform.position = FindObjectOfType<PlayerPoint>().PlayerRestartPoint();
        player.target = FindObjectOfType<PlayerPoint>().PlayerRestartPoint();

    }

 


    private void RainActive(bool state)
    {
        if(rain_obj != null && rain_obj.activeSelf != state)
        {
            rain_obj.SetActive(state);

        }

    }

    private void RainFollowPlayer()
    {

        rain_obj.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4f, player.transform.position.z);

    }


    private void TorchLightAndBonfireEnd()
    {
        var items = FindObjectsOfType<Items>();

        foreach(var item in items)
        {
            if(item.ItemType() == new Equipment(EquipmentType.Bonfire).ItemType() 
                && item.GetComponent<BornfireStart>() != null && item.GetComponent<BornfireStart>().bonfire_state == FireState.Firing)
            {
                var bonfire = item.GetComponent<BornfireStart>();


                bonfire.Fire.SetActive(false);
                bonfire.bonfire_state = FireState.End;
                bonfire.Smoke.SetActive(true);
                bonfire.BonfireEnd();
            }

            if(item.ItemType() == new Equipment(EquipmentType.TorchLight).ItemType()
                && item.GetComponent<TorchLlightStart>() != null && item.GetComponent<TorchLlightStart>().torchfire_state == FireState.Firing)
            {
                var torchlight = item.GetComponent<TorchLlightStart>();

                torchlight.Fire.SetActive(false);
                torchlight.torchfire_state = FireState.End;
                torchlight.TorchLightEnd();
            }
        }
    }

    




    private void EnemyNight()
    {
        var enemy = ObjectPoolMgr.Instance.objpool[2].gameObject;
        int enemy_cnt = 0;

        for (int i = 0; i < enemy.transform.childCount; i++)
        {
            if (enemy.transform.GetChild(i).gameObject.activeSelf == true)
            {
                enemy_cnt++;
            }

        }

        if (enemy_cnt < 10)
        {
            int random = Random.Range(0, enemy_transformSpawns.Count - 1);
            var enemyobj = ObjectPoolMgr.Instance.EnemyPool();

            
           
            enemyobj.transform.position = enemy_transformSpawns[random].position;

            enemyobj.GetComponent<NavMeshAgent>().enabled = true;            


        }


    }

    private void EnemyMorning()
    {
        if (day_enemytrigger == false)
        {
            day_enemytrigger = true;
            var enemy = ObjectPoolMgr.Instance.objpool[2].gameObject;


            for (int i = 0; i < enemy.transform.childCount; i++)
            {
                if (enemy.transform.GetChild(i).gameObject.activeSelf == true)
                {
                    enemy.transform.GetChild(i).gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    ObjectPoolMgr.Instance.EnemyReturn(enemy.transform.GetChild(i).gameObject);
                }

            }

        }

    }



    private void SeaNightPanel()
    {

     
        if (FindObjectOfType<SeaGoChoice>() && day_Seatrigger_night == false)
        {

            var clickTrash = FindObjectOfType<SeaGoChoice>().transform.GetChild(2).GetComponent<Button>().onClick;
            var clickFish  = FindObjectOfType<SeaGoChoice>().transform.GetChild(3).GetComponent<Button>().onClick;

            day_Seatrigger_night = true;
            clickTrash.RemoveAllListeners();
            clickTrash.AddListener(SeaPanelInfo);

            clickFish.RemoveAllListeners();
            clickFish.AddListener(SeaPanelInfo);

            
        }


        if(!FindObjectOfType<SeaGoChoice>() && day_Seatrigger_night == true)
        {

            day_Seatrigger_night = false;
        }


    }


    private void SeaMorningPanel()
    {
        if(FindObjectOfType<SeaGoChoice>() && day_Seatrigger_morning == false)
        {


            var clickTrash = FindObjectOfType<SeaGoChoice>().transform.GetChild(2).GetComponent<Button>().onClick;
            var clickFish = FindObjectOfType<SeaGoChoice>().transform.GetChild(3).GetComponent<Button>().onClick;


            day_Seatrigger_morning = true;
           if(clickTrash.GetPersistentMethodName(0) == "SeaPanelInfo")
            {
                clickTrash.RemoveAllListeners();
                clickTrash.AddListener(FindObjectOfType<SeaGoChoice>().GoTrash);
            }


            if (clickFish.GetPersistentMethodName(0) == "SeaPanelInfo")
            {
                clickFish.RemoveAllListeners();
                clickFish.AddListener(FindObjectOfType<SeaGoChoice>().GoFish);
            }

        }


        if (!FindObjectOfType<SeaGoChoice>() && day_Seatrigger_morning == true)
        {

            day_Seatrigger_morning = false;
        }



    }


    private void SeaPanelInfo()
    {
        ItemSystem.Instance.ItemInfoUI("바다에 들어갈 수 없습니다.", Color.yellow);

    }



    IEnumerator DayRoutin()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.4f);


        while (true)
        {

            if (dayType == DayType.Morning)
            {

               // daytime -= Time.deltaTime;

               // SeaMorningPanel();
                EnemyMorning();
                if (daytime <= 0)
                {

                    daytime = 300f;
                    dayType = DayType.NightGo;

                }

                yield return null;
            }
            else if (dayType == DayType.MorningGo)
            {

                daylight.intensity += 0.05f;

                if (daylight.intensity >= 2)
                {

                    dayType = DayType.Morning;

                }

                yield return waitForSeconds;


            }
            else if (dayType == DayType.Night)
            {
                if (day_enemytrigger)
                {

                    day_enemytrigger = false;
                }

               // daytime -= Time.deltaTime;
               // SeaNightPanel();
                EnemyNight();
                if (daytime <= 0)
                {

                    daytime = 300f;
                    dayType = DayType.MorningGo;

                }

                yield return null;
            }
            else if (dayType == DayType.NightGo)
            {

                daylight.intensity -= 0.05f;

                if (daylight.intensity <= 1)
                {

                    dayType = DayType.Night;

                }

                yield return waitForSeconds;
            }


        }


    }

    IEnumerator RainRoutin()
    {

       

        while (true)
        {
          if(weatherType == Weather.Idle)
          {
                raintime -= Time.deltaTime;
               
                if (raintime < 0)
                {
                    weatherType = Weather.Rain;
                    raintime = 50f;
                }
          }   
          else if(weatherType == Weather.Rain)
          {
                raintime -= Time.deltaTime;
                TorchLightAndBonfireEnd();
                RainActive(true);
                RainFollowPlayer();
                if (raintime < 0)
                {
                    ObjectPoolMgr.Instance.objpool[6].Reset();
                    weatherType = Weather.Idle;
                    RainActive(false);
                    raintime = 200f;
                }


          }

            yield return null;
        }
    }

}


public enum Weather
{
    Idle,
    Rain

}