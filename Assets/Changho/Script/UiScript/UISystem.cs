using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [HideInInspector]
    public TreeUI ui_tree;
    public GameObject tree_pos;
    public GameObject tutorial_pos;
    public GameObject active_pos;
    public ForceUI ui_forec;


    public Canvas canvas;


    public GameObject TreeUICreate()
    {

        var tree_ui = Instantiate(Resources.Load<GameObject>("UI/Popup/TreeUI") as GameObject);
        tree_ui.transform.parent = tree_pos.transform;
        tree_ui.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
       
        ui_tree = tree_ui.GetComponent<TreeUI>();

        return tree_ui;
    }


    public GameObject TutorialUICreate()
    {
        var tutorial_ui = Instantiate(Resources.Load<GameObject>("UI/Popup/Tutorialinfo"));
        tutorial_ui.transform.parent = tutorial_pos.transform;
        tutorial_ui.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);

        return tutorial_ui;
    }



    public GameObject CropStartUICreate()
    {
        var cropui = Instantiate(Resources.Load<GameObject>("UI/Popup/cropstart"));
        cropui.transform.parent = canvas.transform;
        cropui.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);

        return cropui;

    }

    public GameObject ActiveStartCreate()
    {
        var asui = Instantiate(Resources.Load<GameObject>("UI/Popup/ActiveStartPopup"));
        asui.transform.parent = active_pos.transform;
        asui.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);

        return asui;


    }

}
