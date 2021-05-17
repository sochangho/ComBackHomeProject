using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSystem : MonoBehaviour
{

    [HideInInspector]
    public List<Tutorials> tutorials = new List<Tutorials>();

    public int tutorial_index = 0;

    public Arrow arrow;


    public Transform arrowLook;

    public Transform treepos;

    public Transform seedpos;

    public Transform growpos;

    public Transform trashpos;

    public Transform treeLook;

    public Transform seedLook;

    public Transform growLook;

    public Transform trashLook;

    private TreeSliceTutorial treeSliceTutorial = new TreeSliceTutorial();

    private SeedTutorial seedTutorial = new SeedTutorial();

    private GrowTutorial growTutorial = new GrowTutorial();

    private ShipCreateTutorial shipCreateTutorial = new ShipCreateTutorial();

    private EscapeTutorial escapeTutorial =  new EscapeTutorial();

    public bool tutorial_trigger = false;

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

        TutorialsAdd();
        StartCoroutine(HpDre());
        StartCoroutine(HungryDre());

        Invoke("TutorialStart", 2f);
        
    }


    public void TutorialsAdd()
    {
        tutorials.Add(treeSliceTutorial);
        tutorials.Add(seedTutorial);
        tutorials.Add(growTutorial);
        tutorials.Add(shipCreateTutorial);
        tutorials.Add(escapeTutorial);

    }





    public void TutorialStart()
    {
        if(tutorial_index == 0)
        {
            StartCoroutine(TreeCameraPosition());
         
        }
        else if (tutorial_index == 1)
        {
           
            StartCoroutine(SeedCameraPosition());
        }
        else if (tutorial_index == 2)
        {
            StartCoroutine(GrowCameraPosition());
        }
        else if (tutorial_index == 3)
        {

            arrow.gameObject.SetActive(false);
            tutorials[3].TutorialSet();
            StartCoroutine(UiRoutin(tutorials[3].suscript));
    
        }
        else if (tutorial_index == 4)
        {
            StartCoroutine(TrashCameraPosition());

        }
        else if(tutorial_index == 5)
        {
            SceneManager.LoadScene("endGo");
            //엔딩
        }




    }



    private void ArrowCh(Transform tf)
    {
      

      
        if (arrow.gameObject.activeSelf == false)
        {
            arrow.gameObject.SetActive(true);
        }

        arrowLook = tf;



    }


    IEnumerator TreeCameraPosition()
    {

        var camera = FindObjectOfType<Camera>();
        FindObjectOfType<PlayerControl>().enabled = false;
       
       

        while (Vector3.Distance(treepos.position , camera.transform.position) > 0.1f)
        {


          

          camera.transform.position = Vector3.MoveTowards(camera.transform.position, treepos.position, 200 * Time.deltaTime);



            yield return null;
        }


        StartCoroutine(CameraRotationRoutin(treeLook));
        ArrowCh(treeLook);
        tutorials[0].TutorialSet();
        StartCoroutine(UiRoutin(tutorials[0].suscript));

       

        Invoke("DelayReturn", 4f);

    }

    IEnumerator SeedCameraPosition()
    {
        var camera = FindObjectOfType<Camera>();
        
        FindObjectOfType<PlayerControl>().enabled = false;

        

        while (Vector3.Distance(seedpos.position, camera.transform.position) > 0.1f)
        {

            camera.transform.position = Vector3.MoveTowards(camera.transform.position, seedpos.position, 200 * Time.deltaTime);


            yield return null;
        }
        StartCoroutine(CameraRotationRoutin(seedLook));
        ArrowCh(seedLook);
        tutorials[1].TutorialSet();
        StartCoroutine(UiRoutin(tutorials[1].suscript));

        Invoke("DelayReturn", 4f);
    }


    IEnumerator GrowCameraPosition()
    {

        var camera = FindObjectOfType<Camera>();
        FindObjectOfType<PlayerControl>().enabled = false;
        

        while (Vector3.Distance(growpos.position, camera.transform.position) > 0.1f)
        {

            camera.transform.position = Vector3.MoveTowards(camera.transform.position, growpos.position, 200 * Time.deltaTime);


            yield return null;
        }
        StartCoroutine(CameraRotationRoutin(growLook));
        ArrowCh(growLook);
        tutorials[2].TutorialSet();
        StartCoroutine(UiRoutin(tutorials[2].suscript));

        Invoke("DelayReturn", 4f);



    }


    IEnumerator TrashCameraPosition()
    {

        var camera = FindObjectOfType<Camera>();
        FindObjectOfType<PlayerControl>().enabled = false;
       

        while (Vector3.Distance(trashpos.position, camera.transform.position) > 0.1f)
        {

            camera.transform.position = Vector3.MoveTowards(camera.transform.position, trashpos.position, 200 * Time.deltaTime);
            yield return null;
        }

        StartCoroutine(CameraRotationRoutin(trashLook));
        ArrowCh(trashLook);
        tutorials[4].TutorialSet();
        StartCoroutine(UiRoutin(tutorials[4].suscript));
        Invoke("DelayReturn", 4f);


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

    }

    public void NextStart()
    {

        StartCoroutine(NextTutorialDelay());
    }





}
