
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PanelActive : MonoBehaviour
{
    public TextMeshProUGUI croppanel_text;
    public Button use_button;
    public Button destroy_button;
    public void Close()
    {

        Destroy(this.gameObject);

    }


    private void OnEnable()
    {


        ButtonClickPlayer();
    }



    private void ButtonClickPlayer()
    {
       var use =  use_button.gameObject.AddComponent<EventTrigger>();
       var destroy = use_button.gameObject.AddComponent<EventTrigger>();


        ClickEvent(use);
        ClickEvent(destroy);

    }

    private void ClickEvent(EventTrigger et)
    {
        EventTrigger.Entry entry_pointerDown = new EventTrigger.Entry();
        entry_pointerDown.eventID = EventTriggerType.PointerDown;
        entry_pointerDown.callback.AddListener((data) => PlayerStop((PointerEventData)data));
        et.triggers.Add(entry_pointerDown);


        EventTrigger.Entry entry_pointerUp = new EventTrigger.Entry();
        entry_pointerUp.eventID = EventTriggerType.PointerUp;
        entry_pointerUp.callback.AddListener((data) => PlayerStart((PointerEventData)(data)));
        et.triggers.Add(entry_pointerUp);



    }




    private void PlayerStop(PointerEventData data)
    {
        
        FindObjectOfType<PlayerControl>().PlayerControlStop();
        var pam = FindObjectOfType<PlayerAnimaterMgr>();
        pam.WalkAnimation(false);
        pam.RunAnimation(false);


    }

    private void PlayerStart(PointerEventData data)
    {
        FindObjectOfType<PlayerControl>().PlayerControlStart();
        //Destroy(this.gameObject);

    }


}
