﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    [HideInInspector]
    public TreeUI ui_tree;
    public GameObject tree_pos;
    public ForceUI ui_forec;


    public GameObject TreeUICreate()
    {

        var tree_ui = Instantiate(Resources.Load<GameObject>("UI/Popup/TreeUI") as GameObject);
        tree_ui.transform.parent = tree_pos.transform;
        tree_ui.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
       
        ui_tree = tree_ui.GetComponent<TreeUI>();

        return tree_ui;
    }


}
