using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedCollider : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Terrain")
        {

            var getSeedType = GetComponent<Seed>().seed_type;

           

            if(getSeedType == SeedType.TomatoSeed)
            {
               var crop_created = Instantiate(Resources.Load<GameObject>("Ganeral/Crop/TomatoCropObj") as GameObject);
                crop_created.transform.position = collision.contacts[0].point;

                crop_created.transform.SetParent(FindObjectOfType<Terrain>().transform);

            }
            else if (getSeedType == SeedType.CornSeed)
            {

               var crop_created = Instantiate(Resources.Load<GameObject>("Ganeral/Crop/CornCropObj") as GameObject);
                crop_created.transform.position = collision.contacts[0].point;

                crop_created.transform.SetParent(FindObjectOfType<Terrain>().transform);
            }
            else if (getSeedType == SeedType.EggplantSeed)
            {

              var  crop_created = Instantiate(Resources.Load<GameObject>("Ganeral/Crop/EggplantCropObj") as GameObject);
                crop_created.transform.position = collision.contacts[0].point;

                crop_created.transform.SetParent(FindObjectOfType<Terrain>().transform);
            }
            else if (getSeedType == SeedType.ChilliSeed)
            {
              var  crop_created = Instantiate(Resources.Load<GameObject>("Ganeral/Crop/ChilliCropObj") as GameObject);
                crop_created.transform.position = collision.contacts[0].point;

                crop_created.transform.SetParent(FindObjectOfType<Terrain>().transform);
            }
            
            gameObject.SetActive(false);
            //파티클 생성 

        }


    }

}
