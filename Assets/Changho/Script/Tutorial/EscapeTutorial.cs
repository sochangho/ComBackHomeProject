﻿using UnityEngine;

public class EscapeTutorial : Tutorials
{

   public int rope = 0;
   public int cloth = 0;
   public int nail = 0;
   public int wood = 0;


    public int totalrope = 3;

    public int totalcloth = 3;

    public int totalnail = 6;

    public int totalwood = 20;

    public EscapeTutorial()
    {

        name = "탈출하기";
        suscript = "탈출하기 위한 배를 만들기 위해 부품을 모아주세요." + "\r\n"
            + "조건 - 밧줄 3개 천 3개 못 6개 나무 20개";

    }



    public override void TutorialSet()
    {
        base.TutorialSet();
        tutorialState = TutorialState.Go;
        name = "탈출하기";
        suscript = "탈출하기 위한 배를 만들기 위해 부품을 모아주세요." + "\r\n" 
            +"조건 - 밧줄 3개 천 3개 못 6개 나무 20개";

        PlayerPrefs.SetString("name", name);
        PlayerPrefs.SetString("subs", suscript);
        
    }


    public override TutorialState CompleteConditon()
    {
       

        var rope_str = new Part(PartType.Rope).ItemType();
        var cloth_str = new Part(PartType.Cloth).ItemType();
        var nail_str = new Part(PartType.Nail).ItemType();
        var wood_str = new Part(PartType.FireWood).ItemType();
        int rope_cnt = 0;
        int cloth_cnt = 0;
        int nail_cnt = 0;
        int wood_cnt = 0;



        foreach(var item in ItemManager.Instance.itemList)
        {
            if(item.ItemType() == rope_str)
            {
                rope_cnt++;
            }
            else if (item.ItemType() == cloth_str)
            {
                cloth_cnt++;
            }
            else if (item.ItemType() == wood_str)
            {
                wood_cnt++;
            }
            else if (item.ItemType() == nail_str)
            {
                nail_cnt++;
            }



        }

        rope = rope_cnt;
        cloth = cloth_cnt;
        wood = wood_cnt;
        nail = nail_cnt;

        if(rope >= totalrope && cloth >= totalcloth && nail >= totalnail && wood >= totalwood)
        {

            tutorialState = TutorialState.Complete;

        }

        return tutorialState;

    }

    public override string SetCondition()
    {
        return  "밧줄: " + rope.ToString() + "/천 : " + cloth.ToString() + "/장작 : " + wood.ToString() +"/못 : " + nail; 




    }



}
