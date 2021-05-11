using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        tutorials.Add(new TreeSliceTutorial());
        tutorials.Add(new SeedTutorial());
        tutorials.Add(new GrowTutorial());
        tutorials.Add(new ShipCreateTutorial());
        tutorials.Add(new EscapeTutorial());



        Invoke("TutorialStart", 2f);
        
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

            //엔딩
        }


        Debug.Log("TutorialStart Return");

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


        camera.transform.LookAt(treeLook);
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
        camera.transform.LookAt(seedLook);
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
        camera.transform.LookAt(growLook);
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

        camera.transform.LookAt(trashLook);
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

    private void DelayReturn()
    {
        FindObjectOfType<PlayerControl>().enabled = true;

    }

    public void NextStart()
    {

        StartCoroutine(NextTutorialDelay());
    }


}
