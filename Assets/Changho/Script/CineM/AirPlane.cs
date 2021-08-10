using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlane : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {

        source = GetComponent<AudioSource>();
        source.Play();

    }


    private void Update()
    {
        
        if(source.volume > 0)
        {
            source.volume -= 0.01f;

        }

    }



}