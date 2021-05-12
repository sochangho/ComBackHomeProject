
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButton : MonoBehaviour
{
  
    public void GoGround()
    {
        SceneManager.LoadScene("startGo");
    }
}
