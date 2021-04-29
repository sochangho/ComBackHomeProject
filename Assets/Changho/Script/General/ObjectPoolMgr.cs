using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameVanilla.Core;
public class ObjectPoolMgr : MonoBehaviour
{


    public List<ObjectPool> objpool;


    private static ObjectPoolMgr _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static ObjectPoolMgr Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(ObjectPoolMgr)) as ObjectPoolMgr;

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


    public GameObject ParticlePool()
    {

        return objpool[0].GetObject(); 
    }


    public void ParticleReturn(GameObject obj)
    {


        objpool[0].ReturnObject(obj);
    }


    public GameObject BornfirePool()
    {


        return objpool[1].GetObject();
    }



    public void BornfireReturn(GameObject obj)
    {

        objpool[1].ReturnObject(obj);
    }

    public GameObject EnemyPool()
    {

        return objpool[2].GetObject();
    }

    public void EnemyReturn(GameObject obj)
    {

        objpool[2].ReturnObject(obj);
    }


    public GameObject StonPool()
    {

        return objpool[3].GetObject();
    }

    public void StonReturn(GameObject obj)
    {

        objpool[3].ReturnObject(obj);
    }


    public GameObject DustParticlePool()
    {

        return objpool[4].GetObject();
    }

    public void DustParticleReturn(GameObject obj)
    {

        objpool[4].ReturnObject(obj);
    }


    // 바다 아이템
    //

}
