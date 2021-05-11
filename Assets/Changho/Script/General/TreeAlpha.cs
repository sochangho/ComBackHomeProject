using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAlpha : MonoBehaviour
{

    public enum SurfaceType
    {

        Opaque,
        Transparent
    }


    public enum BlendMode
    {
        Alpha,
        Premultiply,
        Additive,
        Multiply
    }

   




    public void ChangeLitMode()
    {

         Renderer renderer;
         renderer = GetComponent<Renderer>();
        var mats = renderer.materials;


        foreach(var mat in mats)
        {
            mat.SetFloat("_Surface", (float)SurfaceType.Transparent);
            mat.SetFloat("_Blend", (float)BlendMode.Alpha);
        }



        StartCoroutine(ChangeAlpha(mats));

    }




    IEnumerator ChangeAlpha(Material[] materials)
    {

        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        while (materials[0].GetColor("_BaseColor").a > 0)
        {

            foreach(var mat in materials)
            {
                var matcolor = mat.GetColor("_BaseColor");

                mat.SetColor("_BaseColor", new Color(matcolor.r, matcolor.g, matcolor.b, matcolor.a - 0.05f));

                
            }

            yield return waitForSeconds;
        }


        gameObject.SetActive(false);

    }


}
