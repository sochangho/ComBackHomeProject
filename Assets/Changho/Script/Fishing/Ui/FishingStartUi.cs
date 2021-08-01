using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingStartUi : MonoBehaviour
{
    public List<Button> buttons;

    public void Start()
    {
        buttons[0].onClick.AddListener(FishingStartButton);
        buttons[1].onClick.AddListener(UiDestroy);

    }

    private void FishingStartButton()
    {
        TutorialSystem.Instance.LakeStart(() =>
        {
            var fgm = FindObjectOfType<FishingGameManager>();
            var playercont = FindObjectOfType<PlayerControl>();
            var pam = FindObjectOfType<PlayerAnimaterMgr>();

            if (playercont.fishingItem.activeSelf == false)
            {
                playercont.fishingItem.SetActive(true);

            }

            FindObjectOfType<EquUI>().ImageNone();
            FindObjectOfType<EquUI>().ImageChange(EquipmentType.Fishing);
            fgm.FishingButton();
            playercont.PlayerControlStop();
            pam.WalkAnimation(false);
            pam.RunAnimation(false);
            Destroy(this.gameObject);


        });

     
    }
    
    private void UiDestroy()
    {
        Destroy(this.gameObject);

    } 

}
