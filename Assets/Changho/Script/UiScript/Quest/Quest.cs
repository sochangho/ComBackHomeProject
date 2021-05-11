using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest : Popup
{
    [SerializeField]
    private TextMeshProUGUI name;

    [SerializeField]
    private TextMeshProUGUI subscript;

    [SerializeField]
    private TextMeshProUGUI conditions;

    [SerializeField]
    private Button complete_button;


    private void Start()
    {

        complete_button.gameObject.SetActive(false);

        SetQuest();


    }
    public void OnCloseButtonPress()
    {
        FindObjectOfType<PlayerControl>().enabled = true;
        Close();

    }

    private void SetQuest()
    {
        var tutorial = TutorialSystem.Instance;

        name.text = tutorial.tutorials[tutorial.tutorial_index].name;

        subscript.text = tutorial.tutorials[tutorial.tutorial_index].suscript;

        var state = tutorial.tutorials[tutorial.tutorial_index].CompleteConditon();

        conditions.text = tutorial.tutorials[tutorial.tutorial_index].SetCondition(); 



        if(state == TutorialState.Complete)
        {
            complete_button.gameObject.SetActive(true);
            complete_button.onClick.AddListener(TutorialNext);

        }

    }


    public void TutorialNext()
    {


        var tutorial = TutorialSystem.Instance;

        tutorial.tutorial_index++;

        tutorial.NextStart();
        
        OnCloseButtonPress();

    }


}
