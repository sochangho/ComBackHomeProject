using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyFly : MonoBehaviour
{
    private PlayerControl player;
    private CamaraShake camaraShake;




    private void OnEnable()
    {

        player = FindObjectOfType<PlayerControl>();

        if (SceneManager.GetActiveScene().name == "GroundScene")
        {
            camaraShake = GameObject.Find("MainCamera(Clone)").GetComponent<CamaraShake>();
        }
    }



    private void OnParticleCollision(GameObject other)
    {
        
        if(other.tag == "Player")
        {
            camaraShake.CamaraShakeStart();
            Sounds.Instance.SoundPlay("Bugattack");
            player.player_hp -= 0.1f;
           
        }
   

    }


    



}
