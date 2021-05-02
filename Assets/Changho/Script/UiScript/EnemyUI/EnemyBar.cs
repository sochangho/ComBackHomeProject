using UnityEngine;
using UnityEngine.UI;

public class EnemyBar : MonoBehaviour
{
    [SerializeField]
    private Image enemy_hpimage;


    private void Start()
    {

        enemy_hpimage.fillAmount = 1f;


    }


    private void LateUpdate()
    {

        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);


    }

    public void EnemyHP(float hp)
    {
        enemy_hpimage.fillAmount = hp / 100;
    }


    
  
}
