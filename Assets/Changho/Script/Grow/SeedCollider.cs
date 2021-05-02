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

            GameObject crop_created = new GameObject();

            if(getSeedType == SeedType.TomatoSeed)
            {
                crop_created = Instantiate(Resources.Load<GameObject>("Ganeral/Crop/TomatoCropObj") as GameObject);
            }
            else if (getSeedType == SeedType.CornSeed)
            {

                crop_created = Instantiate(Resources.Load<GameObject>("Ganeral/Crop/CornCropObj") as GameObject);
            }
            else if (getSeedType == SeedType.EggplantSeed)
            {

                crop_created = Instantiate(Resources.Load<GameObject>("Ganeral/Crop/EggplantCropObj") as GameObject);
            }
            else if (getSeedType == SeedType.ChilliSeed)
            {
                crop_created = Instantiate(Resources.Load<GameObject>("Ganeral/Crop/ChilliCropObj") as GameObject);

            }
            crop_created.transform.position = collision.contacts[0].point;
            gameObject.SetActive(false);
            //파티클 생성 

        }


    }

}
