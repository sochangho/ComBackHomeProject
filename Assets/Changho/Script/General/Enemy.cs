using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    private float sightLevel = 0.4f;
    [SerializeField] 
    private float sightLength = 10f;
    [SerializeField]
    private float attackrange = 1f;
    [SerializeField]
    private float attackRate = 0.5f;
    [SerializeField] 
    private LayerMask layerToCast;

    [SerializeField]
    private Transform start_point;

    [SerializeField]
    private Transform start_home;

    [SerializeField]
    private GameObject particleDie_obj;

    [SerializeField]
    private GameObject searchImage;

    [SerializeField]
    private ParticleSystem fly;

    private NavMeshAgent _agent;

    private PlayerControl _player;

    private Coroutine lifeCoroutin;

    private EnemyState _state;


    [HideInInspector]
    public Vector3 dir_back;


    public EnemyBar enemyBar;

    public float enemy_HP = 100;

    public bool enemydie_trigger = false;

  

    public EnemyState State
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;
        }

    }


    public bool searchTrigger = false;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<PlayerControl>();
        

    }

    private void OnEnable()
    {
        if(enemy_HP != 100)
        {
            enemy_HP = 100;
        } 

        LifeRoutinStart();
        FlyColorSet();
    }


    private void FlyColorSet()
    {
        int random = Random.Range(0, 3);


        if(random == 0)
        {

            fly.startColor = Color.red;
        }
        else if(random == 1)
        {
            fly.startColor = Color.yellow;
        }
        else if (random == 2)
        {
            fly.startColor = Color.blue;
        }


       

    }


    public void PlayerSet()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<PlayerControl>();
        }
    }

    public void LifeRoutinStart()
    {
        _state = EnemyState.Idle;
      lifeCoroutin = StartCoroutine(LifeRoutin());
    }
     

    public void LifeRoutinStop()
    {
        StopCoroutine(lifeCoroutin);
        StartCoroutine(BackRoutin());
    }


    IEnumerator LifeRoutin()
    {
        Debug.Log("ddd");
        while (_state != EnemyState.Dead)
        {


            enemyBar.enemy_hpimage.fillAmount = enemy_HP / 100;

            if (_state == EnemyState.Idle)
            {
                _state = EnemyState.Search;
            }
            else if (_state == EnemyState.Search)
            {


                PlayerSearch();


            }
            else if (_state == EnemyState.Chase)
            {
                _agent.isStopped = false;

                if ((_player.transform.position - start_point.position).magnitude < attackrange)
                {
                    Debug.Log("공격");

                    _state = EnemyState.Attack;
                }
                else
                {


                   
                    _agent.SetDestination(_player.transform.position);

                }


                if (Vector3.Distance(_player.transform.position, start_point.position) > sightLength)
                {
                    Debug.Log("멈춰");
                    _state = EnemyState.Idle;
                  
                }

            
            }
            else if (_state == EnemyState.Attack)
            {

                _agent.isStopped = true;


                _state = EnemyState.Chase;
            }
            else if(_state == EnemyState.Gohome)
            {

                if (Vector3.Distance(transform.position, start_home.position) > 0.1f)
                {
                    _agent.SetDestination(start_home.position);
                }


                PlayerSearch();
                

            }
      

            if(enemy_HP <= 0 && enemydie_trigger == false)
            {

                enemydie_trigger = true;
                enemy_HP = 0;
                StartCoroutine(ParticleDieroutin());
                _state = EnemyState.Dead;               
                
               
            }

       
        

            yield return null;
        }

    }
    





    private void PlayerSearch()
    {
       if(_player == null)
        {


            _player = FindObjectOfType<PlayerControl>();
        }
    

        var distancePlayer = Vector3.Distance(_player.transform.position, start_point.position);

       
        if (distancePlayer < sightLength)
        {
           
               _state = EnemyState.Chase;

        }


    }



    IEnumerator BackRoutin()
    {
        float time = 0;

  

        var dir = _player.transform.position - transform.position;
        var dirXZ = new Vector3(dir.x, 0f, dir.z);

        transform.rotation = Quaternion.LookRotation(dirXZ);


        while (time < 0.3f)
        {
            time += Time.deltaTime;

            transform.Translate(Vector3.back * Time.deltaTime * 5);


            yield return null;
        }

        LifeRoutinStart();

        _state = EnemyState.Idle;

    }


    IEnumerator ParticleDieroutin()
    {
        
        var pardie = ObjectPoolMgr.Instance.DieParticlePool();
        pardie.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        float time = 0;
        while (time < 1f)
        {


            time += Time.deltaTime;


            yield return null;
        }

        ObjectPoolMgr.Instance.DieParticlePoolReturn(pardie);

        GetComponent<NavMeshAgent>().enabled = false;
        ObjectPoolMgr.Instance.EnemyReturn(gameObject);

        //gameObject.SetActive(false);

    }

}
