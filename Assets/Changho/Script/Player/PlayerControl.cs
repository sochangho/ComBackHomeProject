﻿using System.Collections;

using UnityEngine;
using UnityEngine.AI;


// 플레이어 이동 및 아이템 파밍 , 키를 눌렀을 때 행동
public class PlayerControl : MonoBehaviour
{
    public PlayerEquState player_equState;

    public PlayerMotionState player_motion = PlayerMotionState.Walk;

    public ThrowStones stons;

    public GameObject player_positionFix;
    
    public Animator player_animator;

    [SerializeField]
    private Camera player_camera;

    [SerializeField]
    private float player_speed;

    [SerializeField]
    private ItemSlot itemslot;

    [SerializeField]
    private UIButton button;


    [SerializeField]
    private LayerMask layerToMask;

    [HideInInspector]
    public Vector3 target;

    [HideInInspector]
    public float targetToplayer = 0.1f;

    public GameObject spwan_point;

    public Transform point0;

    public Transform point1;

    
    public GameObject equipitem;

    [HideInInspector]
    public GameObject usingitem;

    private Equipment player_equ;

    [SerializeField]
    private EquUI equUI;

   
    public float distanceX;   // 캐릭터x와 - 카메라x의 거리
    public float distanceZ;   // 캐릭터z와 - 카메라z의 위치
    
    
    private float distanceY;

    [HideInInspector]
    public Coroutine hpDecrease_coroutin;
    [HideInInspector]
    public Coroutine hungryDecrease_coroutin;
    [HideInInspector]
    public Coroutine temperature_coroutin;

    public float player_hp = 20f;

    public float player_hungry = 100f;

    public float hp_decrease = 10f;

    public float hp_wait = 20f;

    public float hungry_decerease = 0.3f;

    public float hungry_wait = 20f;

   
    private static PlayerControl _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static PlayerControl Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(PlayerControl)) as PlayerControl;

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
        //rigid = GetComponent<Rigidbody>();
        //character_rigid = Character.GetComponent<Rigidbody>();

       hpDecrease_coroutin = StartCoroutine(HungryDecease());
       distanceY = Mathf.Abs(transform.position.y - player_camera.transform.position.y);       
       player_equ = new Equipment(EquipmentType.Ston);
       
      
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        player_positionFix.transform.localPosition = new Vector3(0, 0, 0);


        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;

            if (Physics.Raycast(player_camera.ScreenPointToRay(Input.mousePosition), out hit, 50f ,layerToMask))   
            {


               

                if (hit.collider.GetComponent<Items>() != null) // 마우스로 클릭한 것이 아이템 일 경우
                {

                    if (Vector3.Distance(transform.position, hit.point) < 7f)
                    {

                        if (hit.collider.CompareTag("Bornfire"))
                        {

                            StartRun(hit.point);

                        }
                        else
                        {
                            GameObject item = hit.collider.gameObject;
                            ItemSystem.Instance.ItemClickAdd(item);
                        }
                    }


                }
                else if (hit.collider.gameObject.layer == 13 && hit.collider.gameObject.layer != 4 && hit.collider.gameObject.layer != 17 && 
                    hit.collider.gameObject.tag != "Tree" && UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() == false)
                {
                    StartRun(hit.point);                  
                }
            }
            // 마우스로 찍은 포인터 값을 target에 반환한다.
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            itemslot.ItemUseZ();
                   
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            itemslot.ItemUseX();

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            itemslot.ItemUseC();

        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            itemslot.ItemUseV();

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            player_equ.ItemUse();
            StopRun();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            player_motion = PlayerMotionState.Run;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            player_motion = PlayerMotionState.Walk;
        }


        if (Input.GetKeyDown(KeyCode.I))
        {
            var inventory = GameObject.Find("InventoryPopup(Clone)");
            if (inventory != null)
            {
                inventory.GetComponent<Inventory>().OnCloseButtonPress();
            }
            else
            {
                button.InventoryButton();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var quest = GameObject.Find("QuestPopup(Clone)");
            if (quest != null)
            {
                quest.GetComponent<Quest>().OnCloseButtonPress();
            }
            else
            {

                button.QuestButton();
            }
        }

        if (player_hp == 0f)
        {
            //애니메이션
            //플레이어 죽음
        }



        if (PlayerRun())
        {

           
            PlayerTurn();
        }
        else
        {
            StopRun();
        }
       

        FollowCamera();
    }

    //플레이어 이동
    private bool PlayerRun()
    {
        var distance = Vector3.Distance(transform.position, target);

 

        if (distance >= targetToplayer )
        {
          
            transform.localPosition = Vector3.MoveTowards(transform.position, target , player_speed * Time.deltaTime);

          
            return true;
        }
   


        return false;
        

    }

    // 플레이어 회전
    private void PlayerTurn()
    {
        var distance = Vector3.Distance(transform.position, target);
        var dir = target - transform.position;
        var dirXZ = new Vector3(dir.x, 0f, dir.z);
     


        if (!(dir.x ==0 && dir.z==0))
        {
            var targetRotation = Quaternion.LookRotation(dirXZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,10* Time.deltaTime);

          

        }
    
        
      
    }

    // 카메라 이동
    private void FollowCamera()
    {

        Vector3 cameraTarget = new Vector3(transform.position.x  - distanceX, transform.position.y + distanceY, transform.position.z - distanceZ );

        player_camera.transform.position = Vector3.Lerp(player_camera.transform.position, cameraTarget, Time.deltaTime * player_speed);

             
    }


    private void StartRun(Vector3 run_pointer)
    {
        if ( player_motion == PlayerMotionState.Walk)
        {

            player_animator.SetBool("Run", false);
            player_animator.SetBool("Walk", true);


        }

        if (player_motion == PlayerMotionState.Run)
        {
            player_animator.SetBool("Walk", false);
            player_animator.SetBool("Run", true);
          

        }

        

        target = run_pointer;

    }


    private void StopRun()
    {
        if (player_animator.GetBool("Walk") == true)
        {
            player_animator.SetBool("Walk", false);
          
        }

        if(player_animator.GetBool("Run") == true)
        {
            player_animator.SetBool("Run", false);

        }



        target = transform.position;
       

    }


   public IEnumerator HpDecrease()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(hp_wait);

        StopCoroutine(hungryDecrease_coroutin);

        while( player_hp > 0)
        {


            player_hp -= hp_decrease;

            yield return waitForSeconds;
        }

    }


   public IEnumerator HungryDecease()
    {

        WaitForSeconds waitForSeconds = new WaitForSeconds(hungry_wait);
        while(player_hungry > 0)
        {
            player_hungry -= hungry_decerease;

            yield return waitForSeconds;

        }

        if (player_hungry <= 0)
        {

            hpDecrease_coroutin = StartCoroutine(HpDecrease());
        }
    }


    /// <summary>
    ///  아이템 장착
    /// </summary>
    public void PlayerEqu(EquipmentType et)
    {

        if(player_equState == PlayerEquState.None)
        {

            player_equState = PlayerEquState.Equ;
            
        }
        

        if(player_equ.equipment_type == et)
        {
            ItemSystem.Instance.ItemInfoUI(player_equ.equipment_type.ToString() + "이미 장착 중입니다.", Color.yellow);

        }
        else
        {

            player_equ.equipment_type= et;


            for (int i = 0; i < equipitem.transform.childCount; i++)
            {
                if (equipitem.transform.GetChild(i).gameObject.activeSelf == true)
                {
                    equipitem.transform.GetChild(i).gameObject.SetActive(false);
                }

            }



            for (int i= 0; i< equipitem.transform.childCount; i++)
            {
                if(equipitem.transform.GetChild(i).GetComponent<Equipment>().ItemType() == player_equ.ItemType())
                {

                    equipitem.transform.GetChild(i).gameObject.SetActive(true);
                    usingitem = equipitem.transform.GetChild(i).gameObject;

                }
                
            }

            equUI.ImageChange(et);
            
        }
    }

    /// <summary>
    /// 무기를 빼고 할 수 있다.
    /// </summary>
    public void PlayerEquStateChange()
    {
       if( player_equState == PlayerEquState.Equ)
        {

            player_equState = PlayerEquState.None;
           

        }


        if (equipitem.transform.childCount >= 1)
        {
            for (int i = 0; i < equipitem.transform.childCount; i++)
            {
               
                if(equipitem.transform.GetChild(i).gameObject.activeSelf == true)
                {
                    equipitem.transform.GetChild(i).gameObject.SetActive(false);
                }


            }

            player_equ.equipment_type = EquipmentType.Ston;
            usingitem = null;
        }



    }

}


public enum PlayerEquState
{
    None,
    Equ
}


public enum PlayerMotionState
{
    Walk,
    Run


}