using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestroy : MonoBehaviour
{
    [SerializeField]
    private List<Slice> shipslices;


    public void ShipSlice()
    {
        foreach (var slice in shipslices)
        {

            
            slice.Slicer(slice.gameObject, slice.GetComponent<Renderer>().material,transform.position, slice.idx = 0, "Destroy");

        }
        //collision.collider.gameObject.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;


    }




}
