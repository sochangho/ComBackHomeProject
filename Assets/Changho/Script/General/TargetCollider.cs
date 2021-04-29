using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{

    private Slice slice;

    public List<GameObject> leafs;

    public void TreeSlice(Vector3 point)
    {


             for(int i = 0; i < transform.childCount; i++)
             {

                   if(transform.GetChild(i).tag == "Stem")
                   {

                slice = transform.GetChild(i).GetComponent<Slice>();
                slice.limit_idx = 0;

                if (gameObject.GetComponent<Trees>().Tree_type == TreeType.AppleTree)
                {
                                                          
                    slice.Slicer(slice.gameObject, slice.GetComponent<Renderer>().material,point , slice.idx = 0, "Apple");
                }
                else
                {

                    slice.Slicer(slice.gameObject, slice.GetComponent<Renderer>().material, point, slice.idx = 0, "");
                }
                gameObject.GetComponent<BoxCollider>().enabled = false;

                break;

                   }   

             }

           
        
    }

    


}
