using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookMainCamera : MonoBehaviour
{
    private Camera camera;
    public Image gague;

    private void Start()
    {

        camera = GameObject.Find("MainCamera(Clone)").GetComponent<Camera>();


    }



    private void Update()
    {
        transform.LookAt(camera.transform);
    }


}
