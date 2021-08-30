using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropSeed : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<PlayerControl>() != null)
        {
            ItemManager.Instance.seedtry = true;

        }


    }


    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<PlayerControl>() != null)
        {
            ItemManager.Instance.seedtry = false;

        }


    }

}
