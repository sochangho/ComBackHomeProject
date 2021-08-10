
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WarterTrigger : MonoBehaviour
{

    public GameObject arrow;
    private GameObject panel;

    [HideInInspector]
    public bool watercondition = false;
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (arrow.activeSelf)
            {
                arrow.SetActive(false);
            }

            if ((TutorialSystem.Instance.tutorial_index == TutorialSystem.Instance.tutorials.FindIndex(x => x is FishingTutorial))
                && (FindObjectOfType<FishingStartUi>() == null))
            {

                FindObjectOfType<UISystem>().CreateFishingStartUi();
                return;
            }


            WaterPickup();



        }
        
    }



    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!arrow.activeSelf)
            {
                arrow.SetActive(true);
            }


            if (FindObjectOfType<PanelActive>() != null)
            {
                Destroy(panel);

            }

            if(FindObjectOfType<FishingStartUi>() != null)
            {

                Destroy(FindObjectOfType<FishingStartUi>().gameObject);
            }

        }


    }

    public void WaterPickup()
    {

        if (FindObjectOfType<PanelActive>() == null)
        {

            panel = FindObjectOfType<UISystem>().ActiveStartCreate();

            panel.GetComponent<PanelActive>().croppanel_text.fontSize = 27f;
            panel.GetComponent<PanelActive>().croppanel_text.text = "물을 획득할 수 있습니다. 바가지를 사용하겠습니까??";

            panel.GetComponent<PanelActive>().use_button.onClick.RemoveAllListeners();
            panel.GetComponent<PanelActive>().use_button.onClick.AddListener(ItemSystem.Instance.WaterAdd);
            panel.GetComponent<PanelActive>().use_button.onClick.AddListener(() => { Sounds.Instance.SoundPlay("SlotClick"); });
            panel.GetComponent<PanelActive>().destroy_button.onClick.AddListener(() => { Sounds.Instance.SoundPlay("SlotClick"); });

        }


    }



}
