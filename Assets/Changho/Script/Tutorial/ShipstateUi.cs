using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShipstateUi : MonoBehaviour
{
    public Image handle_image;

    public TextMeshProUGUI tmp;
    

    [HideInInspector]
    public int totalrope = 3;

    [HideInInspector]
    public int totalcloth = 3;

    [HideInInspector]
    public int totalnail = 6;


    [HideInInspector]
    public int totalwood = 20;

    // Update is called once per frame


    private void Start()
    {
        StartCoroutine(Shipupdate());
    }


    IEnumerator Shipupdate()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);

        var rope_str = new Part(PartType.Rope).ItemType();
        var cloth_str = new Part(PartType.Cloth).ItemType();
        var nail_str = new Part(PartType.Nail).ItemType();
        var wood_str = new Part(PartType.FireWood).ItemType();





        while (true)
        {


            StateShip(rope_str, cloth_str, nail_str, wood_str);


            yield return waitForSeconds;
        }





    }




    void StateShip(string rope_str , string cloth_str , string nail_str ,string wood_str)
    {


       

        int rope = 0;

        int cloth = 0;

        int nail = 0;

        int wood = 0;


        foreach(var item in ItemManager.Instance.itemList)
        {

            if(item.ItemType() == rope_str)
            {
                rope++;

            }
            if (item.ItemType() == cloth_str)
            {
                cloth++;

            }
            if (item.ItemType() == nail_str)
            {
                nail++;

            }
            if (item.ItemType() == wood_str)
            {

                wood++;
            }




        }







        if (rope > totalrope)
        {
            rope = totalrope;

        }
        if (cloth > totalcloth)
        {
            cloth = totalcloth;
        }
        if (nail >  totalnail)
        {
            nail = totalnail;

        }
        if (wood > totalwood)
        {
            wood = totalwood;

        }

        var current = rope + cloth + nail + wood;
        var total = totalrope + totalcloth + totalnail + totalwood;

        handle_image.fillAmount = ((float)current / (float)total);
        tmp.text = (((float)current / (float)total) * 100).ToString("N1") + "%";


    }


   

}
