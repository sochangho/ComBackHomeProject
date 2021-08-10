using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{


    [HideInInspector]
    public List<Items> items = new List<Items>();

    [HideInInspector]
    public Dictionary<string, int> trashs = new Dictionary<string, int>();

  
    [HideInInspector]
    public int randomboxAdd;

    [HideInInspector]
    public bool trashAddPopup = false;


    public List<Items> prefebitems;

    public bool warterTrigger = false;


    [SerializeField]
    private RuntimeAnimatorController[] runtimeControllers;
   
    private static ItemSystem _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static ItemSystem Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(ItemSystem)) as ItemSystem;

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

       var player_equ =  FindObjectOfType<PlayerControl>().equipitem;


        
        ItemCreate(new Equipment(EquipmentType.Axe).ItemType());
        ItemCreate(new Fruit(FuritType.Banana).ItemType());
        ItemCreate(new Equipment(EquipmentType.Bowl).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.FireWood).ItemType());
        ItemCreate(new Part(PartType.Nail).ItemType());
        ItemCreate(new Part(PartType.Nail).ItemType());
        ItemCreate(new Part(PartType.Nail).ItemType());
        ItemCreate(new Part(PartType.Nail).ItemType());
        ItemCreate(new Part(PartType.Cloth).ItemType());
        ItemCreate(new Part(PartType.Cloth).ItemType());
        ItemCreate(new Part(PartType.Cloth).ItemType());
        ItemCreate(new Part(PartType.Rope).ItemType());
        ItemCreate(new Part(PartType.Rope).ItemType());
        ItemCreate(new Equipment(EquipmentType.TorchLight).ItemType());

    }


    public void ItemCreate(string itemtypename)
    {

        foreach(var additem in prefebitems)
        {
            if(additem.ItemType() == itemtypename)
            {
                var go = Instantiate(additem.gameObject);
                items.Add(go.GetComponent<Items>());
                go.transform.SetParent(this.transform);
                go.SetActive(false);
                        
            }
        }

    }
    

    /// <summary>
    /// 팝업창 뜨면 실행
    /// </summary>
    public void TrashAdd()
    {
        
        foreach(var trash in trashs)
        {
            for(int j =0; j < trash.Value; j++)
            {

                ItemCreate(trash.Key);

            }


        }


    }


    // 아이템 클릭 획득
    public void ItemClickAdd(GameObject item)
    {

                
        if (item.GetComponent<Items>() != null)
        {

            foreach(var additem in prefebitems)
            {
                if(item.GetComponent<Items>().ItemType() == additem.ItemType())
                {
                    var go = Instantiate(additem.gameObject);
                    items.Add(go.GetComponent<Items>());
                    go.transform.SetParent(this.transform);
                    go.SetActive(false);
                    Destroy(item);
                    ItemSlotCheck(item.GetComponent<Items>());

                }
                

            }

                       
        }
    }



    /// <summary>
    /// 바가지가 있으면 물획득가능 물획득 한번 후에 바가지는 파괴
    /// </summary>
    public void WaterAdd()
    {
        int cnt_bowl = 0;

        if (FindObjectOfType<WarterTrigger>().watercondition)
        {
            return;
        }

        if (FindObjectOfType<PlayerControl>().player_equState == PlayerEquState.None )
        {
          
            ItemInfoUI("물 뿌리개를 착용해주세요", Color.yellow);
            return;
        }
        else
        {
            if(FindObjectOfType<PlayerControl>().usingitem.GetComponent<BowlWater>() == null)
            {
                ItemInfoUI("물 뿌리개를 착용해주세요", Color.yellow);
                return;

            }

        }



        foreach (var item in items)
        {
           
          if(item.ItemType() == "Bowl")
          {


                TutorialSystem.Instance.LakeStart(() =>
                {

                    var bowlWater = FindObjectOfType<PlayerControl>().usingitem.GetComponent<BowlWater>();
                    cnt_bowl = bowlWater.GetWater() + 1;
                    bowlWater.SetWater(cnt_bowl);
                    StartCoroutine(WaterPickUpAnimRoutin());
                    FindObjectOfType<WarterTrigger>().watercondition = true;

                });
                break;
                
          }

        }

        if(cnt_bowl == 0)
        {

            ItemInfoUI("물 뿌리개가 없습니다 ... ", Color.red);
        }
    }

  

    public void BonfireAdd() // 모닥불 생성
    {
        float fw_cnt = 0;
        float st_cnt = 0;


        foreach (var item in items)
        {
           

            if(item.ItemType() == new Part(PartType.FireWood).ItemType())
            {
                fw_cnt++;

            }
            if (item.ItemType() == new Part(PartType.Firestone).ItemType())
            {
                st_cnt++;

            }



        }


        if ((fw_cnt >= 5) && (st_cnt >= 1))
        {
           
            for(int i =0; i < 5; i++)
            {
                foreach(var item in items)
                {
                    if(item.ItemType() == new Part(PartType.FireWood).ItemType())
                    {
                        ItemUseRemove(item);
                        break;
                    }

                }

            }

            for (int i = 0; i < 1; i++)
            {
                foreach (var item in items)
                {
                    if (item.ItemType() == new Part(PartType.Firestone).ItemType())
                    {
                        ItemUseRemove(item);
                        break;
                    }

                }

            }




            ItemCreate(new Equipment(EquipmentType.Bonfire).ItemType());
            ItemInfoUI("모닥불 생성 ", Color.blue);
        }
        else
        {

            ItemInfoUI("모닥불을 만들기에는 아이템 부족......", Color.red);

            return;
        }


    }

    public void TorchLightAdd()
    {
        int oil_cnt = 0;
        int branch_cnt = 0;
        int cloth_cnt = 0;


        foreach (var item in items)
        {
           
            if(item.ItemType() == new Part(PartType.Oil).ItemType())
            {
                
                oil_cnt++;
            }
            if (item.ItemType() == new Part(PartType.Branch).ItemType())
            {

                branch_cnt++;
            }
            if (item.ItemType() == new Part(PartType.Cloth).ItemType())
            {

                cloth_cnt++;
            }


        }



        if (oil_cnt >= 1 && cloth_cnt >= 1 && branch_cnt >= 1)
        {

            foreach (var item in items)
            {
                if (item.ItemType() == new Part(PartType.Oil).ItemType())
                {
                    ItemUseRemove(item);
                    break;
                }

            }

            foreach (var item in items)
            {
                if (item.ItemType() == new Part(PartType.Cloth).ItemType())
                {
                    ItemUseRemove(item);
                    break;
                }

            }

            foreach (var item in items)
            {
                if (item.ItemType() == new Part(PartType.Branch).ItemType())
                {
                    ItemUseRemove(item);
                    break;
                }

            }



            ItemCreate(new Equipment(EquipmentType.TorchLight).ItemType());
            ItemInfoUI("횃불 생성 ", Color.blue);
        }
        else
        {
            ItemInfoUI("횃불을 만들기에는 아이템 부족....", Color.red);
            return;

        }


    }


    public void RaftAdd()
    {
        int fw_cnt = 0;



        foreach (var item in items)
        {
           
            if(item.ItemType() == new Part(PartType.FireWood).ItemType())
            {
                fw_cnt++;

            }

        }



        if (fw_cnt >= 3)
        {
            
            for(int i = 0; i < 3; i++)
            {
                foreach(var item in items)
                {
                    
                    if(item.ItemType() == new Part(PartType.FireWood).ItemType())
                    {

                        ItemUseRemove(item);
                        break;
                    }


                }




            }





            ItemInfoUI("뗏목 생성 ", Color.blue);
            ItemCreate(new Part(PartType.Raft).ItemType());

        }
        else
        {
            ItemInfoUI("뗏목을 만들기에는 아이템 부족......", Color.red);
            return;
        }


    }





    public void OpenBox()
    {
        List<string> trashitemnames = new List<string>();
        var itemsystem = ItemSystem.Instance;
        int randombox_cnt = 0;
        int ran = Random.Range(0, 10);

        trashitemnames.Add("Nail");
        trashitemnames.Add("Fkiller");
        trashitemnames.Add("Bowl");
        trashitemnames.Add("Rope");


        foreach(var item in items)
        {

            if(item.ItemType() == "RandomBox")
            {
                randombox_cnt++;
                ItemUseRemove(item);
                
                break;
            }
            
        }


        if(randombox_cnt == 0)
        {
            ItemInfoUI("인벤토리 창에 랜덤 박스가 없습니다", Color.yellow);
            return;
        }





        if (ran == 0)
        {
            int item_rancnt = Random.Range(0, trashitemnames.Count);
            var item_ranstr = trashitemnames[item_rancnt];
           
            foreach (var item in prefebitems)
            {
                if (item.ItemType() == item_ranstr)
                {
                    ItemCreate(item.ItemType());
                    ItemInfoUI(item.GetItemName() + "을 획득했습니다!!!", Color.blue);



                    break;
                }

            }



        }
        else
        {

            itemsystem.ItemInfoUI("빈 상자 입니다..", Color.yellow);



        }

        
      
    }




    /// <summary>
    /// 아이템을 사용할 경우 회복아이템과 장비에서 모닥불 아이템, 돌은 사용할 경우 개수를 감소킵니다.
    /// </summary>

    public void ItemUseRemove<T>(T it ) where T: Items
    {
       
        foreach(var item in items)
        {
         
            if(item.ItemType() == it.ItemType())
            {
                Debug.Log("삭제"); 
                items.Remove(item);
                Destroy(item.gameObject);
                break;
            }


        }




    }



    private void ItemSlotCheck(Items item)
    {
        var elements = FindObjectOfType<ItemSlot>().useitems;
        int cnt_update = 0;
     
        foreach(var element in elements)
        {
            if(element.GetItemelement() == item.ItemType())
            {
                foreach (var it in items)
                {
                    if (it.ItemType() == item.ItemType())
                    {

                        cnt_update++;

                    }

                }

                element.ElementCntUpdate(cnt_update);
                break;
            }


        }


     


    }


    public void ItemInfoUI(string str , Color font_color)
    {

        var find_information = FindObjectOfType<UIinfo>().gameObject;

        find_information.GetComponent<UIinfo>()._infotext = str;
        find_information.GetComponent<UIinfo>().TextColor(font_color);
        find_information.GetComponent<UIFade>().FadeStart();

    }

    public void TreeItemCreate<T>(Vector3 pos , T item , Material mat ) where T : Items
    {

       
    
        foreach(var prefabitem in prefebitems)
        {
            if(prefabitem.ItemType() == item.ItemType())
            {
                var go = Instantiate(prefabitem);
                var origin_mat = go.GetComponent<MeshRenderer>().materials[0];
                Material[] mats = new Material[1]; 
                mats[0] = mat;
                go.GetComponent<MeshRenderer>().materials = mats;

                go.gameObject.AddComponent<ItemTreeCollider>();
                go.transform.parent = null;
                go.tag = "Item";

                if (item.ItemType() == new Fruit(FuritType.Apple).ItemType())
                {
                    go.transform.position = new Vector3(pos.x, pos.y + 5f, pos.z);

                }
                else
                {
                    go.transform.position = pos;
                }

                float[] distance = new float[2];
                distance[0] = 2f;
                distance[1] = -2f;

             



              
                go.gameObject.AddComponent<Rigidbody>().velocity = GetVelocity(pos,
                new Vector3(pos.x + distance[Random.Range(0,distance.Length)] , pos.y , pos.z + distance[Random.Range(0, distance.Length)]), 45f);

                

              
               StartCoroutine( ItemMove(go.gameObject , origin_mat) );


                break;
            }


        }




    }
    Vector3 GetVelocity(Vector3 currentPos, Vector3 targetPos, float initialAngle)
    {
        float gravity = Physics.gravity.magnitude;
        float angle = initialAngle * Mathf.Deg2Rad;

        Vector3 planarTarget = new Vector3(targetPos.x, 0, targetPos.z);
        Vector3 planarPosition = new Vector3(currentPos.x, 0, currentPos.z);

        float distance = Vector3.Distance(planarTarget, planarPosition);
        float yOffset = currentPos.y - targetPos.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity = new Vector3(0f, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPosition) * (targetPos.x > currentPos.x ? 1 : -1);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        return finalVelocity;
    }


    IEnumerator ItemMove(GameObject obj  , Material mat)
    {

        yield return new WaitForSeconds(1f);
        
        obj.AddComponent<BoxCollider>();
        var particle = ObjectPoolMgr.Instance.ParticlePool();
        particle.transform.position = obj.transform.position;
        StartCoroutine(ItemCreateparticleRoutin(particle));
        
        Sounds.Instance.SoundPlay("Coin");
        Material[] mats = new Material[1];
        mats[0] = mat;
        obj.GetComponent<MeshRenderer>().materials = mats;

        //ItemClickAdd(obj);
    }




    IEnumerator ItemCreateparticleRoutin(GameObject obj)
    {
        float time = 0;
        
        while(time < 1f)
        {
            time += Time.deltaTime;

            yield return null;

        }


        ObjectPoolMgr.Instance.ParticleReturn(obj);


    }

    /// <summary>
    /// 물 뜨는 애니메이션을 사용할 때 버튼 클릭시 walk 애니메이션을 사용되는 버그발생 5월 30일 적음 
    /// 다음 주 주말에 해결!!!
    /// </summary>
    /// <returns></returns>
    IEnumerator WaterPickUpAnimRoutin()
    {

        float time = 0;

        var player = FindObjectOfType<PlayerControl>();
        if(FindObjectOfType<PanelActive>() != null)
        {
            Destroy(FindObjectOfType<PanelActive>().gameObject);
        }

        player.Anim.PickupAnimation(true);
        player.enabled = false;
        Sounds.Instance.SoundPlay("Water");

        while (time < 3f)
        {
            time += Time.deltaTime;

            yield return null;
        }

        player.Anim.PickupAnimation(false);
        player.enabled = true;
        FindObjectOfType<WarterTrigger>().watercondition = false;
        ItemInfoUI("물 획득!!", Color.blue);
        FindObjectOfType<WarterTrigger>().WaterPickup();

    }



}


