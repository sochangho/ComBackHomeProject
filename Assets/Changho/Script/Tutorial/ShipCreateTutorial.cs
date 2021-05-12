using UnityEngine;

public class ShipCreateTutorial : Tutorials
{


    public ShipCreateTutorial()
    {
        name = "뗏목 만들기";
        suscript = "인벤토리 창에서 뗏목을 만들어주세요. " +
            "그리고 뗏목을 타고 무인도 탈출하기 위한 배를 만들기 위해 바다에 나가 부품을 수집을 해주세요." + "\r\n"
            + "조건 - 뗏목 만들기";

    }


    public override void TutorialSet()
    {
        base.TutorialSet();
        tutorialState = TutorialState.Go;
        name = "뗏목 만들기";
        suscript = "인벤토리 창에서 뗏목을 만들어주세요. " +
            "그리고 뗏목을 타고 무인도 탈출하기 위한 배를 만들기 위해 바다에 나가 부품을 수집을 해주세요."+"\r\n"
            +"조건 - 뗏목 만들기";
        PlayerPrefs.SetString("name", name);
        PlayerPrefs.SetString("subs", suscript);

    }


    public override TutorialState CompleteConditon()
    {
        base.CompleteConditon();

        var raft = new Part(PartType.Raft).ItemType();

        foreach(var item in ItemSystem.Instance.items)
        {
            if(item.ItemType() == raft)
            {
                tutorialState = TutorialState.Complete;
                break;
            }
        }

        return tutorialState;
    }


    public override string SetCondition()
    {
        return base.SetCondition();
    }
}
