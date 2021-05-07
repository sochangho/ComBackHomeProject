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
        bool ok = false;
        var itemsystem = ItemSystem.Instance;

        foreach(var item in itemsystem.items)
        {

            if(item.ItemType() == new Part(PartType.Raft).ItemType())
            {
                ok = true;
                break;
            }
        }


        if (ok)
        {

            DaySystem.Instance.StopDaySystem();
            SceneManager.LoadScene("TrashScene");

        }
        else
        {
            itemsystem.ItemInfoUI("뗏목이 없습니다!", Color.blue);
        }


        

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
