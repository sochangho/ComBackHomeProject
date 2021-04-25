using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ThrowStones : MonoBehaviour
{
  

    public Transform shootPoint;

    
    public Transform shootPoint2;

    [SerializeField]
    private float throwTime;

    private bool throwTrigger = false;

    private bool shotTrigger = false;
    public void Shot()
    {
        bool stoncheck = false;

        foreach(var item in ItemSystem.Instance.items)
        {

            if(item.ItemType() == new Part(PartType.DefaultSton).ItemType())
            {
                if (throwTrigger == false)
                {
                    FindObjectOfType<PlayerAnimaterMgr>().ThrowAnimation(true);
                    ItemSystem.Instance.ItemUseRemove(item);
                    throwTrigger = true;
                    stoncheck = true;
                    StartCoroutine(ThrowRoutin());
                    break;
                }

            }

        }



        if (!stoncheck)
        {
            ItemSystem.Instance.ItemInfoUI("인벤토리 창에 돌이 없습니다.", Color.red);

        }



    }



    private void Throw()
    {
        Debug.Log("Throw");
       
        
     
        var ston = ObjectPoolMgr.Instance.StonPool();
        ston.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ston.transform.position = shootPoint.position;
        ston.transform.rotation = FindObjectOfType<PlayerControl>().transform.rotation;
        
       

    }


    IEnumerator ThrowRoutin()
    {
        float time = 0;
        
        while (time < 2.23f)
        {
            time += Time.deltaTime;


            if(time > 1.04f  && shotTrigger == false)
            {

                Throw();

                shotTrigger = true;


            }


            yield return null;
        }



        FindObjectOfType<PlayerAnimaterMgr>().ThrowAnimation(false);

        if (throwTrigger == true)
        {
            throwTrigger = false;
        }


        if(shotTrigger == true)
        {

            shotTrigger = false;
        }

    }
   


}
