using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedCollider : MonoBehaviour
{

    
    public GameObject[] crop_objs;


    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "CropPlace")
        {

            var getSeedType = GetComponent<Seed>().seed_type;

            GameObject crop_created = new GameObject();

            if(getSeedType == SeedType.TomatoSeed)
            {
                crop_created = Instantiate(crop_objs[0]);
            }
            else if (getSeedType == SeedType.CornSeed)
            {

                crop_created = Instantiate(crop_objs[1]);
            }
            else if (getSeedType == SeedType.EggplantSeed)
            {

                crop_created = Instantiate(crop_objs[2]);
            }
            else if (getSeedType == SeedType.ChilliSeed)
            {
                crop_created = Instantiate(crop_objs[3]);

            }
            crop_created.transform.position = collision.transform.position;
            //파티클 생성 
            
        }


    }

}
