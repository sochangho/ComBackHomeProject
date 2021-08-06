using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AxeStart : MonoBehaviour
{
   
    public float limit_time = 2f;
    public bool use_go_trigger = true;
    public GameObject sound;

    private bool use_trigger = false;
    private bool treeuistart_trigger = false;

    [HideInInspector]
    public Vector3 axe_normal;

    public void AxeWield()
    {

        if (use_trigger == false && use_go_trigger == true)
        {
            use_trigger = true;
            StartCoroutine(AxeRoutin());

        }
       
    }


    private void TreeUIStart()
    {
        if(treeuistart_trigger == false)
        {
            treeuistart_trigger = true;
            StartCoroutine(TreeUIRoutin());

        }
        


    }

   

    private void PlayerRadiusTreeCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(FindObjectOfType<PlayerControl>().transform.position, 3f);
        

        foreach(var collider in colliders)
        {
            if(collider.tag == "Tree")
            {
                TreeUIStart();
                collider.GetComponent<Trees>().TreeNameSet();
                collider.GetComponent<Trees>().tree_hp -= 30;
                collider.GetComponent<Trees>().TreeHpSet();

                if(collider.GetComponent<Trees>().tree_hp <= 0)
                {
                    collider.GetComponent<Trees>().tree_hp = 0;
                    ActionAxe(collider);
                }

                if(collider.GetComponent<CamaraShake>() == null)
                {
                   var shake = collider.gameObject.AddComponent<CamaraShake>();
                    shake._amount = 0.2f;
                    shake._duration = 0.1f;
                }

                collider.GetComponent<CamaraShake>().CamaraShakeStart();
                
                var dust = ObjectPoolMgr.Instance.DustParticlePool();
                dust.transform.position = transform.position;
                StartCoroutine(DustParticleRoutin(dust));
                StartCoroutine(Sound());
                FindObjectOfType<UISystem>().ui_forec.DecreaseForceBar();
               
                break;
            }
        }
    }


    private void ActionAxe(Collider other)
    {
      



            var playerTotreeDir = other.transform.position - FindObjectOfType<PlayerControl>().transform.position;
            var playertreeDot = Vector3.Dot(playerTotreeDir.normalized, FindObjectOfType<PlayerControl>().transform.forward);

        

            if (playertreeDot > 0f)
            {
                var add_fruits = other.GetComponent<Trees>().Fruits;
                string fruitname;
                string namoo = new Part(PartType.FireWood).GetItemName();
                other.GetComponent<TargetCollider>().TreeSlice(other.transform.position);

            FindObjectOfType<PlayerControl>().enabled = false;
            StartCoroutine(DelayCallback(2f ,() => {FindObjectOfType<PlayerControl>().enabled = true;}));

            if (other.GetComponent<Trees>().Tree_type == TreeType.AppleTree)
                {

                StartCoroutine(DelayCallback(2f ,() =>
                {

                    foreach (var add_fruit in add_fruits)
                    {
                        ItemSystem.Instance.TreeItemCreate(other.transform.position, new Fruit(FuritType.Apple)  , 
                            Resources.Load<Material>("Mat/GlowMat_Apple")as Material );
                        
                    }


                }));

                
                    
                }
                else if (other.GetComponent<Trees>().Tree_type == TreeType.BananaTree)
                {
                StartCoroutine(DelayCallback(2f ,() => {
                    foreach (var add_fruit in add_fruits)
                    {
                        ItemSystem.Instance.TreeItemCreate(other.transform.position, new Fruit(FuritType.Banana),
                             Resources.Load<Material>("Mat/GlowMat_Banana") as Material);
                       
                    }
                }));

                }
                else if (other.GetComponent<Trees>().Tree_type == TreeType.CoconutTree)
                {
                StartCoroutine(DelayCallback( 2f,() => {


                    foreach (var add_fruit in add_fruits)
                    {
                        ItemSystem.Instance.TreeItemCreate(other.transform.position, new Fruit(FuritType.Coconet),
                             Resources.Load<Material>("Mat/GlowMat_Blown") as Material);
                        
                    }


                }));    

                }

            StartCoroutine(DelayCallback(2f , ()
                =>
            {

                Vector3 pos;
                if(other.GetComponent<Trees>().Tree_type == TreeType.AppleTree)
                {
                    pos = new Vector3(other.transform.position.x, other.transform.position.y + 5f, other.transform.position.z);
                }
                else
                {
                    pos = other.transform.position;
                }
                ItemSystem.Instance.TreeItemCreate(pos, new Part(PartType.FireWood) ,
                     Resources.Load<Material>("Mat/GlowMat_Blown") as Material);
            }));

           
            }


        
    }

    IEnumerator DelayCallback(float delay, Action itemCallback)
    {
        yield return new WaitForSeconds(delay);

        if (itemCallback != null)
        {
            itemCallback();

        }


    }




    /// <summary>
    ///  무기 사용 대기시간
    /// </summary>
    /// <returns></returns>

    IEnumerator AxeRoutin()
    {
        float time = 0;
        bool axe_trigger = false;

        FindObjectOfType<PlayerAnimaterMgr>().WieldAnimation(true);
        Sounds.Instance.SoundPlay("Wield");
        

        while(time < limit_time && FindObjectOfType<PlayerAnimaterMgr>().WieldState())
        {
            time += Time.deltaTime;


            if((time > 0.3f) && axe_trigger == false)
            {
                PlayerRadiusTreeCheck();
                axe_normal = transform.right;
                axe_trigger = true;
            }


            yield return null;
        }


        if (use_trigger == true)
        {
            use_trigger = false;
        }
        FindObjectOfType<PlayerAnimaterMgr>().WieldAnimation(false);
        

    }

    IEnumerator TreeUIRoutin()
    {
        float time = 0;
        var treeui =  FindObjectOfType<UISystem>().TreeUICreate();

        while (time < 5f)
        {
            time += Time.deltaTime;
            
            yield return null;
        }

        Destroy(treeui);


        if(treeuistart_trigger == true)
        {
            treeuistart_trigger = false;
        }

    }

    IEnumerator Sound()
    {
        sound.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        sound.SetActive(false);
    }


    IEnumerator DustParticleRoutin(GameObject obj)
    {
        float time = 0;

        while(time < 1f)
        {
            time += Time.deltaTime;

            yield return null; 
        }
        ObjectPoolMgr.Instance.DustParticleReturn(obj);
    }

}
