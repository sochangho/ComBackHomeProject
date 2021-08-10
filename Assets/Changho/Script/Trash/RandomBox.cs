using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    [SerializeField]
    private Material[] defaul_mat;

    [SerializeField]
    private Material[] explo_mat;

    [SerializeField]
    private Material[] remedy_mat;


    [SerializeField]
    private MeshRenderer mr;

    [SerializeField]
    private MoveTrash trash;

    int number;


 
    private void OnEnable()
    {
        number = Random.Range(0, 3);

        if (number == 0)
        {
            mr.materials = explo_mat;
            trash.min = 90;
            trash.max = 100;

        }
        else if(number == 1)
        {
            mr.materials = remedy_mat;
            trash.min = 40;
            trash.max = 50;


        }
        else
        {
            mr.materials = defaul_mat;
            trash.min = 15;
            trash.max = 20;


        }
        


    }


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "ShipLope")
        {
            ExplodeRandom();

        }

    }



    private void ExplodeRandom()
    {
        
        var trash_system = FindObjectOfType<TrashSystem>();
        var ship = FindObjectOfType<ShipState>();
        if (number == 0)
        {
            //폭발
               
            ship.camaraShake.CamaraShakeStart();
            ship.ShipExplosion();
            trash_system.shipHp -= 5;
            //trash_system.ItemZero();
            Sounds.Instance.SoundPlay("explosion");

        }
        else if(number == 1)
        {
            trash_system.shipHp += 5;

        }
        else
        {
            trash_system.RandomBoxCount();

        }


    }
}
