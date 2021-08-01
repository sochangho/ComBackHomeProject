using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingItemmove : MonoBehaviour
{
    private Vector3 destination;

 
    public void Itemmove(Vector3 destination)
    {
        this.destination = destination;

        StartCoroutine(moveRoutin());


    }

    IEnumerator moveRoutin()
    {

        while(Vector3.Distance(transform.position , destination) > 0.1f)
        {

            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime);

            yield return null;

        }

        Destroy(this.gameObject);
    }



}
