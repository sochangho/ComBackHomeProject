using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    private PlayerControl player;
    private TutorialSystem tutorialSystem;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        tutorialSystem = TutorialSystem.Instance;

    }


    private void LateUpdate()
    {


        if(FindObjectOfType<TutorialSystem>().arrowLook != null && Vector3.Distance(transform.position , tutorialSystem.arrowLook.position) > 10f)
        {
            

            this.transform.LookAt(tutorialSystem.arrowLook.transform);
            
        }
        else
        {
            if (gameObject.activeSelf == true)
            {

                gameObject.SetActive(false);
            }


        }



        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.8f, player.transform.position.z);





    }





}
