using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerMotionState
{
    
    Walk,
    TorchWalk,
    Lifting
    

}


public class PlayerAnimaterMgr : MonoBehaviour
{

    public Animator player_animator;

    public PlayerMotionState playerMotion;


    public void WalkAnimation(bool state  )
    {

        if (state == true)
        {

            if (playerMotion == PlayerMotionState.Walk || playerMotion == PlayerMotionState.Lifting)
            {

                if (player_animator.GetBool("TorchWalk") == state)
                {
                    player_animator.SetBool("TorchWalk", !state);
                }

                if (player_animator.GetBool("Walk") != state)
                {
                    player_animator.SetBool("Walk", state);
                }

            }
            else if (playerMotion == PlayerMotionState.TorchWalk)
            {

                if (player_animator.GetBool("Walk") == state)
                {
                    player_animator.SetBool("Walk", !state);
                }


                if (player_animator.GetBool("TorchWalk") != state)
                {
                    player_animator.SetBool("TorchWalk", state);
                }

            }
        }
        else
        {
            if (player_animator.GetBool("Walk") != state)
            {
                player_animator.SetBool("Walk", state);
            }
            if (player_animator.GetBool("TorchWalk") != state)
            {
                player_animator.SetBool("TorchWalk", state);
            }

        }

    }
    
    
    public void LiftingAnimation(bool state)
    {


       

        if (player_animator.GetBool("Lifting") != state)
        {
            player_animator.SetBool("Lifting", state);
        }

    }


    public void WieldAnimation(bool state)
    {

        if (player_animator.GetBool("Wield") != state)
        {
            player_animator.SetBool("Wield", state);
           
        }

    }


    public void WateringAnimation(bool state)
    {

        if (player_animator.GetBool("Watering") != state)
        {
            player_animator.SetBool("Watering", state);
        }

    }

    public void FishingStartAnimation(bool state)
    {
        StartCoroutine(FishingStatAnimantionRoutin(state));
    

    }


    public void ThrowAnimation(bool state)
    {

        if(player_animator.GetBool("Throw") != state)
        {
            player_animator.SetBool("Throw", state);
        }
    }

    
    public void SprayAnimation(bool state)
    {


        if (player_animator.GetBool("Spray") != state)
        {
            player_animator.SetBool("Spray", state);
        }

    }

    public void RunAnimation(bool state)
    {

        if(player_animator.GetBool("Run") != state)
        {
            player_animator.SetBool("Run", state);
        }
    }

    public void PickupAnimation(bool state)
    {


        if(player_animator.GetBool("Pickup") != state)
        {
            player_animator.SetBool("Pickup", state);
        }


    }


   public void FishingCastAnimation(bool state)
    {

        if(player_animator.GetBool("FishingCast") != state)
        {
            player_animator.SetBool("FishingCast", state);

        }

    }



    public bool RunState()
    {
        return (player_animator.GetBool("Run") && player_animator.GetBool("Walk"));
    }

    public bool WalkState()
    {

        return (player_animator.GetBool("Walk") || player_animator.GetBool("TorchWalk")) && !player_animator.GetBool("Run") ;
    }

    public bool WieldState()
    {

        return player_animator.GetBool("Wield");
    }

    IEnumerator FishingStatAnimantionRoutin(bool state)
    {
        float time = 0;
        bool use = false;
        if (player_animator.GetBool("Fishing") != state)
        {
            player_animator.SetBool("Fishing", state);
        }


        while (time < 3f)
        {
            time += Time.deltaTime;

            if(time > 2f && !use && state)
            {
                use = true;
                Sounds.Instance.SoundPlay("FishingThrow");
            }


            yield return null;
        }

        if (player_animator.GetBool("FishingIdle") != state)
        {
            player_animator.SetBool("FishingIdle", state);
        }

    }



}
