using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{

    public LayerMask layerMask;
    public ParticleSystem lightning;


    public void LightningCollider()
    {

        


        RaycastHit raycastHit;
        lightning.Play();
        if (Physics.Raycast(transform.position , Vector3.down, out raycastHit, 100f, layerMask))
        {
            
            raycastHit.collider.GetComponent<TargetCollider>().TreeSlice(raycastHit.point);

        }



    }



}
