using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum TreeType
{
   AppleTree,
   BananaTree,
   CoconutTree,

}


public class Trees : MonoBehaviour
{

    [SerializeField]
    private TreeType tree_type;

    [SerializeField]
    private List<GameObject> fruits;

    public List<GameObject> Fruits
    {
        get
        {
            return Fruits;
        }
        set
        {
            Fruits = value;
        }

    }

    public TreeType Tree_type
    {

        get
        {
            return tree_type;
        }
    }
    

    private void Gravityfruits(FuritType type)
    {
        int idx = Random.Range(0, fruits.Count);

        if (fruits.Count > 0)
        {

            if (fruits[idx].GetComponent<Fruit>() == null)
            {
                fruits[idx].AddComponent<Fruit>().fluit_type = type;
            }
            if (fruits[idx].GetComponent<BoxCollider>() == null)
            {

                if (type == FuritType.Apple)
                {
                    fruits[idx].GetComponent<BoxCollider>().enabled = true;

                }
                else
                {

                    fruits[idx].AddComponent<BoxCollider>();
                }
            }
            if (fruits[idx].GetComponent<Rigidbody>() == null)
            {
                fruits[idx].AddComponent<Rigidbody>();
                fruits[idx].GetComponent<Rigidbody>().useGravity = true;

            }


            fruits[idx].layer = 15;


            RaycastHit raycastHit;

            var p = FindObjectOfType<PlayerControl>().spwan_point;

            if (Physics.Raycast(p.transform.position, Vector3.down, out raycastHit, 1000f))
            {

                fruits[idx].transform.position = p.transform.position;
                var obj = ObjectPoolMgr.Instance.ParticlePool();
                obj.transform.position = p.transform.position;
                StartCoroutine(PaticleReturn(obj));

            }
            fruits.RemoveAt(idx);
        }
        else
        {
            ItemSystem.Instance.ItemInfoUI("과일이 없어요....!", Color.yellow);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Stone")
        {
            Debug.Log("tree");
            if(tree_type == TreeType.AppleTree)
            {
                Gravityfruits(FuritType.Apple);

            }
            if(tree_type == TreeType.CoconutTree)
            {
                Gravityfruits(FuritType.Coconet);
            }
            if(tree_type == TreeType.BananaTree)
            {
                Gravityfruits(FuritType.Banana);

            }
            collision.collider.gameObject.SetActive(false);
        }

        return;
    }


    IEnumerator PaticleReturn(GameObject obj)
    {
        float time = 0;

        while ( time < 1f)
        {

            time += Time.deltaTime; 

            yield return null;
        }

        ObjectPoolMgr.Instance.ParticleReturn(obj);
    }



}
