using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeStart : MonoBehaviour
{
   
    public float limit_time = 2f;
    public bool use_go_trigger = true;
    private bool use_trigger = false;
    private bool treeuistart_trigger = false;
    


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

               
                var dust = ObjectPoolMgr.Instance.DustParticlePool();
                dust.transform.position = transform.position;
                StartCoroutine(DustParticleRoutin(dust));
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


                if (other.GetComponent<Trees>().Tree_type == TreeType.AppleTree)
                {
                    
                    foreach (var add_fruit in add_fruits)
                    {
                    ItemSystem.Instance.TreeItemCreate(other.transform.position, new Fruit(FuritType.Apple));
                    }
                    
                }
                else if (other.GetComponent<Trees>().Tree_type == TreeType.BananaTree)
                {
                   
                    foreach (var add_fruit in add_fruits)
                    {
                    ItemSystem.Instance.TreeItemCreate(other.transform.position, new Fruit(FuritType.Banana));
                     }
                    
                }
                else if (other.GetComponent<Trees>().Tree_type == TreeType.CoconutTree)
                {
                    
                    foreach (var add_fruit in add_fruits)
                    {
                    ItemSystem.Instance.TreeItemCreate(other.transform.position, new Fruit(FuritType.Coconet));
                    }
                    
                }


            ItemSystem.Instance.TreeItemCreate(other.transform.position, new Part(PartType.FireWood));
            //메쉬슬라이싱
            other.GetComponent<TargetCollider>().TreeSlice(other.transform.position);
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

        

        while(time < limit_time)
        {
            time += Time.deltaTime;


            if((time > 0.3f) && axe_trigger == false)
            {
                PlayerRadiusTreeCheck();
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
