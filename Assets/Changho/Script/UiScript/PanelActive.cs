
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelActive : MonoBehaviour
{
    public TextMeshProUGUI croppanel_text;
    public Button use_button;

    public void Close()
    {

        Destroy(this.gameObject);

    }


}
