﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashEnd : Popup
{   
    /// <summary>
    /// 육지로 돌아가기
    /// </summary>
    public void GoGroundScene()
    {
        SceneManager.LoadScene("GroundScene");



    }




}
