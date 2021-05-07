using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoint : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private GameObject restart_point;

    [SerializeField]
    private GameObject start_point;

    public Vector3 PlayerRestartPoint()
    {
        var repos = new Vector3(0, 0, 0);
        RaycastHit ray;

        if(Physics.Raycast(restart_point.transform.position ,Vector3.down ,out ray,100f,layerMask))
        {

            repos = ray.point;


        }

        return repos;
    }



    public Vector3 PlayerStartPoint()
    {
        var repos = new Vector3(0, 0, 0);
        RaycastHit ray;

        if (Physics.Raycast(start_point.transform.position, Vector3.down, out ray, 100f, layerMask))
        {

            repos = ray.point;


        }

        return repos;
    }


}
