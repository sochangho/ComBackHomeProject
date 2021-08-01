using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingTutorial : Tutorials
{
    int fish;

    public FishingTutorial()
    {

        name = "낚시하기";
        suscript = "배를 타고 나가기전 식량을 확보하기 위해서 낚시를 해서 물고기를 획득합니다." + "\r\n"
            + "조건 - 물고기 3개";

    }


    public override TutorialState CompleteConditon()
    {
        base.CompleteConditon();

        var crops = FindObjectsOfType<TomatoGrow>();

        int complete_cnt = 0;


        foreach (var item in ItemSystem.Instance.items)
        {
            if(item.GetComponent<Fish>()!= null)
            {
                complete_cnt++;

            }

        }

        fish = complete_cnt;
        if (fish >= 2)
        {

            tutorialState = TutorialState.Complete;

        }

        return tutorialState;
    }



    public override void TutorialSet()
    {
        base.TutorialSet();
        tutorialState = TutorialState.Go;
        name = "낚시하기";
        suscript = "배를 타고 나가기전 식량을 확보하기 위해서 낚시를 해서 물고기를 획득합니다." + "\r\n"
            + "조건 - 물고기 3개";
        PlayerPrefs.SetString("name", name);
        PlayerPrefs.SetString("subs", suscript);
    }

    public override string SetCondition()
    {
        return "물고기 : " + fish.ToString();
    }

}
