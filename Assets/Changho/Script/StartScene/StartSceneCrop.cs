using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneCrop : MonoBehaviour
{

    [SerializeField]
    private Texture2D crop_texture;

    [SerializeField]
    private Texture2D stem_texure;

    [SerializeField]
    private List<Renderer> crop_renderers;

    [SerializeField]
    private Renderer stem_renderer;


    private void Start()
    {

        CropSet();
        StemSet();

    }

    private void CropSet()
    {
        foreach(var crop_renderer in crop_renderers)
        {
            crop_renderer.material.SetTexture("_MainTex", crop_texture);
            crop_renderer.material.SetFloat("_CropGrow", 1f);

        }


    }
    
    private void StemSet()
    {

        stem_renderer.material.SetTexture("_MainTex", stem_texure);
        stem_renderer.material.SetFloat("_StemGrow", 1f);

    }


}
