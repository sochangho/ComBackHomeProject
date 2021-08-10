using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingPointCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {          
        if(other.tag == "FishingZone")
        {
            var splash = ObjectPoolMgr.Instance.SplashPool();
            splash.transform.position = transform.position;
            Sounds.Instance.SoundPlay("FishingCollider");
            StartCoroutine(Return(splash));
        }
    }


    IEnumerator Return(GameObject obj)
    {
        yield return new WaitForSeconds(2f);

        ObjectPoolMgr.Instance.SplashReturn(obj);

    }


}
