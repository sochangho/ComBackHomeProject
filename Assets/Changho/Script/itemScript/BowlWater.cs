using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlWater:MonoBehaviour
{
    int warter_cnt = 0; 
    

    public void SetWater(int cnt)
    {

        warter_cnt = cnt;
    }

    public int GetWater()
    {
        return warter_cnt;

    }



}
