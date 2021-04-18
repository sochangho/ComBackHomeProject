
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPbar : MonoBehaviour
{
    public Image hpfill;
    public TextMeshProUGUI hpfilltext;


    public void Update()
    {
        HpbarUpdate();

    }


    private void HpbarUpdate()
    {
       var hp  = FindObjectOfType<PlayerControl>().player_hp;

        if (hp > 100) {
            hp = 100;
        } 
       hpfill.fillAmount = hp / 100;
       hpfilltext.text = hp.ToString("N1");
    }




}
