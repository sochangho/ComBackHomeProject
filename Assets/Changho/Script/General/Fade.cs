using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    Renderer render;
  
    public void FadeOutStart()
    {
        render = gameObject.GetComponent<Renderer>();
        //StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        int i = 20;
        while (i > 0)
        {
            i -= 1;
            if(i == 0)
            {
               // gameObject.SetActive(false);
            }

            float f = i / 20.0f;
            Color c = render.material.color;
            c.a = f;
            render.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Terrain")
        {
            StartCoroutine(FadeOut());

        }


    }


}
