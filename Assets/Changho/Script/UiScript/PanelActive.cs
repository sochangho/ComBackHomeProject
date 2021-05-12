
using UnityEngine;
using TMPro;

public class PanelActive : MonoBehaviour
{
    public TextMeshProUGUI croppanel_text;


    public void Close()
    {

        Destroy(this.gameObject);

    }


}
