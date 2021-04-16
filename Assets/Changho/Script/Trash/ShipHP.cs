using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShipHP : MonoBehaviour
{
    public Image hpfill;
    public TextMeshProUGUI hpfilltext;




    public void Update()
    {
        HpbarUpdate();

    }


    private void HpbarUpdate()
    {
        var hp = FindObjectOfType<TrashSystem>().shipHp;

        if (hp > 100)
        {

            PlayerControl.Instance.player_hp = 100;
            hp = 100;
        }

        hpfill.fillAmount = hp / 100;
        hpfilltext.text = hp.ToString("N1");
    }
}
