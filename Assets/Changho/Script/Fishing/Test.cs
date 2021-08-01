using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    bool isfishable = true;


    private void OnTriggerEnter(Collider other)
    {
        if (isfishable)
        {
            isfishable = false;
            FindObjectOfType<FishingGameManager>().FishingButton();
            FindObjectOfType<PlayerControl>().gameObject.transform.position 
                = FishingGameManager.Instance.playerStartPoint.position;
            FindObjectOfType<PlayerControl>().transform.LookAt(FishingGameManager.Instance.playerStartLookatPoint);
            FindObjectOfType<PlayerControl>().enabled = false;
            FindObjectOfType<PlayerAnimaterMgr>().WalkAnimation(false);
            FindObjectOfType<PlayerAnimaterMgr>().RunAnimation(false);
        }
    }
}
