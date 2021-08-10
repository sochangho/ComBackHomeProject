using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TorchLlightStart : MonoBehaviour
{

    private Transform player_transform;
   
    private bool use_triger = false;

    private bool collider_triger = false;

    private bool fire_endTrigger = false;

    public float Th_limit = 0.8f;

    public TrailRenderer attack_renderer;


    [SerializeField]
    private GameObject fire_particle;

    public GameObject Fire
    {
        get
        {
           return fire_particle;
        }
    }

    //public FireState torchfire_state = FireState.Firing;



    private void Start()
    {
        player_transform = GetComponentInParent<Transform>();

        attack_renderer.enabled = false;
    }



    private void PlayerRadiusEnemyCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(FindObjectOfType<PlayerControl>().transform.position, 4f);

        StartCoroutine(AttackRoutin(colliders));
        StartCoroutine(AttackSoudRoutin(colliders));
    }

    public void TorchLightEnd()
    {
        
        FindObjectOfType<EquUI>().ImageNone();
        ItemSystem.Instance.ItemUseRemove(new Equipment(EquipmentType.TorchLight));

        //그리고 착용취소 상태 and 인벤토리에서 파괴
        //착용시에 불을켜버린다
        FindObjectOfType<PlayerAnimaterMgr>().WieldAnimation(false);

    }


     public void Wield()
    {
        //if (fire_endTrigger)
        //{
        //    ItemSystem.Instance.ItemInfoUI("횃불을 사용할 수 없습니다.", Color.red);
        //    return;
            
        //}        
        if (!use_triger)
        {

            StartCoroutine(WieldRoutin());
            use_triger = true;
        }
    }


    IEnumerator WieldRoutin()
    {
        float time = 0;
        bool torchlight_trigger = false;
        attack_renderer.enabled = true;
        FindObjectOfType<PlayerAnimaterMgr>().WieldAnimation(true);
        Sounds.Instance.SoundPlay("Wield");

        while (time < Th_limit)
        {

            time += Time.deltaTime;



            if ((time > 0.3f) && torchlight_trigger == false)
            {
                PlayerRadiusEnemyCheck();
                torchlight_trigger = true;
            }

            yield return null;
        }

      

        if (use_triger)
        {
            use_triger = false;
        }
        attack_renderer.Clear();
        attack_renderer.enabled = false;
       
        FindObjectOfType<PlayerAnimaterMgr>().WieldAnimation(false);
      

    }

    IEnumerator AttackRoutin(Collider[] colliders)
    {

        foreach (var collider in colliders)
        {
            if (collider.gameObject.tag == "Zombi")
            {

                var enemy = collider.gameObject.GetComponentInParent<Enemy>();




                enemy.LifeRoutinStop();
                enemy.enemy_HP -= 10f;
              

            }


            yield return new WaitForSeconds(0.1f);
        }




    }

    IEnumerator AttackSoudRoutin(Collider[] colliders)
    {

        foreach (var collider in colliders)
        {
            if (collider.gameObject.tag == "Zombi")
            {
                var enemy = collider.gameObject.GetComponentInParent<Enemy>();
                if (enemy.enemy_HP > 0)
                {

                    var sound = ObjectPoolMgr.Instance.AttackSoundPool();
                    StartCoroutine(SoundReturn(sound));
                }
            }


            yield return new WaitForSeconds(0.1f);
        }




    }



    IEnumerator SoundReturn(GameObject sound)
    {

        yield return new WaitForSeconds(0.1f);
        ObjectPoolMgr.Instance.AttackSoundReturn(sound);

    }


}
