using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TorchLlightStart : MonoBehaviour
{

    private Transform player_transform;
   
    private bool use_triger = false;

    private bool collider_triger = false;

    private bool fire_endTrigger = false;

    public float Th_limit = 2f;

    [SerializeField]
    private GameObject fire_particle;

    public GameObject Fire
    {
        get
        {
           return fire_particle;
        }
    }

    public FireState torchfire_state = FireState.Firing;



    private void Start()
    {
        player_transform = GetComponentInParent<Transform>();
        
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Zombi" && collider_triger == true)
        {          
            var enemy = other.GetComponentInParent<Enemy>();          
            enemy.LifeRoutinStop();
           
        }

    }

    private void PlayerRadiusEnemyCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(FindObjectOfType<PlayerControl>().transform.position, 3f);


        foreach(var collider in colliders)
        {
            if(collider.gameObject.tag == "Zombi")
            {

                var enemy = collider.gameObject.GetComponentInParent<Enemy>();
                enemy.LifeRoutinStop();
                enemy.enemy_HP -= 10f;
                enemy.enemyBar.EnemyHP(enemy.enemy_HP);
            } 
        }


    }

    public void TorchLightEnd()
    {
        fire_endTrigger = true;

    }


     public void Wield()
    {
        if (fire_endTrigger)
        {
            ItemSystem.Instance.ItemInfoUI("횃불을 사용할 수 없습니다.", Color.red);
            return;
            
        }
        

        if (!use_triger)
        {
            StartCoroutine(WieldRoutin());
            use_triger = true;
        }
    }


    IEnumerator WieldRoutin()
    {
        float time = 0;
        bool torchlight_trigger = false;
        FindObjectOfType<PlayerAnimaterMgr>().WieldAnimation(true);
        

        while (time < Th_limit)
        {

            time += Time.deltaTime;



            if ((time > 0.3f) && torchlight_trigger == false)
            {
                PlayerRadiusEnemyCheck();
                torchlight_trigger = true;
            }

            yield return null;
        }

        if (use_triger)
        {
            use_triger = false;
        }

        FindObjectOfType<PlayerAnimaterMgr>().WieldAnimation(false);
       // StartCoroutine(ColliderRoutin());

    }


    IEnumerator ColliderRoutin()
    {
        float time = 0;

        if(collider_triger == false)
        {

            collider_triger = true;
        }


        while (time < 0.3f)
        {
            time += Time.deltaTime;
            yield return null;

        }

        if (collider_triger == true)
        {

            collider_triger = false;
        }



    }



}
