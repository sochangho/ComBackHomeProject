using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingGameManager : SlngletonGeneral<FishingGameManager>
{


    private PlayerAnimaterMgr animaterMgr;   
    private Fishline fishline;
   
    public List<Items> fishingItems;
    public Transform playerStartPoint;
    public Transform playerStartLookatPoint;   
    
    // Start is called before the first frame update
    void Start()
    {
        animaterMgr = FindObjectOfType<PlayerAnimaterMgr>();
        

 
        EventManager.On("FishingStart", FishsingStartAnimation);
        EventManager.On("FishingStart", FishingStartAction);

        EventManager.On("Acquire", FishingAquireRandom);
        EventManager.On("Acquire", FishingAquireStart);
        EventManager.On("Acquire", FishingAquirAnimation);



    }


 
// StartGameActionEvent-----------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// 애니메이션 함수"StartGameAction"
    /// </summary>
    /// <param name="obj"></param>

    private void FishsingStartAnimation(object obj)
    {
        animaterMgr.FishingStartAnimation(true);

    }
    /// <summary>
    /// "StartGameAction"
    /// </summary>
    /// <param name="obj"></param>
    private void FishingStartAction(object obj)
    {
        fishline = FindObjectOfType<Fishline>();

        fishline.FishingStart();

    }




    ///획득 ----------------------------------------------------------------------------------------------------------------------------------------------------
    ///

 

    private void FishingAquireRandom(object obj)
    {
        int randomvalue = Random.Range(0, fishingItems.Count);
        var fish =Instantiate(fishingItems[randomvalue].gameObject);        
        fish.transform.SetParent(fishline.point3);
        fish.transform.localPosition = new Vector3(0, 0, 0);     
        ItemSystem.Instance.ItemCreate(fish.GetComponent<Fish>());
        StartCoroutine(FishMoveDelay(fish));
        //FindObjectOfType<UISystem>().CreateFishingAquireUi(fish.GetComponent<Items>());

    }


    private void FishingAquireStart(object obj)
    {
        fishline.FishingAquireStart();
    }

    /// <summary>
    /// 월척애니메이션
    /// </summary>
    private void FishingAquirAnimation(object obj)
    {
       animaterMgr.FishingCastAnimation(true);
       animaterMgr.FishingStartAnimation(false);
    }


    IEnumerator FishMoveDelay(GameObject fishobj)
    {
        yield return new WaitForSeconds(5f);
        Destroy(fishobj);
    }


    public void FishingButton()
    {
        EventManager.Emit("FishingStart", null);
    }
 


}



