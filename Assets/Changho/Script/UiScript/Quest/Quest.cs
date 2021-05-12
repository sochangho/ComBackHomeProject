
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


    [SerializeField]
    private GameObject shippercent;

    [SerializeField]
    private Image percent_image;

    [SerializeField]
    private TextMeshProUGUI percent_font;


    private void Start()
    {

        complete_button.gameObject.SetActive(false);



       

        SetQuest();

        ShipPercent();

    }
    public void OnCloseButtonPress()
    {
       
        FindObjectOfType<PlayerControl>().enabled = true;
        Close();

    }

    private void SetQuest()
    {
        var tutorial = TutorialSystem.Instance;

        if(tutorial.tutorials[0] == null)
        {

            tutorial.tutorials[0] = new TreeSliceTutorial();
        }
        if(tutorial.tutorials[1] == null)
        {
            tutorial.tutorials[1] = new SeedTutorial();

        }
        if(tutorial.tutorials[2] == null)
        {
            tutorial.tutorials[2] = new GrowTutorial();

        }
        if(tutorial.tutorials[3] == null)
        {
            tutorial.tutorials[3] = new ShipCreateTutorial();
        }
        if (tutorial.tutorials[4] == null)
        {
            tutorial.tutorials[4] = new EscapeTutorial();
        }




        name.text = PlayerPrefs.GetString("name") ;

        subscript.text = PlayerPrefs.GetString("subs");

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

    private void ShipPercent()
    {

       EscapeTutorial escape = (EscapeTutorial)TutorialSystem.Instance.tutorials[4];


        if(TutorialSystem.Instance.tutorial_index == 4)
        {

            shippercent.SetActive(true);


            if(escape.rope > escape.totalrope)
            {
                escape.rope = escape.totalrope;

            }
            if(escape.cloth > escape.totalcloth)
            {
                escape.cloth = escape.totalcloth;
            }
            if(escape.nail > escape.totalnail)
            {
                escape.nail = escape.totalnail;

            }
            if(escape.wood > escape.totalwood)
            {
                escape.wood = escape.totalwood;

            }

            var current = escape.rope + escape.cloth + escape.nail + escape.wood;
            var total = escape.totalrope + escape.totalcloth + escape.totalnail + escape.totalwood;

            percent_image.fillAmount = current / total;
            percent_font.text = ((current / total) * 100).ToString() + "%";


        }
        else
        {
            shippercent.SetActive(false);

        }


    }




}
