using System.Collections;
using UnityEngine;


public class BornfireStart : MonoBehaviour
{

    private float time = 0;

    [SerializeField]
    private float limit_time = 20;
    [SerializeField]
    private float delay = 0.3f;
    [SerializeField]
    private GameObject paticleobj;

   
    private PlayerControl _player;

    private Coroutine bornfire_coroutin;

    private bool fireTrigger = true;



    private void Start()
    {
        _player = FindObjectOfType<PlayerControl>();
        bornfire_coroutin = StartCoroutine(BornfireCorutin());
       

    }


    IEnumerator BornfireCorutin()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.3f);
        paticleobj.GetComponent<ParticleSystem>().Play();
        while (true)//(time < limit_time)
        {
         
            time += Time.deltaTime;


            if(Vector3.Distance(paticleobj.transform.position, _player.transform.position) < 3f)
            {

               if(_player.player_hp < 100)
                {
                    _player.player_hp += 0.1f;

                }
                else
                {
                    _player.player_hp = 100;

                }

            }

            yield return waitForSeconds;

        }

        //paticleobj.SetActive(false);
        //fireTrigger = false;
        //StopCoroutine(bornfire_coroutin);
    }

    private void OnTriggerEnter(Collider other)
    {
        
       if(other.tag == "Zombi" && fireTrigger == true)
        {

            Debug.Log(other.name);
            other.GetComponentInParent<Enemy>().State = EnemyState.Gohome;
            other.GetComponentInParent<Enemy>().searchTrigger = false;
        }
 
             
    }

    private void OnTriggerExit(Collider other)
    {
        
        if(other.tag == "Zombi" && fireTrigger == true)
        {
            Debug.Log("나갔다");
            other.GetComponentInParent<Enemy>().searchTrigger = true;


        }


    }





}
