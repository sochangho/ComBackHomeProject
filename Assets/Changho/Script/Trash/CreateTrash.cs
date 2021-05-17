using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameVanilla.Core;


public class CreateTrash : MonoBehaviour
{

    private List<ObjectPool> obj_list;
  
    public List<ObjectPool> itempool_list;

    public List<ObjectPool> lightning_itempoolList;




    private void Awake()
    {
        obj_list = itempool_list;
    }


    private void Start()
    {
      
        StartCoroutine(Create());
    }

    public void ChangeList(bool lit_trigger)
    {
        if (lit_trigger)
        {

            obj_list = lightning_itempoolList;
        }
        else
        {

            obj_list = itempool_list;
        }

    }


    private int Probaility()
    {
        int ran = Random.Range(0, 10);

        if (ran >= 0 && ran < 8)
        {

            return obj_list.Count-1;

        }
        else
        {
            int numran = Random.Range(0, obj_list.Count - 1);

            return numran;

        }

    }



    IEnumerator Create()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);


        while(true)
        {

           

            var go = obj_list[Probaility()].GetObject();
            go.transform.localPosition = new Vector3(0, 0, 0);

            yield return wait;
        }




    }







}
