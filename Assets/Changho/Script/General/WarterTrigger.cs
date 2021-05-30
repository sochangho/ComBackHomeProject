
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WarterTrigger : MonoBehaviour
{

   
    private GameObject panel;

    [HideInInspector]
    public bool watercondition = false;
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (FindObjectOfType<PanelActive>() == null)
            {

                panel = FindObjectOfType<UISystem>().ActiveStartCreate();
                
                panel.GetComponent<PanelActive>().croppanel_text.fontSize = 27f;
                panel.GetComponent<PanelActive>().croppanel_text.text = "물을 획득할 수 있습니다. 바가지를 사용하겠습니까??";

                panel.GetComponent<PanelActive>().use_button.onClick.RemoveAllListeners();
                panel.GetComponent<PanelActive>().use_button.onClick.AddListener(ItemSystem.Instance.WaterAdd);
                
            }
        }
        
    }



    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(FindObjectOfType<PanelActive>() != null)
            {
                Destroy(panel);

            }

        }


    }
}
