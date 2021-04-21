using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxOpen : MonoBehaviour
{

    private List<string> trashitemnames = new List<string>();

    public void OpenBox()
    {

        var itemsystem = ItemSystem.Instance;

        int ran = Random.Range(0, 10);

        trashitemnames.Add("Nail");
        trashitemnames.Add("Fkiller");
        trashitemnames.Add("Bowl");
        trashitemnames.Add("Rope");


        if(ran == 0)
        {
          int item_rancnt = Random.Range(0, trashitemnames.Count);
          var item_ran = trashitemnames[item_rancnt];


          



        }






    }





}
