using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIinfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI infotext;

    public string _infotext
    {
        set
        {
            infotext.text = value;
        }
    }
    
    public void TextColor(Color color)
    {
        infotext.color = color;        
    }




}
