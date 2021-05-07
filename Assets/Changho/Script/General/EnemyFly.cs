using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : MonoBehaviour
{
    private PlayerControl player;
    private CamaraShake camaraShake;




    private void OnEnable()
    {

        player = FindObjectOfType<PlayerControl>();
        camaraShake = FindObjectOfType<CamaraShake>();
    }



    private void OnParticleCollision(GameObject other)
    {
        
        if(other.tag == "Player")
        {
            camaraShake.CamaraShakeStart();
            player.player_hp -= 0.1f;
           
        }
   

    }


    



}
