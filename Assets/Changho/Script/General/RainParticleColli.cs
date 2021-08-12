using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainParticleColli : MonoBehaviour
{

    private ParticleSystem particle;
    List<ParticleCollisionEvent> particleCollisionEvents = new List<ParticleCollisionEvent>();

    private void Start()
    {


        particle = GetComponent<ParticleSystem>();
    }


    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = particle.GetCollisionEvents(other, particleCollisionEvents);


        for(int i = 0; i< numCollisionEvents; i++)
        {

          var ripple =   ObjectPoolMgr.Instance.RippleParticlePool();
            ripple.transform.position = particleCollisionEvents[i].intersection;
            StartCoroutine(RippleRoutin(ripple));
        }

   
    }

    IEnumerator RippleRoutin(GameObject ripple)
    {
        float time = 0;

        while(time < 0.1f)
        {

            time += Time.deltaTime;

            yield return null;
        }

        ObjectPoolMgr.Instance.RippleParticleReturn(ripple.gameObject);

    }






}
