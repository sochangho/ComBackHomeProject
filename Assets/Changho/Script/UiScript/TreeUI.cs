using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TreeUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tree_name;

    [SerializeField]
    private Image feel_image;

    [SerializeField]
    private Color fill_color;


    public void TreeName(string str)
    {
        tree_name.text = str;

    }

    public void ImageFill(float tree_fill)
    {

        if(tree_fill >= 20)
        {

            feel_image.color = fill_color;
        }


        if(tree_fill < 20)
        {
            feel_image.color = Color.red;
        }

        feel_image.fillAmount = tree_fill / 100;
        
    }




  
}
