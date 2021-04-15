using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TorchLlightStart : MonoBehaviour
{

    private Transform player_transform;
   
    private bool use_triger = false;

    public float Th_limit = 0.5f;
   
    private void Start()
    {
        player_transform = GetComponentInParent<Transform>();
        
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Zombi" && use_triger == true)
        {
          
            var enemy = other.GetComponentInParent<Enemy>();
           

            enemy.LifeRoutinStop();

        }

    }


    public void Wield()
    {
        if(use_triger == false)
        {
            use_triger= true;
            StartCoroutine(WieldRoutin());
        }
    }


    IEnumerator WieldRoutin()
    {
        float time = 0;

        while(time < Th_limit)
        {

            time += Time.deltaTime;


            yield return null;
        }

        if (use_triger == true)
        {
            use_triger = false ;
        }


    }



}
