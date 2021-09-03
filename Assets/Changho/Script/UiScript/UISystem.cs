using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISystem : MonoBehaviour
{
    [HideInInspector]
    public TreeUI ui_tree;
    //public GameObject tree_pos;
    //public GameObject tutorial_pos;
    //public GameObject active_pos;
    public ForceUI ui_forec;

    public GameObject fishingGageUi;
    public GameObject fishingAquireUi;
    public GameObject fishingStartUi;
    public GameObject PanelUi;
    public GameObject TransitionUi;
   
    public Canvas canvas;
    public Canvas playerCanvas;

    public GameObject TreeUICreate()
    {

        var tree_ui = Instantiate(Resources.Load<GameObject>("UI/Popup/TreeUI") as GameObject);
        tree_ui.transform.parent = canvas.transform;
        tree_ui.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
        tree_ui.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        tree_ui.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        tree_ui.GetComponent<RectTransform>().anchoredPosition = new Vector3(-204.65f, -53.64998f, 0f);
        
        ui_tree = tree_ui.GetComponent<TreeUI>();

        return tree_ui;
    }


    public GameObject TutorialUICreate()
    {
        var tutorial_ui = Instantiate(Resources.Load<GameObject>("UI/Popup/Tutorialinfo"));
        tutorial_ui.transform.parent = canvas.transform;
        tutorial_ui.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
        tutorial_ui.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        tutorial_ui.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        tutorial_ui.GetComponent<RectTransform>().anchoredPosition = new Vector2(-236.83f, -184.27f);

        return tutorial_ui;
    }



    public GameObject CropStartUICreate()
    {
        var cropui = Instantiate(Resources.Load<GameObject>("UI/Popup/cropstart"));
        cropui.transform.parent = canvas.transform;
        cropui.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);

        return cropui;

    }

    public GameObject ActiveStartCreate()
    {
        var asui = Instantiate(Resources.Load<GameObject>("UI/Popup/ActiveStartPopup"));
        asui.transform.parent = canvas.transform;
        asui.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);

        return asui;


    }

    
    public void CreateFishingGamge()
    {

        if (playerCanvas.worldCamera == null)
        {
            playerCanvas.worldCamera = FindObjectOfType<Camera>();
        }
        var ui = Instantiate(fishingGageUi);
        ui.transform.SetParent(playerCanvas.gameObject.transform);
        ui.transform.localPosition = new Vector3(0f, 0f, 0f);
        ui.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0.82f,0f);

    }

    public void CreateFishingAquireUi(Items fishitem)
    {
        var ui = Instantiate(fishingAquireUi);
        ui.transform.SetParent(canvas.transform);
        ui.GetComponent<RectTransform>().anchoredPosition = new Vector3(26f, -222f);
        fishingAquireUi.GetComponent<FishingAcquireUi>().itemaquire_img.sprite = Resources.Load<Sprite>("Sprite/" + fishitem.ItemType());

        StartCoroutine(CreateAfterDestroy(ui));
    }

    public void CreateFishingStartUi()
    {
        var ui = Instantiate(fishingStartUi);
        ui.transform.SetParent(canvas.transform);
        ui.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.375f, 78.54596f);


    }


    public GameObject CreatePanelUi()
    {
         PanelUi.SetActive(true);                    
        return PanelUi;
    }

    public void CreateTrasitionUi()
    {
        var ui = Instantiate(TransitionUi);
        ui.transform.SetParent(canvas.transform);
        ui.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 137f);
        ui.GetComponent<PanelActive>().croppanel_text.text = "이동할 수 있습니다. 이동할까요??";

       
        ui.GetComponent<PanelActive>().use_button.onClick.AddListener(()=> { FindObjectOfType<Transitions>().SetTrastionPos(TutorialSystem.Instance.tutorial_index); });
        ui.GetComponent<PanelActive>().use_button.onClick.AddListener(() => { Destroy(ui); });



    }


    
    public void UIClick()
    {
        Sounds.Instance.SoundPlay("Click");
    }



    IEnumerator CreateAfterDestroy(GameObject obj)
    {
        yield return new WaitForSeconds(5f);

        Destroy(obj);


    }
}
