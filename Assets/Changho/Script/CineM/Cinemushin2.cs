using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cinemushin2 : MonoBehaviour
{


    public LayerMask layer;

    [SerializeField]
    private Transform startPoint;


    [SerializeField]
    private Transform endPoint;

    [SerializeField]
    private GameObject dust;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Animator player_animator;


    void Start()
    {
        player.SetActive(false);
        CinemushineStart();
    }

    
    
    private void CinemushineStart()
    {
        StartCoroutine(DustRoutin());


    }


    IEnumerator DustRoutin()
    {

        float time = 0;


        dust.SetActive(true);
        while(time < 0.5f)
        {
            time += Time.deltaTime;


            yield return null;
        }

        player.SetActive(true);
        player.transform.LookAt(endPoint);
        player.transform.position = PointDownTerrain(startPoint);

        StartCoroutine(PlayerMpveRoutin());
    }


    IEnumerator PlayerMpveRoutin()
    {
        Vector3 end = PointDownTerrain(endPoint);
        player_animator.SetBool("Walk", true);
        while (Vector3.Distance(player.transform.position,end) > 0.2f)
        {

            player.transform.position = Vector3.MoveTowards(player.transform.position, end, 10* Time.deltaTime);


            yield return null;
        }

        SceneManager.LoadScene("GroundScene");


    }


    private Vector3 PointDownTerrain(Transform trans)
    {


        RaycastHit raycastHit;

        Vector3 pos = trans.position;

        if(Physics.Raycast(trans.position , Vector3.down , out raycastHit , 10f , layer))
        {

            pos = raycastHit.point;


        }

        return pos;


    }






}
