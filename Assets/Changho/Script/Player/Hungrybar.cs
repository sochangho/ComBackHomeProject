
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hungrybar : MonoBehaviour
{
    public Image hungryfill;
    public TextMeshProUGUI hungryfilltext;


    public void Update()
    {
        HungrybarUpdate();

    }


    private void HungrybarUpdate()
    {
        var hungry = PlayerControl.Instance.player_hungry;

        if (PlayerControl.Instance.player_hungry > 100)
        {

            PlayerControl.Instance.player_hungry = 100;
            hungry = 100;
        }
        hungryfill.fillAmount = hungry / 100;
        hungryfilltext.text = hungry.ToString("N1");
    }





}
