using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneCharacter : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimaterMgr ani;

    [SerializeField]
    private ParticleSystem water_partcle;


    private void Start()
    {
        AniWater();
    }


    private void AniWater()
    {
        ani.WateringAnimation(true);
        water_partcle.Play();

    }





}
