using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlWater:MonoBehaviour
{
    int warter_cnt = 20; 
    

    public void SetWater(int cnt)
    {
        
        warter_cnt = cnt;
    }

    public int GetWater()
    {
        return warter_cnt;

    }

    public void WateringAnimation()
    {

        StartCoroutine(WateringRoutin());
    }



    IEnumerator WateringRoutin()
    {
        float time = 0;
        var player = FindObjectOfType<PlayerControl>();
        FindObjectOfType<PlayerAnimaterMgr>().WateringAnimation(true);
      
        while (time < 5.17f)
        {
            time += Time.deltaTime;
            yield return null;

        }
        FindObjectOfType<PlayerAnimaterMgr>().WateringAnimation(false);
    }



}
