﻿
using System.Collections;
using UnityEngine;

public class TreeSliceTutorial : Tutorials
{
   

    public int fruit;
     
    public TreeSliceTutorial()
    {
        name = "나무 베기 아이템 얻기";
        suscript = "무인도에 떨어지고 허기짐이 많이 떨어진 상태입니다. 나무를 베어서 과일을 획득하고 허기짐을 채우기 위해서 과일3개를 획득하세요" + "\r\n"
            + "조건 - 과일 3개";

    }

    public override void TutorialSet()
    {
        base.TutorialSet();

        tutorialState = TutorialState.Go;
        name = "나무 베기 아이템 얻기";
        suscript = "무인도에 떨어지고 허기짐이 많이 떨어진 상태입니다. 나무를 베어서 과일을 획득하고 허기짐을 채우기 위해서 과일3개를 획득하세요" + "\r\n" 
            + "조건 - 과일 3개";


        
     

        PlayerPrefs.SetString("name", name);
        PlayerPrefs.SetString("subs", suscript);
    }


    public override TutorialState CompleteConditon()
    {
       
        int fruite_cnt = 0;

        foreach(var item in ItemSystem.Instance.items)
        {
            if (item.GetComponent<Fruit>())
            {
                fruite_cnt++;

            }

        }


        fruit = fruite_cnt;

        if(fruit >= 3)
        {
            tutorialState = TutorialState.Complete;

        }

        return tutorialState;
    }

    public override string SetCondition()
    {
        return "획득한 과일 : " + fruit.ToString();
    }

   

}
