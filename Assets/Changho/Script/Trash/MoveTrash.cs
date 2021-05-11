using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameVanilla.Core;
public class MoveTrash : MonoBehaviour
{

    private Rigidbody rigid_trash;
    private float randomSpeed;
    private ObjectPool obj;

    public float max = 15f;
    public float min = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rigid_trash = GetComponent<Rigidbody>();
        randomSpeed = Random.Range(min, max);
        obj = GetComponentInParent<ObjectPool>();
        StartCoroutine(MoveRoutin());

        if(this.gameObject.tag == "Lightning")
        {

            transform.position=new Vector3(this.transform.position.x, GameObject.Find("Sea").transform.position.y, this.transform.position.z);

        }
       
    }

    IEnumerator MoveRoutin()
    {

      

        while (true)
        {

           

            rigid_trash.AddForce(Vector3.back * randomSpeed * Time.deltaTime);


            yield return null;

        }

     
    }


    private void OnTriggerEnter(Collider other)
    {

        if (this.gameObject.tag != "Lightning")
        {
            if (other.tag == "Pan")
            {

                obj.ReturnObject(gameObject);

            }
            else if (other.tag == "ShipLope")
            {

                if (this.gameObject.tag == "LightningBoll")
                {
                    obj.ReturnObject(gameObject);
                    FindObjectOfType<TrashSystem>().WeatherChange(true);

                }
                else
                {
                    obj.ReturnObject(gameObject);
                    FindObjectOfType<TrashSystem>().IncreaseCount(transform.GetChild(0).gameObject);
                }
            }
        }
        else 
        {
            if (other.tag == "ShipLope")
            {
                var trash_system = FindObjectOfType<TrashSystem>();
                FindObjectOfType<ShipState>().ChangeStart();
                trash_system.shipHp -= 10;
               // trash_system.ItemZero();

      
            }

            if (other.tag == "Pan")
            {

                obj.ReturnObject(gameObject);

            }

        }
        
    }


}
