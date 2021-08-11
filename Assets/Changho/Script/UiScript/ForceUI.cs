using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceUI : MonoBehaviour
{
    [SerializeField]
    private Image fill_image;

    private PlayerControl player;
    
    private void Start()
    {

        player = FindObjectOfType<PlayerControl>();

        StartCoroutine(ForceBarRoutin());

    }
   

    public void DecreaseForceBar()
    {
        player.player_force -= 3;

        fill_image.fillAmount = player.player_force / 100;

        if(player.player_force <= 0)
        {
            player.player_force = 0;
            ItemSystem.Instance.ItemInfoUI("더 이상 나무를 벨 수 없습니다.", Color.red);

            if (player.usingitem.GetComponent<AxeStart>().use_go_trigger == true)
            {
                player.usingitem.GetComponent<AxeStart>().use_go_trigger = false;
            }

            
        }



    }

    IEnumerator ForceBarRoutin()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(3f);


        while (true)
        {

            if (player.player_force < 100)
            {
                


                if (player.usingitem != null && player.usingitem.GetComponent<AxeStart>() != null && 
                    player.usingitem.GetComponent<AxeStart>().use_go_trigger == false)
                {
                    player.usingitem.GetComponent<AxeStart>().use_go_trigger = true;
                }


                player.player_force += 1;
                fill_image.fillAmount = player.player_force / 100;
            }
          

            if(player.player_force > 100)
            {

                player.player_force = 100;
            }


            yield return waitForSeconds;
        }




    }





}
