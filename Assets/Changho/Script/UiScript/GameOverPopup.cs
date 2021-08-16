
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverPopup :Popup
{


    public void Start()
    {
        Time.timeScale = 0;   

    }

    public void RestartButtoun()
    {
        Time.timeScale = 1f;
        Close();
       
        var player = FindObjectOfType<PlayerControl>();

        player.player_hp = 100;
        player.player_hungry = 100;
        player.player_force = 100;
        player.transform.position = FindObjectOfType<PlayerPoint>().PlayerRestartPoint();
        player.target = FindObjectOfType<PlayerPoint>().PlayerRestartPoint();
        player.gameover_bool = false;

        ObjectPoolMgr.Instance.objpool[2].Reset();

    }

    public void ButtonSound()
    {
        Sounds.Instance.SoundPlay("SlotClick");
    }

    public void GameEndButton()
    {

        //Application.Quit();
        SceneManager.LoadScene("StartScene");

        
    }


}
