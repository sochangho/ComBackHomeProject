using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIFade : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI infoText;
    [SerializeField]
    private Image infoPanel;

    float fades = 1.0f;
    float fadesout = 0.05f;
    private Coroutine fade_coroutin;
   
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
      
        if(fades <= 0.0f)
        {
            StopCoroutine(fade_coroutin);
            infoText.gameObject.SetActive(false);
            infoPanel.gameObject.SetActive(false);
        }

    }


    IEnumerator Fade()
    {

        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        
        while (fades > 0.0f)
        {

                fades -= fadesout;
                infoPanel.color = new Color(infoPanel.color.r, infoPanel.color.g, infoPanel.color.b, fades);
                infoText.color = new Color(infoText.color.r, infoText.color.g, infoText.color.b, fades);
              

            yield return waitForSeconds;

        }

    }


    public void FadeStart()
    {
        infoText.gameObject.SetActive(true);
        infoPanel.gameObject.SetActive(true);
        infoText = GetComponentInChildren<TextMeshProUGUI>();
        infoPanel = GetComponentInChildren<Image>();
        fades = 1.0f;   
        fade_coroutin = StartCoroutine(Fade());

    }



    
}
