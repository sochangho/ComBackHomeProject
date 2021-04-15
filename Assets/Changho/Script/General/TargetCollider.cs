using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{
    [SerializeField]
    private List<Slice> slices;

    public List<Slice> Slice
    {
        get
        {
            return slices;
        }
        set
        {
            slices = value;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Lightning")
        {

            TreeSlice(collision.contacts[0].point);
        }

        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void TreeSlice(Vector3 point)
    {
       
            foreach (var slice in slices)
            {

                slice.Slicer(slice.gameObject, slice.GetComponent<Renderer>().material, point, slice.idx = 0 ,"Destroy");

            }



            //collision.collider.gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        


    }

    


}
