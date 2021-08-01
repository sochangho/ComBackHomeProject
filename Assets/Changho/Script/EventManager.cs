using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : SlngletonGeneral<EventManager>
{
    private Dictionary<string ,List<Action<object>>> _eventDatabase;


    private void Awake()
    {
        _eventDatabase = new Dictionary<string, List<Action<object>>>();
    }



    public static void On(string eventName , Action<object> subscriber)
    {
        if(Instance._eventDatabase.ContainsKey(eventName) == false)
        {
            Instance._eventDatabase.Add(eventName, new List<Action<object>>());


        }


        Instance._eventDatabase[eventName].Add(subscriber);


    }


    public static void Emit(string eventName , object parameter)
    {
        if(Instance._eventDatabase.ContainsKey(eventName) == false)
        {
            Debug.LogWarning($"{eventName} 존재하x");
            return;

        }


        foreach(var action in Instance._eventDatabase[eventName])
        {
            action(parameter);
        }


    }



}
