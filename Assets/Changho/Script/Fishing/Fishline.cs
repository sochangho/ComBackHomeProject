using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Fishline : MonoBehaviour
{
   
    public Transform point1;
    public Transform point2;
    public Transform point3;
    
    public LineRenderer lineRenderer;
    public int vertexCount = 20;
   
    public FishLineStartPoint fishLineStartPoint;
    public FishLineBackPoint fishLineBackPoint;
    public FishLineFrontPoint fishLineFrontPoint;

    private Vector3 originpoint2;

    private Vector3 originpoint3;


    private void OnEnable()
    {
        originpoint2 = new Vector3(point2.localPosition.x, point2.localPosition.y, point2.localPosition.z);
        originpoint3 = new Vector3(point3.localPosition.x, point3.localPosition.y, point3.localPosition.z);
    }



    private void Update()
    {


        var pointList = new List<Vector3>();

        for (float ratio = 0; ratio < 1; ratio += 1.0f / vertexCount)
        {

            var tangentLineVertex1 = Vector3.Lerp(point1.position, point2.position, ratio);
            var tangentLineVertex2 = Vector3.Lerp(point2.position, point3.position, ratio);
            
            var berzierpoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
            
            pointList.Add(berzierpoint);
            
        }
        lineRenderer.positionCount = pointList.Count;
        lineRenderer.SetPositions(pointList.ToArray());



    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(point1.position, point2.position);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(point2.position, point3.position);

        Gizmos.color = Color.red;

        for (float ratio = 0.5f / vertexCount; ratio < 1; ratio += 1.0f / vertexCount)
        {

            Gizmos.DrawLine(Vector3.Lerp(point1.position, point2.position, ratio),
                Vector3.Lerp(point2.position, point3.position, ratio));
        }
    }

    public void FishingStart()
    {
        point2.localPosition = fishLineStartPoint.point2;
        point3.localPosition = fishLineStartPoint.point3;



        StartCoroutine(FishStartActionRoutinBackPoint2());
        StartCoroutine(FishStartActionRoutinBackPoint3());
        StartCoroutine(FisingGageDelay());
        

    }


    public void FishingAquireStart()
    {

        StartCoroutine(FishingAquireRoutinPoint2());
        StartCoroutine(FishingAquireRoutinPoint3());
        StartCoroutine(FishingAquireAfterDelayAnimation());
        Sounds.Instance.SoundSetActive(true, "FishingPull");
      
    }



    IEnumerator FishStartActionRoutinBackPoint2()
    {
       
        while (Vector3.Distance(point2.localPosition , fishLineBackPoint.point2) > 0.001)
        {

            point2.localPosition = Vector3.MoveTowards(point2.localPosition, fishLineBackPoint.point2, Time.deltaTime);

            yield return null;
        }

        StartCoroutine(FishStartActionRoutinFrontPoint2());

    }

    IEnumerator FishStartActionRoutinBackPoint3()
    {
      
        while (Vector3.Distance(point3.localPosition, fishLineBackPoint.point3) > 0.001)
        {
            point3.localPosition = Vector3.MoveTowards(point3.localPosition, fishLineBackPoint.point3,Time.deltaTime);


            yield return null;
        }

        
        StartCoroutine(FishStartActionRoutinFrontPoint3());
        

    }




    IEnumerator FishStartActionRoutinFrontPoint2()
    {




        while (Vector3.Distance(point2.localPosition, fishLineFrontPoint.point2) > 0.001)
        {

            point2.localPosition = Vector3.MoveTowards(point2.localPosition, fishLineFrontPoint.point2,2 * Time.deltaTime);

            yield return null;
        }

       

    }
    IEnumerator FishStartActionRoutinFrontPoint3()
    {

        while (Vector3.Distance(point3.localPosition, fishLineFrontPoint.point3) > 0.001)
        {

            point3.localPosition = Vector3.MoveTowards(point3.localPosition, fishLineFrontPoint.point3,2*Time.deltaTime);

            yield return null;
        }
        
    }


 
//-----------------------------------------------------------------------------------------------------------------------------------

    IEnumerator FishingAquireRoutinPoint2()
    {
        float time = 0;
        while (time < 5f)
        {
            time += Time.deltaTime;


            point2.localPosition = Vector3.MoveTowards(point2.localPosition, fishLineStartPoint.point2, 2 * Time.deltaTime);
            yield return null;
        }

       
    }
    
    IEnumerator FishingAquireRoutinPoint3()
    {

        float time = 0;
        while (time < 5f)
        {
            time += Time.deltaTime;


            point3.localPosition = Vector3.MoveTowards(point3.localPosition, fishLineStartPoint.point3, 2 * Time.deltaTime);
            yield return null;
        }
        
    }


 

    IEnumerator FisingGageDelay()
    {
        yield return new WaitForSeconds(10f);
        FindObjectOfType<UISystem>().CreateFishingGamge();

    }

    IEnumerator FishingAquireAfterDelayAnimation()
    {
        
        yield return new WaitForSeconds(5f);
        Sounds.Instance.SoundSetActive(false, "FishingPull");
        FindObjectOfType<PlayerAnimaterMgr>().FishingCastAnimation(false);
        FindObjectOfType<PlayerControl>().PlayerControlStart();
        StartCoroutine(origin2Routin());
        StartCoroutine(origin3Routin());
      
        if ((TutorialSystem.Instance.tutorial_index == TutorialSystem.Instance.tutorials.FindIndex(x => x is FishingTutorial))
            && (FindObjectOfType<FishingStartUi>() == null))
        {

            FindObjectOfType<UISystem>().CreateFishingStartUi();

        }

        if(FindObjectOfType<PlayerControl>().fishingItem.activeSelf)
        {
            FindObjectOfType<PlayerControl>().fishingItem.SetActive(false);

        }

        FindObjectOfType<EquUI>().ImageNone();

    }




    IEnumerator origin2Routin()
    {
        while (Vector3.Distance(point2.localPosition, originpoint2) > 0.001)
        {

            point2.localPosition = Vector3.MoveTowards(point2.localPosition, originpoint2, 2 * Time.deltaTime);

            yield return null;
        }
    }


    IEnumerator origin3Routin()
    {
        while (Vector3.Distance(point3.localPosition, originpoint3) > 0.001)
        {

            point3.localPosition = Vector3.MoveTowards(point3.localPosition, originpoint3, 2 * Time.deltaTime);

            yield return null;
        }

    }


}

[System.Serializable]
public class FishLineStartPoint
{
    public Vector3 point2;
    public Vector3 point3;

}

[System.Serializable]
public class FishLineBackPoint
{
    public Vector3 point2;
    public Vector3 point3;


}

[System.Serializable]
public class FishLineFrontPoint
{

    public Vector3 point2;
    public Vector3 point3;



}

