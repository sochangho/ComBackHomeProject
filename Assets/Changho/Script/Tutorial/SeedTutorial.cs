
public class SeedTutorial : Tutorials
{
  public  int cliiseed = 0;
  public  int cornseed = 0;
  public  int tomatoseed = 0;
  public  int eggplantseed = 0;



    public override void TutorialSet()
    {
        base.TutorialSet();
        tutorialState = TutorialState.Go;
        name = "폐가에서 씨앗줍기";
        suscript = "HP가 많이 떨어져있습니다. " +
            "농작물을 키워서 농작물을 먹어서 HP를 회복해야합니다. " +
            "폐가로 가서 씨앗을 주우세요." +
            "몬스터가 나올 때 스프레이와 횃불을 만들어서 퇴치하세요";
        
    }


    public override TutorialState CompleteConditon()
    {
        base.CompleteConditon();

        var chill_str = new Seed(SeedType.ChilliSeed).ItemType();
        var corn_str = new Seed(SeedType.ChilliSeed).ItemType();
        var tomato_str = new Seed(SeedType.TomatoSeed).ItemType();
        var eggplant_str = new Seed(SeedType.EggplantSeed).ItemType();

        int cil_cnt = 0;
        int corn_cnt = 0;
        int tomato_cnt = 0;
        int egg_cnt = 0;

        foreach (var item in ItemSystem.Instance.items)
        {
            if(item.GetComponent<Items>().ItemType() == chill_str)
            {

                cil_cnt++;
            }

            if (item.GetComponent<Items>().ItemType() == corn_str)
            {

                corn_cnt++;
            }
            if (item.GetComponent<Items>().ItemType() == tomato_str)
            {

                tomato_cnt++;
            }
            if (item.GetComponent<Items>().ItemType() == eggplant_str)
            {

                egg_cnt++;
            }

        }


        cliiseed = cil_cnt;
        cornseed = corn_cnt;
        tomatoseed = tomato_cnt;
        eggplantseed = egg_cnt;

        if(cliiseed >= 3 && cornseed >= 3 && tomatoseed >= 3 && eggplantseed >= 3)
        {

            tutorialState = TutorialState.Complete;
        }

        return tutorialState;
    }

    public override string SetCondition()
    {
        return "목표 -  오이고추씨앗 : " + cliiseed.ToString() + "/옥수수씨앗 : " + cornseed.ToString() + "/토마토씨앗 : " + tomatoseed.ToString() + "/가지 씨앗 : " + eggplantseed;  
    }




}
