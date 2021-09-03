using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeZoneTr : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private GameObject lakeFog;


    private void Awake()
    {
        arrow.SetActive(false);
        lakeFog.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerControl>() != null)
        {
            arrow.SetActive(true);
            lakeFog.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerControl>() != null)
        {
            arrow.SetActive(false);
            lakeFog.SetActive(false);
        }
    }

}
