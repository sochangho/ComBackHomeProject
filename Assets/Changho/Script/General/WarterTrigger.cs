
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WarterTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private TextMeshProUGUI panel_tmp;

    [SerializeField]
    private Button panel_button;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (panel.activeSelf == false)
            {

                panel.SetActive(true);
                panel_tmp.fontSize = 27f;
                panel_tmp.text = "물을 획득할 수 있습니다. 바가지를 사용하겠습니까??";

                panel_button.onClick.RemoveAllListeners();
                panel_button.onClick.AddListener(ItemSystem.Instance.WaterAdd);
                
            }
        }
        
    }



    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(panel.activeSelf == true)
            {
                panel.SetActive(false);

            }

        }


    }
}
