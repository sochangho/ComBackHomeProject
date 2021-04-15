﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{

    private Rigidbody rigidbody;


    private void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(StonRoutin());       
    }


    private void OnCollisionEnter(Collision collision)
    {


        ObjectPoolMgr.Instance.StonReturn(this.gameObject);

    }


    IEnumerator StonRoutin()
    {
        float time = 0;

      
        while (time < 2f)
        {
            time += Time.deltaTime;
            rigidbody.AddForce(PlayerControl.Instance.transform.forward * 10f );
            yield return null;
        }
       
        ObjectPoolMgr.Instance.StonReturn(this.gameObject);
    }

}
