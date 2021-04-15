using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeStart : MonoBehaviour
{

    public float limit_time;
    private bool use_trigger = false;
    
    public void AxeWield()
    {

        if (use_trigger == false)
        {
            use_trigger = true;
            StartCoroutine(AxeRoutin());

        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if( use_trigger&& other.tag == "Tree")
        {

            var slices =  other.GetComponent<TargetCollider>().Slice;
            var trees = other.GetComponent<Trees>();
            var slices_last = slices[slices.Count - 1];

            slices_last.limit_idx = 1;
            slices_last.Slicer(slices_last.gameObject, slices_last.GetComponent<Renderer>().material, Vector3.down, slices_last.idx = 1,"Slice");
            


            foreach(var slice in slices)
            {
                if(slice.gameObject.tag == "Leaf")
                {

                    slice.transform.parent = slices_last.Object_property.transform;

                }


            }

            slices_last.Object_property.AddComponent<Rigidbody>().useGravity = true;
            
            
            foreach(var fruit in trees.Fruits)
            {

                if(trees.Tree_type == TreeType.AppleTree)
                {
                    fruit.AddComponent<Fruit>().fluit_type = FuritType.Apple;
                    ItemSystem.Instance.items.Add(fruit);
                    fruit.SetActive(false);

                }
                if (trees.Tree_type == TreeType.BananaTree)
                {
                    fruit.AddComponent<Fruit>().fluit_type = FuritType.Banana;
                    ItemSystem.Instance.items.Add(fruit);
                    fruit.SetActive(false);
                }
                if (trees.Tree_type == TreeType.CoconutTree)
                {
                    fruit.AddComponent<Fruit>().fluit_type = FuritType.Coconet;
                    ItemSystem.Instance.items.Add(fruit);
                    fruit.SetActive(false);
                }

            }
            
        }
           
    }


    

    /// <summary>
    ///  무기 사용 대기시간
    /// </summary>
    /// <returns></returns>

    IEnumerator AxeRoutin()
    {
        float time = 0;

        while(time < limit_time)
        {
            time += Time.deltaTime;
            yield return null;
        }


        if(use_trigger == true)
        {
            use_trigger = false;
        }

    }


}
