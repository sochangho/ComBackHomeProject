using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem spay_particle;

    private int spray_cnt = 3;
    private bool use_trigger = false;
    

    public void SprayUse()
    {

        if (use_trigger == false)
        {
            use_trigger = true;
            StartCoroutine(SprayRoutin());
            spray_cnt--;
        }

    }


    private void SprayTargetRange()
    {

        Collider[] colliders = Physics.OverlapSphere(FindObjectOfType<PlayerControl>().transform.position, 6f);

        foreach(var collider in colliders)
        {
            if(collider.gameObject.tag == "Zombi")
            {
              
                    var enemy = collider.gameObject.GetComponentInParent<Enemy>();
                    enemy.LifeRoutinStop();
                    enemy.enemy_HP -= 40f;
               

            }

        }

    }

    IEnumerator SprayRoutin()
    {
        float time = 0;

        bool spray_trigger = false;

        // 스프레이 애니메이션 시작
        FindObjectOfType<PlayerControl>().Anim.WalkAnimation(false);
        FindObjectOfType<PlayerControl>().Anim.SprayAnimation(true);
        FindObjectOfType<PlayerControl>().enabled = false;
        spay_particle.Play();



        while (time < 3.2f)
        {


            time += Time.deltaTime;


            if(spray_trigger == false && time > 1f)
            {
                SprayTargetRange();
                spray_trigger = true;

            }

           
            yield return null;


        }

        //스프레이 애니메이션 종료
        FindObjectOfType<PlayerControl>().Anim.SprayAnimation(false);
        FindObjectOfType<PlayerControl>().enabled = true;
        
        if (use_trigger)
        {

            use_trigger = false;

        }


        if (spray_cnt == 0)
        {
            ItemSystem.Instance.ItemUseRemove(new Equipment(EquipmentType.Fkiller));
            FindObjectOfType<EquUI>().ImageNone();
        }


    }




}
