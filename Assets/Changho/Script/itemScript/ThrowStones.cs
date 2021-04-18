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
    public void Shot(GameObject item)
    {

        if (throwTrigger == false)
        {
            ItemSystem.Instance.ItemUseRemove(item.GetComponent<Items>());
            throwTrigger = true;
            StartCoroutine(ThrowRoutin());
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


    private Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        var dst = target - origin;
        var dstXZ = dst;
        dstXZ.y = 0f;

        float Sy = dst.y;
        float Sxz = dstXZ.magnitude;


        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;


        Vector3 result = dstXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;

    }

    IEnumerator ThrowRoutin()
    {
        float time = 0; 

        while (time < 4.2f)
        {
            time += Time.deltaTime;


            if(time > 2.1f  && shotTrigger == false)
            {

                Throw();

                shotTrigger = true;


            }


            yield return null;
        }



        FindObjectOfType<PlayerControl>().player_animator.SetBool("Throw", false);

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
