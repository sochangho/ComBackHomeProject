using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingGageUi : MonoBehaviour
{

    private Camera camera;
    public Image gage_img;

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();
        gage_img.fillAmount = 1;
        Sounds.Instance.SoundPlay("FishingGage");
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(camera.transform);
        gage_img.fillAmount -= 0.01f; 

        if(gage_img.fillAmount <= 0)
        {
            //파티클생성 


            //이벤트 
            EventManager.Emit("Acquire", null);
            Sounds.Instance.SoundPlay("FishingComplete");
            Destroy(this.gameObject);

        }

        

    }
}
