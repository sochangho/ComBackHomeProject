using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLight : MonoBehaviour
{
  

    // Start is called before the first frame update
    void Start()
    {

        FindObjectOfType<Light>().intensity = 0.1f;

    }

}
