using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Cinemushin3 : MonoBehaviour
{

    public LayerMask layer;
    public Transform start;
    public Transform end;
    public GameObject player;
    public Transform shippoint;
    public GameObject Boat;
    public CinemachineVirtualCamera virtualCamera;
    public Animator player_animator;
    public Transform gohome;
    public AudioSource source;

    private void Start()
    {
        player.transform.position = PointDownTerrain(start);

        player.transform.LookAt(end);

        FindObjectOfType<Light>().intensity = 1f;

        StartCoroutine(GoSeaRoutin());
    }



    IEnumerator GoSeaRoutin()
    {

        virtualCamera.LookAt = player.transform;
        var endpoint = PointDownTerrain(end);
        player_animator.SetBool("Walk", true);

        while (Vector3.Distance(player.transform.position , endpoint) > 0.2f)
        {


            player.transform.position = Vector3.MoveTowards(player.transform.position, endpoint, 5 * Time.deltaTime);




            yield return null;

        }

        StartCoroutine(BoatGo());

    }


    IEnumerator BoatGo()
    {

        
        player_animator.SetBool("Walk", false);
        player.transform.position = PointDownTerrain(shippoint);

        virtualCamera.LookAt=Boat.transform;
       
        player.transform.parent = Boat.transform;

        source.Play();
       

        while(Vector3.Distance(Boat.transform.position, gohome.position) > 0.2f)
        {


            Boat.transform.position = Vector3.MoveTowards(Boat.transform.position, gohome.position, 10 * Time.deltaTime);


            yield return null;
                
        }

        SceneManager.LoadScene("StartScene");

    }



    private Vector3 PointDownTerrain(Transform trans)
    {


        RaycastHit raycastHit;

        Vector3 pos = trans.position;

        if (Physics.Raycast(trans.position, Vector3.down, out raycastHit, 10f, layer))
        {

            pos = raycastHit.point;


        }

        return pos;


    }







}
