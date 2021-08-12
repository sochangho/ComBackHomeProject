using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class TutorialSystem : MonoBehaviour
{
   

    [HideInInspector]
    public List<Tutorials> tutorials = new List<Tutorials>();

    public int tutorial_index = 0;

    public Arrow arrow;

    public GameObject fisingfiled_gameObj;

    public Transform arrowLook;

    public Transform treepos;

    public Transform seedpos;

    public Transform growpos;

    public Transform trashpos;

    public Transform fishingpos;

    public Transform treeLook;

    public Transform seedLook;

    public Transform growLook;

    public Transform trashLook;

    public Transform fishingLook;

    private TreeSliceTutorial treeSliceTutorial = new TreeSliceTutorial();

    private SeedTutorial seedTutorial = new SeedTutorial();

    private GrowTutorial growTutorial = new GrowTutorial();

    private ShipCreateTutorial shipCreateTutorial = new ShipCreateTutorial();

    private EscapeTutorial escapeTutorial =  new EscapeTutorial();

    private FishingTutorial fishingTutorial = new FishingTutorial();

    private List<TutorialCameraInfo> tutorialCameraInfos = new List<TutorialCameraInfo>();

   

    private Coroutine questRoutine;

    public bool tutorial_trigger = false;
    public bool transition = false ;

    

    private static TutorialSystem _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static TutorialSystem Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(TutorialSystem)) as TutorialSystem;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);

        
    }

    private void Start()
    {
        transition = false;
        TutorialsAdd();
        TutorialTransformSetAdd();
        StartCoroutine(HpDre());
        StartCoroutine(HungryDre());

        Invoke("TutorialStart", 2f);
        
    }


    public void TutorialsAdd()
    {
        if(tutorials.Count > 0)
        {
            tutorials.Clear();
        }

        tutorials.Add(new TreeSliceTutorial());
        tutorials.Add(new SeedTutorial());
        tutorials.Add(new GrowTutorial());
        tutorials.Add(new ShipCreateTutorial());

        tutorials.Add(new EscapeTutorial());
       

    }

    public void TutorialTransformSetAdd()
    {
        tutorialCameraInfos.Add(new TutorialCameraInfo(0, treepos.position, treeLook));
        tutorialCameraInfos.Add(new TutorialCameraInfo(1, seedpos.position, seedLook));
        tutorialCameraInfos.Add(new TutorialCameraInfo(2, growpos.position, growLook));      
        tutorialCameraInfos.Add(new TutorialCameraInfo(4, trashpos.position, trashLook));   
        
     

    }

    


    public void TutorialStart()
    {
        
        if (tutorial_index == 3)
        {

            arrow.gameObject.SetActive(false);
            tutorials[3].TutorialSet();
            StartCoroutine(UiRoutin(tutorials[3].suscript));
            return;
        }


        if (tutorial_index == 5)
        {
            SceneManager.LoadScene("endGo");
            return;
            //엔딩
        }

        FindObjectOfType<PlayerControl>().enabled = false;

        var buttons = FindObjectsOfType<Button>();

        foreach(var button in buttons)
        {
            button.interactable = false;
        }

        var player = FindObjectOfType<PlayerControl>();

        player.PlayerControlStop();
        player.Anim.WalkAnimation(false);
        player.Anim.RunAnimation(false);

        foreach (var tutorialCameraInfo in tutorialCameraInfos)
        {
            if(tutorial_index == tutorialCameraInfo.GetTutorialIndex())
            {                              
                Vector3 position_des;
                Transform transform_des;
                tutorialCameraInfo.GetTutorialCameraInfo(out position_des, out transform_des);
                StartCoroutine(TutorialTransformChangeRoution(tutorial_index, position_des, transform_des));
            }
        }

        questRoutine = StartCoroutine(QuestCompleteRoutin());

     

    }



    private void ArrowCh(Transform tf)
    {
      

      
        if (arrow.gameObject.activeSelf == false)
        {
            arrow.gameObject.SetActive(true);
        }

        arrowLook = tf;



    }


    IEnumerator TutorialTransformChangeRoution(int tutorial_index ,Vector3 desitination,Transform  look_transform)
    {
        var camera = FindObjectOfType<Camera>();
       



        while (Vector3.Distance(desitination, camera.transform.position) > 0.1f)
        {




            camera.transform.position = Vector3.MoveTowards(camera.transform.position, desitination, 200 * Time.deltaTime);



            yield return null;
        }


        StartCoroutine(CameraRotationRoutin(look_transform));
        ArrowCh(look_transform);
        tutorials[tutorial_index].TutorialSet();
        StartCoroutine(UiRoutin(tutorials[tutorial_index].suscript));



        Invoke("DelayReturn", 6f);

    }


  


    IEnumerator UiRoutin(string sub)
    {
        float time = 0;
        var ui = FindObjectOfType<UISystem>().TutorialUICreate();
        ui.GetComponent<TutorialInfo>().trutorial_subscript.text = sub;

        while (time < 10f)
        {

            time += Time.deltaTime;


            yield return null;
        }

        Destroy(ui);
        FindObjectOfType<UISystem>().CreateTrasitionUi();
    }

    IEnumerator NextTutorialDelay()
    {
       
        float time = 0;
        while (time < 2f)
        {

            time += Time.deltaTime;


            yield return null;
        }

        TutorialStart();

    }

    IEnumerator CameraRotationRoutin(Transform look )
    {
        var camera = FindObjectOfType<Camera>();

        var dir = (look.position - camera.transform.position).normalized;

        while (camera.transform.forward != dir )
        {
            var targetRotation = Quaternion.LookRotation(dir);
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, targetRotation, 10 * Time.deltaTime);

            yield return null;

        }
        FindObjectOfType<PlayerControl>().PlayerControlStart();

    }


    IEnumerator HpDre()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.05f);

        var hp = FindObjectOfType<PlayerControl>().player_hp;

        

        while (FindObjectOfType<PlayerControl>().player_hp > 50f)
        {

            FindObjectOfType<PlayerControl>().player_hp -= 2f;


            yield return waitForSeconds;
        }



    }

    IEnumerator HungryDre()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.05f);

       
       

        while (FindObjectOfType<PlayerControl>().player_hungry > 10f)
        {

            FindObjectOfType<PlayerControl>().player_hungry -= 2f;


            yield return waitForSeconds;
        }



    }


    private void DelayReturn()
    {
        FindObjectOfType<PlayerControl>().enabled = true;

        var buttons = FindObjectsOfType<Button>();
        foreach (var button in buttons)
        {
            button.interactable = true;
        }

    }

    public void NextStart()
    {

        StartCoroutine(NextTutorialDelay());
    }



    IEnumerator QuestCompleteRoutin()
    {

       
        while (true) {

            if (tutorials[tutorial_index].CompleteConditon() == TutorialState.Complete
                && SceneManager.GetActiveScene().name == "GroundScene" && FindObjectOfType<TrashAddPopup>() == null)
            {
                
                Invoke("OtherUI", 0.2f);
                break;
            }

           
            yield return null;
        }

    }


    IEnumerator otherUIRoutin()
    {
        while (FindObjectOfType<TrashAddPopup>() != null)
        {

            yield return null;


        }

        //ui 생성 함수 
        ItemSystem.Instance.ItemInfoUI("퀘스트 완료!!", Color.blue);
        FindObjectOfType<UIButton>().QuestButton();
        
    }



    private void OtherUI()
    {

        StartCoroutine(otherUIRoutin());

    }

    public void TransitionScene()
    {

        if (questRoutine != null)
        {
            StopCoroutine(questRoutine);
        }
        transition=true;
    }

    public void RestartQuest()
    {

        if (transition)
        {
           
            questRoutine = StartCoroutine(QuestCompleteRoutin());
        }
    }


    public void LakeStart(Action animationAfterCallback )
    {
        fishingLook.position = new Vector3(fishingLook.position.x, FindObjectOfType<PlayerControl>().transform.position.y, fishingLook.position.z);

        FindObjectOfType<PlayerControl>().transform.LookAt(fishingLook);
      
        if (animationAfterCallback != null)
        {

            animationAfterCallback();
        }


    }



}
