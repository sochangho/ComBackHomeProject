using UnityEngine;
public class SeedTutorial : Tutorials
{


    public int seed = 0;
    public bool oldhouse_ok = false;


    public SeedTutorial()
    {
        name = "폐가에서 씨앗줍기";
        suscript = "HP가 많이 떨어져있습니다. " +
            "농작물을 키워서 농작물을 먹어서 HP를 회복해야합니다. " +
            "폐가로 가서 씨앗을 주우세요." +
            "몬스터가 나올 때 스프레이와 횃불을 만들어서 퇴치하세요. " + "\r\n" +
            "조건 - 씨앗 2개";


    }
    public override void TutorialSet()
    {
        base.TutorialSet();
        tutorialState = TutorialState.Go;
        name = "폐가에서 씨앗줍기";
        suscript = "HP가 많이 떨어져있습니다. " +
            "농작물을 키워서 농작물을 먹어서 HP를 회복해야합니다. " +
            "폐가로 가서 씨앗을 주우세요." +
            "몬스터가 나올 때 스프레이와 횃불을 만들어서 퇴치하세요. " + "\r\n" +
            "그리고 폐가에서 빠져 나와 주세요" + "\r\n" +
            "조건 - 씨앗 2개";

        PlayerPrefs.SetString("name", name);
        PlayerPrefs.SetString("subs", suscript);

    }


    public override TutorialState CompleteConditon()
    {
        base.CompleteConditon();


        int seed_cnt = 0;

        foreach (var item in ItemSystem.Instance.items)
        {
           
            if(item.GetComponent<Seed>() != null)
            {
                seed_cnt++;
            }


        }

        seed = seed_cnt;
        if(seed >= 2 && DaySystem.Instance.Day_Type.Equals(DayType.MorningGo))
        {

            tutorialState = TutorialState.Complete;
        }

        return tutorialState;
    }

    public override string SetCondition()
    {
        return "씨앗 : " + seed.ToString();  
    }




}
