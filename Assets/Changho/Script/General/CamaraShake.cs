using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraShake : MonoBehaviour
{

    Vector3 originPos;

    public float _amount;
    public float _duration;

 


    public void CamaraShakeStart()
    {
        StartCoroutine(Shake());
    }
     IEnumerator Shake()
    {
        originPos = transform.localPosition;
        float timer = 0;
        while (timer <= _duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originPos;

    }


}
