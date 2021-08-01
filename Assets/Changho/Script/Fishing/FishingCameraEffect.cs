using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingCameraEffect : MonoBehaviour
{
    private Vector3 cameraStartPos;
    private Quaternion cameraStartRot;
    public Vector3 cameraDestination;



    private void Start()
    {
        cameraStartPos = transform.position;
        cameraStartRot = transform.rotation;
    }


    public void CameraEffect(GameObject lookitem)
    {
        StartCoroutine(moveCamera(lookitem));
       



    }

    public void RestoreCamera()
    {
        transform.position = cameraStartPos;
        transform.rotation = cameraStartRot;


    }


    IEnumerator moveCamera(GameObject ltem)
    {
        while (Vector3.Distance(transform.position , cameraDestination) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, cameraDestination, 10 * Time.deltaTime);

            yield return null;

        }

        StartCoroutine(lookItemCamera(ltem));
    }


    IEnumerator lookItemCamera(GameObject lookitem)
    {

        while (lookitem != null)
        {

            transform.LookAt(lookitem.transform);
            yield return null;

        }

        RestoreCamera();
    }

}
