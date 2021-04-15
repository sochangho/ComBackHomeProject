using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{

    public float ship_seed;
    public Transform r_limit;
    public Transform l_limit;


    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

            if (l_limit.position.x < transform.position.x)
            {
                transform.Translate(Vector3.back * ship_seed * Time.deltaTime);
            }

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (r_limit.position.x > transform.position.x)
            {
                {
                    transform.Translate(Vector3.forward * ship_seed * Time.deltaTime);
                }

            }




        }



    }



}
