
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


    private void OnEnable()
    {
        Sounds.Instance.SoundPlay("Click");
    }


    private void Start()
    {
        Sounds.Instance.SoundPlay("Open");
        complete_button.gameObject.SetActive(false);

        PlayerStop();


      

        SetQuest();

       // ShipPercent();

    }
    public void OnCloseButtonPress()
    {

        Sounds.Instance.SoundPlay("Click");

        FindObjectOfType<PlayerControl>().enabled = true;
        Close();

    }


    public void OnDestroy()
    {
        Sounds.Instance.SoundPlay("Close");
        
        PlayerStart();
    }


    private void PlayerStop()
    {
        var player = FindObjectOfType<PlayerControl>();

        player.PlayerControlStop();
        player.Anim.WalkAnimation(false);
        player.Anim.RunAnimation(false);
    }

    private void PlayerStart()
    {

        FindObjectOfType<PlayerControl>().PlayerControlStart();

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

            percent_image.fillAmount = ((float)current / (float)total);
            percent_font.text = (((float)current / (float)total) * 100).ToString("N1") + "%";

        }
        else
        {
            shippercent.SetActive(false);

        }


    }




}
