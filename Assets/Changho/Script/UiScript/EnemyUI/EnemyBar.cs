using UnityEngine;
using UnityEngine.UI;

public class EnemyBar : MonoBehaviour
{
    [SerializeField]
    private Image enemy_hpimage;

    private Camera camara;

    private void Start()
    {

        enemy_hpimage.fillAmount = 1f;
        camara = FindObjectOfType<Camera>();

    }


    private void LateUpdate()
    {
        if(camara == null)
        {
            camara = FindObjectOfType<Camera>();

        }

        transform.LookAt(camara.transform);
        transform.Rotate(0, 180, 0);


    }

    public void EnemyHP(float hp)
    {
        enemy_hpimage.fillAmount = hp / 100;
    }


    
  
}
