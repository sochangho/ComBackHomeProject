using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipState : MonoBehaviour
{
    private bool state_trigger = false;    
    private Coroutine lightningroutin;




    public CamaraShake camaraShake;
    public List<MeshRenderer> renderers;
    public List<ParticleSystem> particles;
    public  Material[] materials_default;
    public  Material[] materials_lightning;



    private void Start()
    {
        ChangeDefault();
    }





    public void ChangeStart()
    {

        camaraShake.CamaraShakeStart();
        lightningroutin = StartCoroutine(LightningState());
        //if (!state_trigger)
        //{
        //    lightningroutin = StartCoroutine(LightningState());

        //}
        //else
        //{
        //    StopCoroutine(lightningroutin);

        //    lightningroutin = StartCoroutine(LightningState());

        //}


    }

    public void ShipExplosion()
    {
        foreach(var particle in particles)
        {
            if (particle.gameObject.activeSelf == false)
            {
                particle.gameObject.SetActive(true);
              
            }


            particle.Play();

        }

    }



    IEnumerator LightningState()
    {
        //if (!state_trigger)
        //{

        //    state_trigger = true;
        //}


        float time = 0;
        ChangeLightning();

        while (time < 0.5f)
        {

            time += Time.deltaTime;

            yield return null;
        }

        ChangeDefault();

        //if (state_trigger)
        //{

        //    state_trigger = false;

        //}

    }

    private void ChangeDefault()
    {
        foreach(var renderer in renderers)
        {

            renderer.materials = materials_default;

        }

    }

    private void ChangeLightning()
    {

        foreach (var renderer in renderers)
        {

            renderer.materials = materials_lightning;

        }

    }


    

}
