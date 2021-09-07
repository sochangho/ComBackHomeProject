using UnityEngine;

public class GrowTutorial : Tutorials
{
   public int crop = 0;



    public GrowTutorial()
    {

        name = "농작물 키우기";
        suscript = "HP를 채우기 위해서 농작물을 키우세요" + "\r\n"
            + "조건 - 농작물 1개";

    }


    public override TutorialState CompleteConditon()
    {
        base.CompleteConditon();

        var crops = FindObjectsOfType<TomatoGrow>();

        int complete_cnt = 0;


        foreach(var crop in crops)
        {

            if(crop.Growstate == GrowState.Complete)
            {
                complete_cnt++;
            }

           
        }

        crop = complete_cnt;
        if(crop >= 1)
        {

            tutorialState = TutorialState.Complete;

        }

        return tutorialState;
    }



    public override void TutorialSet()
    {
        base.TutorialSet();
        tutorialState = TutorialState.Go;
        name = "농작물 키우기";
        suscript = "HP를 채우기 위해서 농작물을 키우세요" + "\r\n" 
            + "조건 - 농작물 1개";
        PlayerPrefs.SetString("name", name);
        PlayerPrefs.SetString("subs", suscript);
    }

    public override string SetCondition()
    {
        return "농작물 : " + crop.ToString();
    }






}
