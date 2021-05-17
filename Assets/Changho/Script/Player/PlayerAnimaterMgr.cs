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

    public void FishingAnimation(bool state)
    {

        if (player_animator.GetBool("Fishing") != state)
        {
            player_animator.SetBool("Fishing", state);
        }


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


    public bool RunState()
    {
        return (player_animator.GetBool("Run") && player_animator.GetBool("Walk"));
    }


}
