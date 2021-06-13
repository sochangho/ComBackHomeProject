using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishingstart : MonoBehaviour
{


    public GameObject linepoint1;

    public GameObject linepoint2;

    public Transform startpoint1;

    public Transform startpoint2;

    public Transform endpoint1;

    public Transform endpoint2;



    private void FishGo()
    {
        linepoint1.transform.position = new Vector3(startpoint1.position.x, startpoint1.position.y, startpoint1.position.z);
        linepoint2.transform.position = new Vector3(startpoint2.position.x, startpoint2.position.y, startpoint2.position.z);

        StartCoroutine(FishingGoRoutin());
     

    }

    private void FishBack()
    {
        linepoint1.transform.position = new Vector3(endpoint1.position.x, endpoint1.position.y, endpoint1.position.z);
        linepoint2.transform.position = new Vector3(endpoint2.position.x, endpoint2.position.y, endpoint2.position.z);

        StartCoroutine(FishingBackRoutin());
    }


   


    IEnumerator FishingGoRoutin()
    {




        while (Vector3.Distance(linepoint1.transform.position, endpoint1.position) > 0.1 || Vector3.Distance(linepoint2.transform.position, endpoint2.position) > 0.1)
        {

            if (Vector3.Distance(linepoint1.transform.position, endpoint1.position) > 0.1)
            {
                linepoint1.transform.position = Vector3.MoveTowards(linepoint1.transform.position, endpoint1.position, 20 * Time.deltaTime);
            }

            if (Vector3.Distance(linepoint1.transform.position, endpoint2.position) > 0.1)
            {
                linepoint2.transform.position = Vector3.MoveTowards(linepoint2.transform.position, endpoint2.position, 20 * Time.deltaTime);
            }


            yield return null;

        }


    }
    IEnumerator FishingBackRoutin()
    {




        while (Vector3.Distance(linepoint1.transform.position, startpoint1.position) > 0.1 || Vector3.Distance(linepoint2.transform.position, startpoint2.position) > 0.1)
        {

            if (Vector3.Distance(linepoint1.transform.position, startpoint1.position) > 0.1)
            {
                linepoint1.transform.position = Vector3.MoveTowards(linepoint1.transform.position, startpoint1.position, 20 * Time.deltaTime);
            }

            if (Vector3.Distance(linepoint2.transform.position, startpoint2.position) > 0.1)
            {
                linepoint2.transform.position = Vector3.MoveTowards(linepoint2.transform.position, startpoint2.position, 20 * Time.deltaTime);
            }


            yield return null;

        }

    


    }


}
