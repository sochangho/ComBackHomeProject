
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButton : MonoBehaviour
{

    private Animator animaterUI;






    private void Start()
    {
        animaterUI = GetComponent<Animator>();
    }

    private void GoGround()
    {
        SceneManager.LoadScene("startGo");
    }

    


    public void MouseButtonUpExit(bool trigger)
    {
        animaterUI.SetBool("Scale", trigger);
        
    }


    public void MouseClickAnimation()
    {

        animaterUI.SetBool("Click", true);

        Invoke("GoGround", 1f);


    }


    public void MouseClickExitAnimation()
    {

        animaterUI.SetBool("Click", true);

        Invoke("ExitClick", 1f);
    }


    public void ExitClick()
    {

        Application.Quit();

    }
    

}
