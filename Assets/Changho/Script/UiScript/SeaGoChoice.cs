using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SeaGoChoice :Popup
{
    /// <summary>
    /// 돗단배가 있어야한다
    /// </summary>
    public void GoTrash()
    {

        SceneManager.LoadScene("TrashScene");

    }

    /// <summary>
    /// 돗단배가 있어야한다.
    /// </summary>


    public void GoFish()
    {


    }

    public void OnCloseChoice()
    {
        Close();


    }


}
