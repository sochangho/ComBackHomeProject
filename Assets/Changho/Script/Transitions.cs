using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    public List<TransitionPlayerPos> tpp;

    public void SetTrastionPos(int index)
    {
        foreach(var t in tpp)
        {
            if(t.index == index)
            {
                FindObjectOfType<PlayerControl>().transform.position = t.playerTranstion.position;
                StartCoroutine(FadePanel());
            }

        }

    }
    
    IEnumerator FadePanel()
    {
       var ui = FindObjectOfType<UISystem>().CreatePanelUi();

      var player = FindObjectOfType<PlayerControl>();
        player.Anim.WalkAnimation(false);
        player.Anim.RunAnimation(false);
        


        ui.GetComponent<CanvasGroup>().alpha = 1f;
        while (ui.GetComponent<CanvasGroup>().alpha > 0)
        {
            ui.GetComponent<CanvasGroup>().alpha -= 0.01f;

            yield return null;

        }

       
        ui.SetActive(false);


    }



   
}
