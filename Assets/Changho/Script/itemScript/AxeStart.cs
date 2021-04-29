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
                collider.GetComponent<Trees>().TreeNameSet();
                collider.GetComponent<Trees>().tree_hp -= 5;
                collider.GetComponent<Trees>().TreeHpSet();

                if(collider.GetComponent<Trees>().tree_hp <= 0)
                {
                    collider.GetComponent<Trees>().tree_hp = 0;
                    ActionAxe(collider);
                }

                TreeUIStart();
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
                    fruitname = new Fruit(FuritType.Apple).GetItemName();
                    foreach (var add_fruit in add_fruits)
                    {
                        ItemSystem.Instance.ItemCreate(new Fruit(FuritType.Apple).ItemType());
                    }
                    ItemSystem.Instance.ItemInfoUI(fruitname + " " + add_fruits.Count + "개" + namoo + " 1개 얻었습니다!!", Color.blue);
                }
                else if (other.GetComponent<Trees>().Tree_type == TreeType.BananaTree)
                {
                    fruitname = new Fruit(FuritType.Banana).GetItemName();
                    foreach (var add_fruit in add_fruits)
                    {
                        ItemSystem.Instance.ItemCreate(new Fruit(FuritType.Banana).ItemType());
                    }
                    ItemSystem.Instance.ItemInfoUI(fruitname + " " + add_fruits.Count + "개" + namoo + " 1개 얻었습니다!!", Color.blue);
                }
                else if (other.GetComponent<Trees>().Tree_type == TreeType.CoconutTree)
                {
                    fruitname = new Fruit(FuritType.Coconet).GetItemName();
                    foreach (var add_fruit in add_fruits)
                    {
                        ItemSystem.Instance.ItemCreate(new Fruit(FuritType.Coconet).ItemType());
                    }
                    ItemSystem.Instance.ItemInfoUI(fruitname + " " + add_fruits.Count + "개" + namoo + " 1개 얻었습니다!!", Color.blue);
                }


                ItemSystem.Instance.ItemCreate(new Part(PartType.FireWood).ItemType());
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
        var treeui = FindObjectOfType<UISystem>().ui_tree;

        if(treeui.gameObject.activeSelf == false)
        {

            treeui.gameObject.SetActive(true);

        }
        while (time < 5f)
        {
            time += Time.deltaTime;
            
            yield return null;
        }

        if (treeui.gameObject.activeSelf == true)
        {

            treeui.gameObject.SetActive(false);

        }



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
