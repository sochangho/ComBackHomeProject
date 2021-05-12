using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cinemushin1 : MonoBehaviour
{

    public string next_name;


    private void Start()
    {

        CinemushineStart();
    }


    public void CinemushineStart()
    {


        StartCoroutine(CineRoutin(next_name));
    }



    IEnumerator CineRoutin(string nextscene)
    {

        float time = 0; 

        while(time < 5f)
        {
            time += Time.deltaTime;



            yield return null;
        }

        SceneManager.LoadScene(nextscene);

    }






}
